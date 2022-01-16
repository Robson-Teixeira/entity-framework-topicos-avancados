using P3.DataContext;
using P3.Domain;
using System;
using System.Data.Entity;
using System.Linq;

namespace P3
{
    static class Program
    {
        static void Main()
        {
            MyDataContext myDataContext = new MyDataContext();
            myDataContext.Database.Log = Logme;
            #region Insert

            #region E-mail

            Email email = new Email
            {
                Name = "treinamentos",
                Domain = "@andrebaltieri.net",
                IsActive = true,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = "master"
            };

            myDataContext.Emails.Add(email);

            #endregion

            #region Organization

            Organization organization = new Organization
            {
                Name = "André Baltieri Treinamentos",
                Email = email,
                Image = "imagemTeste",
                IsActive = true,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = "master"
            };

            myDataContext.Organizations.Add(organization);

            #endregion

            #region Franchise

            Franchise franchise = new Franchise
            {
                Name = "Piracicaba",
                OrganizationId = organization.Id,
                IsActive = true,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = "master"
            };

            myDataContext.Franchises.Add(franchise); 
            
            #endregion

            myDataContext.SaveChanges();

            #endregion

            #region Select

            Organization organizationRetorno;

            organizationRetorno = myDataContext.Organizations
                .Find(organization.Id);

            if (organizationRetorno != null)
                Console.WriteLine($"Consulta via Find.");

            organizationRetorno = myDataContext.Organizations
                .Where(x => x.Id == organization.Id && x.IsActive)
                .FirstOrDefault();

            if (organizationRetorno != null)
                Console.WriteLine($"Consulta via Linq.");

            #endregion

            #region Update

            organization.Name = "André Baltieri Treinamentos S/A";

            myDataContext.Entry(organizationRetorno).State = EntityState.Modified;
            myDataContext.SaveChanges();

            Console.WriteLine($"Registro atualizado!");

            #endregion

            #region Lists

            var organizations = myDataContext.Organizations;

            foreach (Organization o in organizations)
            {
                Console.WriteLine($"{o.Name}");

                foreach (Franchise f in o.Franchises)
                {
                    Console.WriteLine($"\t {f.Name}");

                    foreach (Person p in f.Persons)
                    {
                        Console.WriteLine($"\t\t {p.Name}");
                    }
                }
            }

            var finalOrganizations = organizations
                /*montando objeto/sql com propriedades específicas (ProxyCreationEnabled = false)*/
                .Select(x => new { x.Name, x.Image })
                .Where(x => x.Name.Contains("André"))
                /*executa consulta no BD*/
                .ToList();

            foreach (var finalOrganization in finalOrganizations)
            {
                Console.WriteLine($"{finalOrganization.Name} - {finalOrganization.Image}");
            }

            #endregion

            #region Delete

            myDataContext.Organizations.Remove(organizationRetorno);
            myDataContext.SaveChanges();

            Console.WriteLine($"Registro excluído!");

            #endregion

            myDataContext.Dispose();

            Console.WriteLine("Concluído!");
            Console.ReadKey();
        }

        private static void Logme(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}