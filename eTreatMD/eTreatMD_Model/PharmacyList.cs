﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTreatMD_Model
{
    public class PharmacyList
    {
        [Key]
        public int locationID { get; set; }

        public int rankingOrder { get; set; }

        public String country { get; set; }
    }
}
