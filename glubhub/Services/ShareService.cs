using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace glubhub.Services
{
    public class ShareService : IShareService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ShareService>? _logger;

        public ShareService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger<ShareService>? logger = null)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger;
        }

        public async Task<Post> ShareToFeedAsync(int originalPostId, Guid sharingUserId, string? comment, CancellationToken cancellationToken = default)
        {
            var original = await _db.Posts
                .AsNoTracking()
                .Include(p => p.UserId) 
                .FirstOrDefaultAsync(p => p.PostId == originalPostId, cancellationToken);

            if (original == null)
                throw new KeyNotFoundException("Original post not found");

            var content = BuildSharedContent(original, comment);

            // Opret nyt post (sæt kun de felter vi kender fra dit projekt)
            var post = new Post
            {
                UserId = sharingUserId,
                Comment = null,
                Content = content,
                Timestamp = DateTime.UtcNow,
                LikeCount = 0
            };

            _db.Posts.Add(post);

            // Atomisk increment (benytter PostId kolonnen)
            try
            {
                await _db.Database.ExecuteSqlInterpolatedAsync(
                    $"UPDATE Posts SET SharedCount = COALESCE(SharedCount, 0) + 1 WHERE PostId = {originalPostId}",
                    cancellationToken);
            }
            catch (Exception ex)
            {
                _logger?.LogWarning(ex, "Could not increment SharedCount for post {PostId}", originalPostId);
                // Ikke fatal — vi fortsætter med at oprette delingen.
            }

            await _db.SaveChangesAsync(cancellationToken);
            return post;
        }

        public async Task<bool> SendPostAsMessageAsync(int originalPostId, Guid senderUserId, string recipientUserName, string? comment, CancellationToken cancellationToken = default)
        {
            var original = await _db.Posts
                .AsNoTracking()
                .Include(p => p.UserId) 
                .FirstOrDefaultAsync(p => p.PostId == originalPostId, cancellationToken);

            if (original == null)
                return false;

            var recipient = await _userManager.FindByNameAsync(recipientUserName);
            if (recipient == null)
                return false;

            var text = string.IsNullOrWhiteSpace(comment)
                ? (original.Content?.Length > 120 ? original.Content.Substring(0, 120) + "…" : original.Content)
                : comment;

            // Create Message instance and set properties defensively (reflection)
            var msg = new Message(); // antag at Message har parameterfri constructor

            // SenderId: kan være Guid eller string i din model - sæt passende type
            SetPropertyIfExists(msg, new[] { "SenderId", "FromUserId", "UserId" }, senderUserId);

            // RecipientId / ToUserId - sæt hvis muligt
            // recipient.Id kan være string eller Guid afhængigt af Identity-opsætning
            object recipientIdValue = TryParseGuid(recipient.Id) ? Guid.Parse(recipient.Id) : (object)recipient.Id!;
            SetPropertyIfExists(msg, new[] { "RecipientId", "ToUserId", "RecipientUserId" }, recipientIdValue);

            // Tekstfelt: find et passende navnefelt (Text/Body/Content/Message)
            SetPropertyIfExists(msg, new[] { "Text", "Body", "Content", "Message" }, (text ?? "") + $"\n\nLink til opslag: /post/{originalPostId}");

            // Created/Timestamp
            SetPropertyIfExists(msg, new[] { "CreatedAt", "Timestamp", "SentAt" }, DateTime.UtcNow);

            // Hvis din Message-model har ConversationId eller GroupId - vi sætter ikke det, da gruppechat ikke bruges.

            _db.Messages.Add(msg);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }

        private static bool TryParseGuid(string? s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return Guid.TryParse(s, out _);
        }

        /// <summary>
        /// Finder første egnet property på objektet fra propNames og forsøger at sætte værdien (konverterer enkelt mellem Guid/string hvis nødvendigt).
        /// Hvis typen ikke kan konverteres, logger vi og ignorerer.
        /// </summary>
        private void SetPropertyIfExists(object target, string[] propNames, object value)
        {
            var targetType = target.GetType();
            foreach (var name in propNames)
            {
                var prop = targetType.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (prop == null || !prop.CanWrite) continue;

                try
                {
                    var propType = prop.PropertyType;
                    object? converted = ConvertToType(value, propType);
                    if (converted != null || (value == null && (!propType.IsValueType || Nullable.GetUnderlyingType(propType) != null)))
                    {
                        prop.SetValue(target, converted);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogDebug(ex, "Failed to set property {Prop} on {Type}", name, targetType.Name);
                    // prøv næste navn
                }
            }
        }

        private static object? ConvertToType(object value, Type targetType)
        {
            if (value == null) return null;

            var underlying = Nullable.GetUnderlyingType(targetType) ?? targetType;

            // Hvis value allerede er af ønsket type
            if (underlying.IsInstanceOfType(value)) return value;

            // String -> Guid
            if (underlying == typeof(Guid) && value is string s && Guid.TryParse(s, out var g)) return g;

            // Guid -> string
            if (underlying == typeof(string) && value is Guid gv) return gv.ToString();

            // Guid -> Nullable<Guid>
            if (underlying == typeof(Guid) && value is Guid gg) return gg;

            // Objekt til string
            if (underlying == typeof(string)) return value.ToString();

            // DateTime
            if (underlying == typeof(DateTime) && value is DateTime dt) return dt;

            // Simple convert attempt
            try
            {
                return System.Convert.ChangeType(value, underlying);
            }
            catch
            {
                return null;
            }
        }

        private string BuildSharedContent(Post original, string? comment)
        {
            // Antag original indeholder Content og en navigation til User/Author hvis du har det
            var authorName = GetAuthorName(original);
            var originalSnippet = (original.Content ?? "");
            if (originalSnippet.Length > 240) originalSnippet = originalSnippet.Substring(0, 240) + "…";

            if (string.IsNullOrWhiteSpace(comment))
            {
                return $"Del af {authorName}: \"{originalSnippet}\" (se mere)";
            }
            else
            {
                return comment + "\n\n" + $"Del af {authorName}: \"{originalSnippet}\"";
            }
        }

        private string GetAuthorName(Post original)
        {
            // Forsøg at finde et DisplayName/UserName via reflection hvis navigation er anderledes
            var userProp = original.GetType().GetProperty("User") ?? original.GetType().GetProperty("Author");
            if (userProp != null)
            {
                var userObj = userProp.GetValue(original);
                if (userObj != null)
                {
                    var disp = userObj.GetType().GetProperty("DisplayName")?.GetValue(userObj) ??
                               userObj.GetType().GetProperty("UserName")?.GetValue(userObj);
                    if (disp != null) return disp.ToString()!;
                }
            }

            // fallback: prøv OwnerName på post eller lignende
            var nameProp = original.GetType().GetProperty("AuthorName") ?? original.GetType().GetProperty("OwnerName");
            if (nameProp != null)
            {
                var val = nameProp.GetValue(original);
                if (val != null) return val.ToString()!;
            }

            return "ukendt";
        }
    }
}