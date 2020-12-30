using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    class RequestMedicineRepository : GenericFileRepository<Medicine>
    {
      private readonly MyDbContext dbContext;
      public RequestMedicineRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public RequestMedicineRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public RequestMedicineRepository(string filePath) : base(filePath) { }
       
    }
}