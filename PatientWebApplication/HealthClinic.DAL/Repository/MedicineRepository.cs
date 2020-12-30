/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class MedicineRepository : GenericFileRepository<Medicine>
   {
      private readonly MyDbContext dbContext;
      public MedicineRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      public MedicineRepository()
      {
         this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }
      public MedicineRepository(string filePath) : base(filePath)  { }

      public List<Medicine> GetAll()
      {
         return dbContext.Medicines.ToList();
      }
    }
}