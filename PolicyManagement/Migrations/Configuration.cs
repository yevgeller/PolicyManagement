namespace PolicyManagement.Migrations
{
    using PolicyManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PolicyManagement.Models.PolicyManagementDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PolicyManagement.Models.PolicyManagementDb context)
        {
            context.Policies.AddOrUpdate(p => p.PolicyNumber, //Here I'm treating the PolicyNumber field as the primary key even though there is a unique Id in the tables
                new Policy
                {
                    PolicyNumber = "A123",
                    EffectiveDate = new DateTime(2017, 1, 1, 0, 0, 1),
                    ExpirationDate = new DateTime(2018, 1, 1, 0, 0, 1),
                    InsuredCustomer = new Customer
                    {
                        FirstName = "Alicia",
                        LastName = "Anderson",
                        CustomerAddress = new Address
                        {
                            AddressLine1 = "123 Army Navy Drive",
                            City = "Springfield",
                            State = "AZ",
                            Zip = "12345"
                        }
                    },
                    InsuredRiskEntity = new RiskEntity
                    {
                        RiskConstruction = ConstructionType.ModularHome,
                        YearBuilt = 1950,
                        RiskAddress = new Address
                        {
                            AddressLine1 = "234 A Avenue",
                            City = "Springfield",
                            State = "AZ",
                            Zip = "12345"
                        }
                    }
                }, new Policy
                {
                    PolicyNumber = "B234",
                    EffectiveDate = new DateTime(2017, 6, 1, 0, 0, 1),
                    ExpirationDate = new DateTime(2018, 7, 1, 0, 0, 1),
                    InsuredCustomer = new Customer
                    {
                        FirstName = "Bernie",
                        LastName = "Bronson",
                        CustomerAddress = new Address
                        {
                            AddressLine1 = "234 Bronn Street",
                            City = "Springfield",
                            State = "BC",
                            Zip = "23451"
                        }
                    },
                    InsuredRiskEntity = new RiskEntity
                    {
                        RiskConstruction = ConstructionType.DoubleWideManufacturedHome,
                        YearBuilt = 1950,
                        RiskAddress = new Address
                        {
                            AddressLine1 = "221B Baker Street",
                            City = "Springfield",
                            State = "BC",
                            Zip = "23451"
                        }
                    }
                }, new Policy
                {
                    PolicyNumber = "C345",
                    EffectiveDate = new DateTime(2017, 9, 1, 0, 0, 1),
                    ExpirationDate = new DateTime(2018, 9, 1, 0, 0, 1),
                    InsuredCustomer = new Customer
                    {
                        FirstName = "Claire",
                        LastName = "Carlson",
                        CustomerAddress = new Address
                        {
                            AddressLine1 = "123 Chanson Street",
                            City = "Springfield",
                            State = "CA",
                            Zip = "34512"
                        }
                    },
                    InsuredRiskEntity = new RiskEntity
                    {
                        RiskConstruction = ConstructionType.SingleWideManufacturedHome,
                        YearBuilt = 1950,
                        RiskAddress = new Address
                        {
                            AddressLine1 = "234 C Street",
                            City = "Springfield",
                            State = "CA",
                            Zip = "34512"
                        }
                    }
                });





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        
    }
}
