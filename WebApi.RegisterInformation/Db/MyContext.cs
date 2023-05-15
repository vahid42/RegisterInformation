using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.RegisterInformation.Domain;

namespace WebApi.RegisterInformation.Db
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=ContextRegisterInformation")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //برای حذف آبشاری برای رابطه یک به چند
            modelBuilder.Entity<CarInfo>()
                        .HasRequired(x => x.User)
                        .WithMany(x => x.CarInfo)
                        .WillCascadeOnDelete();

            ////برای حذف آبشاری برای رابطه چند به یک
            //modelBuilder.Entity<User>()
            //            .HasOptional(x => x.CountrySection)
            //            .WithMany(x => x.Users)
            //            .WillCascadeOnDelete();



            ////برای حذف آبشاری برای رابطه یک به یک
            modelBuilder.Entity<User>()
                        .HasOptional(x => x.UserPermission)
                        .WithRequired(x => x.User)
                        .WillCascadeOnDelete();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<CarInfo> CarInfos { get; set; }
        public virtual DbSet<CountrySection> CountrySections { get; set; }

    }
}