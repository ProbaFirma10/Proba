using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class EPrescriptionRepository : IEPrescriptionRepository
    {
        private MyDbContext dbContext;
        public EPrescriptionRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public EPrescriptionRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }
        public EPrescription Create(EPrescription prescription)
        {
            dbContext.EPrescriptions.Add(prescription);
            dbContext.SaveChanges();
            return prescription;
        }

        public List<EPrescription> GetAll()
        {
            return dbContext.EPrescriptions.ToList();
        }
    }
}
