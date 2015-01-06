using System;
namespace AnteyaVIP.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using AnteyaVIP.Models;

    public interface IAnteyaVIPDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Characteristic> Characteristics { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Picture> Pictures { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
