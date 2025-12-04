using glubhub.Data;

namespace glubhub.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; } = new List<ApplicationUser>();
        public string Description { get; set; }
        public string Message { get; set; }
        public Group(string description, string massage, int groupId) 
        {
            GroupId = groupId;
            Description = description;
            Message = massage;
            Members = new List<ApplicationUser>();

        }

        public Group() 
        {
            Members = new List<ApplicationUser>();
        }
    }
}
