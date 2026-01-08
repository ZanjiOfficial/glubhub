
using glubhub.Models;
using System.Text.RegularExpressions;

namespace glubhub.Persistent.Interfaces
{
    public interface IShareService
    {
        Task<Post> ShareToFeedAsync(int originalPostId, Guid sharingUserId, string? comment, CancellationToken cancellationToken = default);
        Task<bool> SendPostAsMessageAsync(int originalPostId, Guid senderUserId, string recipientUserName, string? comment, CancellationToken cancellationToken = default);
    }
}
