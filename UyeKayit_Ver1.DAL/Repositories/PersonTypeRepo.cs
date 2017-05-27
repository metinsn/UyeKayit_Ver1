using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UyeKayit_Ver1.Entity.DBContext;
using UyeKayit_Ver1.Entity.Models;

namespace UyeKayit_Ver1.DAL.Repositories
{
    public class PersonTypeRepo
    {
        public static List<PersonType> GetAll()
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.PersonTypes.ToList();
            }
        }

        public static bool Add(PersonType pt)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                var result = db.PersonTypes.FirstOrDefault(p => p.Name.ToLower() == pt.Name.ToLower());

                if (result == null)
                {
                    db.PersonTypes.Add(pt);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
