namespace AnteyaVIP.Data
{
    using AnteyaVIP.Contracts;
    using AnteyaVIP.Models;

    public interface IDigitalLibraryData
    {
        IDigitalLibraryDbContext Context { get; }

        //IDeletableEntityRepository<Author> Authors { get; }

        //IDeletableEntityRepository<Comment> Comments { get; }

        //IDeletableEntityRepository<Genre> Genres { get; }

        //IRepository<Like> Likes { get; }

        //IDeletableEntityRepository<Work> Works { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
