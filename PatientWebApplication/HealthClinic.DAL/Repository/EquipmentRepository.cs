/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class EquipmentRepository : GenericFileRepository<Equipment>
   {
      private readonly MyDbContext dbContext;
      public EquipmentRepository(MyDbContext context)
      {
         this.dbContext = context;
      }

      public EquipmentRepository()
      {
         this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
      }
      public EquipmentRepository(string filePath) : base(filePath){ }

   }
}