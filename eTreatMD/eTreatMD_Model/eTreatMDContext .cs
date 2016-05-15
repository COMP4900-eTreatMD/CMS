using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTreatMD_Model
{
    public class eTreatMDContext : DbContext
    {
        public eTreatMDContext() : base("DefaultConnection") { }

        public DbSet<Location> locationList { get; set; }
        public DbSet<PharmacyList> pharmacyList { get; set; }
        public DbSet<PhysiotherapistList> physiotherapistList { get; set; }
        public DbSet<HospitalList> hospitalList { get; set; }
        public DbSet<DoctorList> doctorList { get; set; }
    }
}
