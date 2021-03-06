﻿namespace AnteyaVIP.Data
{
    using AnteyaVIP.Contracts;
    using AnteyaVIP.Data.Repositories.Base;
    using AnteyaVIP.Models;
    using System;
    using System.Collections.Generic;

    public class AnteyaVIPData : IAnteyaVIPData
    {
        private readonly IAnteyaVIPDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public AnteyaVIPData(IAnteyaVIPDbContext context)
        {
            this.context = context;
        }

        public IAnteyaVIPDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Picture> Pictures
        {
            get { return this.GetRepository<Picture>(); }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get { return this.GetDeletableEntityRepository<Category>(); }
        }

        public IDeletableEntityRepository<Characteristic> Characteristics
        {
            get { return this.GetDeletableEntityRepository<Characteristic>(); }
        }

        public IDeletableEntityRepository<Manufacturer> Manufacturers
        {
            get { return this.GetDeletableEntityRepository<Manufacturer>(); }
        }

        public IDeletableEntityRepository<Product> Products
        {
            get { return this.GetDeletableEntityRepository<Product>(); }
        }

        public IDeletableEntityRepository<Order> Orders
        {
            get { return this.GetDeletableEntityRepository<Order>(); }
        }

        public IDeletableEntityRepository<OrderDetail> OrderDetails
        {
            get { return this.GetDeletableEntityRepository<OrderDetail>(); }
        }

        //public IDeletableEntityRepository<Work> Works
        //{
        //    get { return this.GetDeletableEntityRepository<Work>(); }
        //}

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
