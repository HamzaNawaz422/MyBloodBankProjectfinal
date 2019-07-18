using BloodReal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BloodReal.Context
{
    public class DonorBlood:DbContext
    {
       public DonorBlood():base("Donor6")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Request> Requests { set; get; }
    }
}