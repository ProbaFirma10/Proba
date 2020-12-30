/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Secretary;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class SecretaryRepository : GenericFileRepository<SecretaryUser>
   {
      private readonly MyDbContext dbContext;
      public SecretaryRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public SecretaryRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public SecretaryRepository(string filePath) : base(filePath) { }

    }
}