using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PolicyManagement.Models
{
    public interface IPolicyManagementDb : IDisposable //this is to abstract the database access for testing
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }

    public class PolicyManagementDb : DbContext, IPolicyManagementDb
    {
        public PolicyManagementDb() : base("name=DefaultConnection") { }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<RiskEntity> RiskEntities { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        void IPolicyManagementDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}