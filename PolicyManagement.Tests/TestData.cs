using PolicyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagement.Tests
{
    public class TestData
    {
        public static IQueryable<Policy> Policies
        {
            get
            {
                List<Policy> policies = new List<Policy>();
                policies.Add(new Policy
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
                });

                policies.Add(new Policy
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
                });

                policies.Add(new Policy
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

                return policies.AsQueryable();
            }
        }
    }
}
