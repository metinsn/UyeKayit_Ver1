using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UyeKayit_Ver1.Entity.DBContext;
using UyeKayit_Ver1.Entity.Models;
using UyeKayit_Ver1.Entity.ViewModels;

namespace UyeKayit_Ver1.DAL.Repositories
{
    public class PersonRepo
    {
        public static List<Person> GetAll()
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.Persons.ToList();
            }
        }
        public static List<PersonVM> GetAllPersonVM()
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.Persons.Select(p => new PersonVM
                {
                    Id = p.Id,
                    Email = p.Email,
                    Fname = p.Fname,
                    Lname = p.Lname,
                    Phone = p.Phone,
                    PersonTypeName = p.PersonType.Name
                }).ToList();
            }
        }
        public static List<PersonVM> GetAllPersonVM(int id)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.Persons.Where(u => u.PersonTypeId == id).Select(p => new PersonVM
                {
                    Email = p.Email,
                    Fname = p.Fname,
                    Lname = p.Lname,
                    Phone = p.Phone,
                    PersonTypeName = p.PersonType.Name
                }).ToList();
            }
        }
        public static void Add(Person person)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }
        public static int PersonCount(int typeId)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                return db.Persons.Where(p => p.PersonTypeId == typeId).ToList().Count;
            }
        }
        public static void Delete(int personId)
        {
            using (UyeKayitEntities db = new UyeKayitEntities())
            {
                var result = db.Persons.FirstOrDefault(p => p.Id == personId);
                db.Persons.Remove(result);
                db.SaveChanges();
            }
        }
    }
}
