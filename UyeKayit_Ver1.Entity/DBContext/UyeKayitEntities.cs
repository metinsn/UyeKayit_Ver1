namespace UyeKayit_Ver1.Entity.DBContext
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class UyeKayitEntities : DbContext
    {
        public UyeKayitEntities()
            : base("name=UyeKayitDB")
        {
            Database.SetInitializer(new UyeKayitDBInitializer());
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
    }

    public class UyeKayitDBInitializer : CreateDatabaseIfNotExists<UyeKayitEntities>
    {
        protected override void Seed(UyeKayitEntities db)
        {
            //db.PersonTypes.Add(new PersonType() { Name = "Genel Kurul Üyesi"});

            db.PersonTypes.AddRange(new List<PersonType>()
            {
                new PersonType() { Name = "Genel Kurulu Üyesi"},
                new PersonType() { Name = "Denetleme Kurulu Üyesi"},
                new PersonType() { Name = "Normal Üye"}
            });

            db.Admins.Add(new Admin()
            {
                NickName = "admin",
                Password = "1234"
            });

            db.SaveChanges();
        }
    }

}