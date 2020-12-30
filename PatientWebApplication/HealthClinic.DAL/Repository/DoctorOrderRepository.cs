using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class DoctorOrderRepository : IDoctorOrderRepositoy
    {
      private readonly MyDbContext dbContext;
      public DoctorOrderRepository(MyDbContext context)
      {
         this.dbContext = context;
      }

      public DoctorOrderRepository()
      {
         this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }

      public DoctorsOrder Add(DoctorsOrder order)
      {
         dbContext.DoctorsOrders.Add(order);
         dbContext.SaveChanges();
            return order;
      }

      public List<DoctorsOrder> GetAll()
      {
         return dbContext.DoctorsOrders.ToList();
      }
    }
}
