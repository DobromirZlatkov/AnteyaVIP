namespace AnteyaVIP.Data
{
    using AnteyaVIP.Contracts;
    using AnteyaVIP.Models;

    public interface IAnteyaVIPData
    {
        IAnteyaVIPDbContext Context { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<Characteristic> Characteristics { get; }

        IDeletableEntityRepository<Manufacturer> Manufacturers { get; }

        IDeletableEntityRepository<Product> Products { get; }

        IRepository<User> Users { get; }

        IRepository<Picture> Pictures { get; }

        int SaveChanges();
    }
}
