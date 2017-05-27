using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UyeKayit_Ver1.Entity.DBContext;
using UyeKayit_Ver1.Entity.Models;

namespace UyeKayit_Ver1.DAL.Repositories
{
    public class AdminRepo
    {
        public static Admin AdminValid(Admin admin)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.Admins.FirstOrDefault
                    (a => a.NickName == admin.NickName && a.Password == admin.Password);
            }
        }
    }
}
