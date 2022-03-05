namespace InstagramCloneAPI.Model
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public bool Like { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}