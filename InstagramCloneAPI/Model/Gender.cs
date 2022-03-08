namespace InstagramCloneAPI.Model
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}