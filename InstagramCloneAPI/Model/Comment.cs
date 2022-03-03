namespace InstagramCloneAPI.Model
{
     public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}