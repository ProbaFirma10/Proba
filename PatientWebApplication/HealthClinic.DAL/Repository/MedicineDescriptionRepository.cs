using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class MedicineDescriptionRepository : IMedicineDescriptionRepository
    {
         private readonly MyDbContext dbContext;
         public MedicineDescriptionRepository(MyDbContext dbContext)
         {
            this.dbContext = dbContext;
         }
         public MedicineDescriptionRepository()
         {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
         }
         public MedicineDescription Create(MedicineDescription medicine)
           {
               dbContext.MedicineDescriptions.Add(medicine);
               dbContext.SaveChanges();
               return medicine;
           }

         public List<MedicineDescription> GetAll()
         {
               return dbContext.MedicineDescriptions.ToList();
         }
    }
}
