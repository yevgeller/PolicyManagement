using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PolicyManagement.Models
{
    public class PolicyManagementDb : DbContext
    {

        public PolicyManagementDb() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<RiskEntity> RiskEntities { get; set; }
    }
}