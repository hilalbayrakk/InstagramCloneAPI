namespace InstagramCloneAPI.Model
{
  public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
      

        public virtual ICollection<Post>Posts { get; set; }
         public virtual ICollection<Comment>Comments { get; set; }
    }
}