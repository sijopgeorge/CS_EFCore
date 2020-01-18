using System;
using System.Linq;

namespace CS_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManageDatabase();
                using(var ctx = new Models.PersonDbContext())
                {
                    var person = new Models.Person() { PersonName = "Sijo", Age = 40, Gender = "Male" };
                    ctx.Persons.Add(person);
                    ctx.SaveChanges();
                    Console.WriteLine("Added Person");
                    foreach(var p in ctx.Persons.ToList())
                    {
                        Console.WriteLine($"{p.PersonID} {p.PersonName} {p.Age} {p.Gender}");
                    }
                }//end of using

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// This method will make sure that if the database is already available, then delete it.
        /// </summary>
        static void ManageDatabase()
        {
            using(var ctx = new Models.PersonDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }


    }//End of class
} // End of namespace
