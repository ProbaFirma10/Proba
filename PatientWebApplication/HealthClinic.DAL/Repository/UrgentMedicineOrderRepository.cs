using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
   public class UrgentMedicineOrderRepository : IUrgentMedicineOrderRepository
    {
      private readonly MyDbContext dbContext;
      public UrgentMedicineOrderRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public UrgentMedicineOrderRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public UrgentMedicineOrder Create(UrgentMedicineOrder order)
      {
            dbContext.UrgentMedicineOrder.Add(order);
            dbContext.SaveChanges();
            return order;
      }

      public List<UrgentMedicineOrder> GetAll()
      {
         return dbContext.UrgentMedicineOrder.ToList();
      }
    }
}