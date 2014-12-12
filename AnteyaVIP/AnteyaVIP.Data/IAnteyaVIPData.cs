namespace AnteyaVIP.Data
{
    using AnteyaVIP.Contracts;
    using AnteyaVIP.Models;

    public interface IAnteyaVIPData
    {
        IAnteyaVIPDbContext Context { get; }

        //IDeletableEntityRepository<Author> Authors { get; }

        //IDeletableEntityRepository<Comment> Comments { get; }

        //IDeletableEntityRepository<Genre> Genres { get; }

        //IRepository<Like> Likes { get; }

        //IDeletableEntityRepository<Work> Works { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
