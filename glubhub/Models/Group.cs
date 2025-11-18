namespace glubhub.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public List<User> Members { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Group(List<User> members, string Description, string massage, int groupId) 
        {
            GroupId = groupId;
            Description = Description;
            Message = massage;
            Members = members;

        }
    }
}
