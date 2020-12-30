/***********************************************************************
 * Module:  EmergencyPhonesRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.EmergencyPhonesRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class EmergencyPhonesRepository : GenericFileRepository<PhoneNumber>
   {
      private readonly MyDbContext dbContext;
      public EmergencyPhonesRepository(MyDbContext context)
      {
            this.dbContext = context;
      }

      public EmergencyPhonesRepository()
      {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }
      public EmergencyPhonesRepository(string filePath) : base(filePath)  { }

    }
}