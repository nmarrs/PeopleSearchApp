using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PeopleSearch.Models;
using PeopleSearch.DAL;
using System.Data.Entity.Validation;
using System.Text;

namespace PeopleSearch.DAL
{
    public class PeopleSearchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleSearchContext>
    {
        protected override void Seed(PeopleSearchContext context)
        {
            //Initial seed data, only runs if the model changes, in which database is dropped and re-added with the same 
            //seed data below as well as modified to match the new model.
            var people = new List<Person>
            {
            new Person{FirstName="Nathan", LastName="Marrs", AddressLine1="622 E Grand Ave", AddressLine2="", City="El Segundo", State="CA", ZIP="90245", Age=20, Gender="Male", Email="nathanielmarrs@gmail.com", PrimaryPhone="(385) 236-9681", Interests="Life long learning, nature, music", Picture="/Content/PersonPhoto/NathanMarrs.jpg" }, 
            new Person{FirstName="Erika", LastName="Marrs", AddressLine1="622 E Grand Ave", AddressLine2="", City="El Segundo", State="CA", ZIP="90245", Age=23, Gender="Female", Email="email1@gmail.com", PrimaryPhone="(303) 111-1111", Interests="Annoying her brother", Picture="/Content/PersonPhoto/ErikaMarrs.jpg" },
            new Person{FirstName="Vicki", LastName="Marrs", AddressLine1="622 E Grand Ave", AddressLine2="", City="El Segundo", State="CA", ZIP="90245", Age=49, Gender="Female", Email="email2@gmail.com", PrimaryPhone="(303) 111-1112", Interests="Walking, hiking", Picture="/Content/PersonPhoto/VickiMarrs.jpg" },
            new Person{FirstName="Kevin", LastName="Marrs", AddressLine1="622 E Grand Ave", AddressLine2="", City="El Segundo", State="CA", ZIP="90245", Age=50, Gender="Male", Email="email3@gmail.com", PrimaryPhone="(303) 112-1112", Interests="Working... a lot", Picture="/Content/PersonPhoto/KevinMarrs.jpg" },
            new Person{FirstName="Alex", LastName="Pratt", AddressLine1="100 S Generic Ave", AddressLine2="", City="Huntington Beach", State="CA", ZIP="90600", Age=22, Gender="Male", Email="email4@gmail.com", PrimaryPhone="(385) 236-1111", Interests="Coding, music", Picture="/Content/PersonPhoto/AlexPratt.jpg" },
            new Person{FirstName="Peyton", LastName="Manning", AddressLine1="622 S Football Ave", AddressLine2="", City="Denver", State="CO", ZIP="80015", Age=40, Gender="Male", Email="email5@gmail.com", PrimaryPhone="(303) 111-1113", Interests="Football", Picture="/Content/PersonPhoto/PeytonManning.jpg" }
            };

            people.ForEach(s => context.Persons.Add(s));
            SaveChanges(context);
        }
        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
                //Above is a means of catching errors in entity validation as they are otherwise hard 
                //to find
            }
        }
    }
}