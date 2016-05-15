using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTreatMD_Model
{
    public class Location
    {
        [Key]
        public int locationID { get; set; }
        public Double latitude { get; set; }
        public Double longitude { get; set; }
        public String address { get; set; }
    }
}
