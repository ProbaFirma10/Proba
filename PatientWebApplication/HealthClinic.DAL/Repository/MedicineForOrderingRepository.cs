using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class MedicineForOrderingRepository : IMedicineForOrderingRepository
    {
      private readonly MyDbContext dbContext;
      public MedicineForOrderingRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      public MedicineForOrderingRepository()
      {
         this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }
      public MedicineForOrdering Create(MedicineForOrdering medicine)
      {
            dbContext.MedicinesForOrdering.Add(medicine);
            dbContext.SaveChanges();
            return medicine;
      }

      public List<MedicineForOrdering> GetAll()
      {
         return dbContext.MedicinesForOrdering.ToList();
      }
    }
}
