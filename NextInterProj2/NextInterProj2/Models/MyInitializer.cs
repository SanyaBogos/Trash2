using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using WebMatrix.WebData;
using NextInterProj2.Filters;

namespace NextInterProj2.Models
{
    public class MyInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        [InitializeSimpleMembership]
        protected override void Seed(UsersContext context)
        {
            WebSecurity.CreateUserAndAccount("IvanII", "qweqwe",
                        new
                        {
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            BirthDate = DateTime.Now,
                            Email = "ivan@ukr.net",
                            MobileNumber = "78965412302"//,
                            //Image = File.ReadAllBytes(@"D:\Learn\EPAM\images_for_Projects\175ceffaf3f7685d248255b528cc346a.jpeg")
                        });
            //WebSecurity.CreateUserAndAccount("PetroPP", "qweqwe",
            //            new
            //            {
            //                FirstName = "Petro",
            //                LastName = "Petrov",
            //                BirthDate = Convert.ToDateTime("01.02.1987"),
            //                Email = "petro@ukr.net",
            //                MobileNumber = "12365412302",
            //                Image = File.ReadAllBytes(@"D:\Learn\EPAM\images_for_Projects\320x480_2cr4qmwv.gif")
            //            });
            //WebSecurity.CreateUserAndAccount("Vasa", "qweqwe",
            //            new
            //            {
            //                FirstName = "Vasa",
            //                LastName = "Rogov",
            //                BirthDate = Convert.ToDateTime("01.01.1992"),
            //                Email = "vasa@ukr.net",
            //                MobileNumber = "98665412302",
            //                Image = File.ReadAllBytes(@"D:\Learn\EPAM\images_for_Projects\1347542150_v-razreshenii-320x480.jpeg")
            //            });
            //WebSecurity.CreateUserAndAccount("Kolya", "qweqwe",
            //            new
            //            {
            //                FirstName = "Kolya",
            //                LastName = "Nikolayev",
            //                BirthDate = Convert.ToDateTime("01.01.1997"),
            //                Email = "kolya@ukr.net",
            //                MobileNumber = "25865412302",
            //                Image = File.ReadAllBytes(@"D:\Learn\EPAM\images_for_Projects\AppleBokeh-20110319.jpeg")
            //            });
            //WebSecurity.CreateUserAndAccount("Oleg", "qweqwe",
            //            new
            //            {
            //                FirstName = "Oleg",
            //                LastName = "Arhipov",
            //                BirthDate = Convert.ToDateTime("01.01.1995"),
            //                Email = "oleg@ukr.net",
            //                MobileNumber = "43665412302",
            //                Image = File.ReadAllBytes(@"D:\Learn\EPAM\images_for_Projects\frog_320x480_23.jpeg")
            //            });

            base.Seed(context);
        }
    }
}