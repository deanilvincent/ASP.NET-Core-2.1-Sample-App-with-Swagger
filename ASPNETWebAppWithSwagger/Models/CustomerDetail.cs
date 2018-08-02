using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETWebAppWithSwagger.Models
{
    public class CustomerDetail
    {
        [Key] public int CustomerDetailId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
