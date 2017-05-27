using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UyeKayit_Ver1.Entity.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonTypeId { get; set; }

        public virtual PersonType PersonType { get; set; }
    }
}
