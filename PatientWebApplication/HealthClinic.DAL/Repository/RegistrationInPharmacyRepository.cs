using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class RegistrationInPharmacyRepository : IRegistrationInPharmacyRepository 
    {
      private readonly MyDbContext dbContext;
      public RegistrationInPharmacyRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public RegistrationInPharmacyRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public RegistrationInPharmacy Create(RegistrationInPharmacy registration)
        {
            dbContext.Registrations.Add(registration);
            dbContext.SaveChanges();
            return registration;
        }
        public List<RegistrationInPharmacy> GetAll()
        {
            return dbContext.Registrations.ToList();
        }
       
        public RegistrationInPharmacy getPharmacyApiKey(String apiKey)
        {
            return dbContext.Registrations.ToList().SingleOrDefault(registration => registration.ApiKey == apiKey);
        }
        public Boolean Remove(String apiKey)
        {
            try {
                dbContext.Registrations.Remove(dbContext.Registrations.ToList().SingleOrDefault(registration => registration.ApiKey == apiKey));
                return true;
            }
            catch {return false; }
        }


    }
}
