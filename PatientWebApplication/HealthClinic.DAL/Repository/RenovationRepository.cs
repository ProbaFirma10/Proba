/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class RenovationRepository : GenericFileRepository<Renovation>
   {
      private readonly MyDbContext dbContext;
      public RenovationRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public RenovationRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public RenovationRepository(string filePath) : base(filePath)  { }

    }
}