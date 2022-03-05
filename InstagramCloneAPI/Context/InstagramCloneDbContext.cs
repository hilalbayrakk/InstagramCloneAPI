using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Context
{
    public class InstagramCloneDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql("server=localhost;database=hbmi;user=root;port=3306;password=toortoor", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.IsBlocked);
                entity.Property(e => e.IsProvided);
                entity.Property(e => e.IsVisibility);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CommentDate);
                entity.HasOne(p => p.User).WithMany(c => c!.Comments).HasForeignKey(p => p.UserId);
                entity.HasOne(p => p.Post).WithMany(c => c!.Comments).HasForeignKey(p => p.PostId);
            });
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Post>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.AddedDate);
               entity.Property(e => e.ImageURL);
               entity.Property(e => e.Description).IsRequired();
               entity.Property(e => e.Latitude);
               entity.Property(e => e.Longtitude);
               entity.Property(e => e.Like);
               entity.HasOne(p => p.User).WithMany(c => c!.Posts).HasForeignKey(p => p.UserId);
           });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.SurName).IsRequired();
                entity.Property(e => e.BirthDate);
                entity.HasOne(p => p.Gender).WithMany(c => c!.Users).HasForeignKey(p => p.GenderId);
                entity.HasOne(p => p.Account).WithMany(c => c!.Users).HasForeignKey(p => p.AccountId);

            });
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Email = "hilal@gmail.com",
                    Password = "01234",
                    IsBlocked = false,
                    IsProvided = true,
                    IsVisibility = true
                },
                new Account
                {
                    Id = 2,
                    Email = "mustafa@gmail.com",
                    Password = "56789",
                    IsBlocked = false,
                    IsProvided = true,
                    IsVisibility = true
                }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Description = "Çok güzel",
                    IsActive = true,
                    UserId = 1,
                    PostId = 1
                },
                 new Comment
                {
                    Id = 2,
                    Description = "Çok çirkin",
                    IsActive = true,
                    UserId = 2,
                    PostId = 2
                }
            );
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Kız"
                },
                 new Gender
                {
                    Id = 2,
                    Name = "Erkek"
                }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Description = "Yeni foto",
                    ImageURL ="Url",
                    Latitude = "1",
                    Longtitude ="1",
                    Like =true,
                    UserId = 1
                },
                new Post
                {
                    Id = 2,
                    Description = "Yeni post",
                    ImageURL ="Url1",
                    Latitude = "2",
                    Longtitude ="2",
                    Like =true,
                    UserId = 2
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Hilal",
                    SurName = "BAYRAK",
                    GenderId = 1,
                    AccountId = 1
                },
                   new User
                {
                    Id = 2,
                    Name = "Mustafa",
                    SurName = "İNCİK",
                    GenderId = 2,
                    AccountId = 2
                }
            );
        }

    }
}