/***********************************************************************
 * Module:  QuestionarieRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.QuestionarieRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.CL.Repository
{
    public class QuestionarieRepository : GenericFileRepository<Question>
   {

      private readonly MyDbContext dbContext;
      public QuestionarieRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
      public QuestionarieRepository()
      {
         var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
      }
      public QuestionarieRepository(string filePath) : base(filePath) {  }

    }
}