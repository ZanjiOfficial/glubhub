namespace glubhub.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public List<User> Members { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Group(string description, string massage, int groupId) 
        {
            GroupId = groupId;
            Description = description;
            Message = massage;
            Members = new List<User>();

        }

        public Group() 
        {
            Members = new List<User>();
        }
    }
}
