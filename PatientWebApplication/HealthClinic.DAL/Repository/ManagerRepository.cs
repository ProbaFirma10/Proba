/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Manager;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class ManagerRepository : GenericFileRepository<ManagerUser>
   {
      private readonly MyDbContext dbContext;
      public ManagerRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      public ManagerRepository()
      {
         this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }

      public ManagerRepository(string filePath) : base(filePath)  { }

   }
}