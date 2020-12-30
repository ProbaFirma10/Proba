/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
   {
      private readonly MyDbContext dbContext;
      public RoomRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public RoomRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public RoomRepository(string filePath) : base(filePath)  { }

    }
}