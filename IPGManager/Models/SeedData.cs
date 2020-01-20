using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class SeedData
    {
        private const string ADMIN_ROLE = "admin";
        private const string MANAGER_ROLE = "manager";
        private const string CHEF_ROLE = "chef";

        /*public static void Populate(IPGManagerDBContext db)
        {
           if (!db.Generos.Any()) {
                db.Generos.AddRange(
                    new GeneroLista { id=1, Genero = "Masculino" },
                    new GeneroLista { id = 2, Genero = "Feminino" },
                    new GeneroLista { id = 3, Genero = "Outro" }
                    );
                
            }
            if (!db.Professor.Any())


            {
                db.Professor.AddRange(
                 new Professor { Nome = "	Tiago Lourenço	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("25-09-1950"), DepartamentoId = 1 },
                    new Professor { Nome = "	Miguel Teixeira	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1951"), DepartamentoId = 2 },
                        new Professor { Nome = "	Afonso 	Figueiredo	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1952"), DepartamentoId = 3 },
                        new Professor { Nome = "	Antonio 	Manuel	", Contacto = "965125764", GeneroId = 1, DataNascimento = DateTime.Parse("13-03-1960"), DepartamentoId = 4 },
                        new Professor { Nome = "	Morais	 	Couves	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-06-1952"), DepartamentoId = 1 },
                        new Professor { Nome = "	Carlos	 Silva	", Contacto = "965154224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1970"), DepartamentoId = 2 },
                        new Professor { Nome = "	Joao	Costa	", Contacto = "965787524", GeneroId = 1, DataNascimento = DateTime.Parse("15-07-1981"), DepartamentoId = 3 },
                        new Professor { Nome = "	Alberto	 	Tavares	", Contacto = "965132524", GeneroId = 1, DataNascimento = DateTime.Parse("16-03-1952"), DepartamentoId = 4 },
                        new Professor { Nome = "	Miguel	 	Manuel	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-12-1980"), DepartamentoId = 1 },
                        new Professor { Nome = "	Afonso	 	Couves	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-04-1952"), DepartamentoId = 2 },
                        new Professor { Nome = "	Antonio		Silva	", Contacto = "965456224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1952"), DepartamentoId = 3 },
                        new Professor { Nome = "	Morais	 	Costa	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("22-10-1952"), DepartamentoId = 4 },
                        new Professor { Nome = "	Morais		Manuel	", Contacto = "965605224", GeneroId = 1, DataNascimento = DateTime.Parse("28-06-1970"), DepartamentoId = 1 },
                        new Professor { Nome = "	Joao		Couves	", Contacto = "965105524", GeneroId = 1, DataNascimento = DateTime.Parse("02-11-1952"), DepartamentoId = 2 },
                        new Professor { Nome = "	Alberto		Silva	", Contacto = "964105254", GeneroId = 1, DataNascimento = DateTime.Parse("12-05-1980"), DepartamentoId = 3 },
                        new Professor { Nome = "	Miguel		Tavares	", Contacto = "965158624", GeneroId = 1, DataNascimento = DateTime.Parse("06-04-1952"), DepartamentoId = 4 }
);

                db.SaveChanges();
            }
            
        }*/

        public static void Populate(IPGManagerDBContext db)
        {
            // ...
        }


        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            const string MANAGER_USERNAME = "manager@ipg.pt";
            const string MANAGER_PASSWORD = "Secret123$";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_USERNAME
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN_ROLE))
            {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }

            user = await userManager.FindByNameAsync(MANAGER_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = MANAGER_USERNAME,
                    Email = MANAGER_USERNAME
                };

                await userManager.CreateAsync(user, MANAGER_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, MANAGER_ROLE))
            {
                await userManager.AddToRoleAsync(user, MANAGER_ROLE);
            }

            user = await userManager.FindByNameAsync("test@ipg.pt");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "test@ipg.pt",
                    Email = "test@ipg.pt"
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            // Create other user accounts ...
        }

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //const string CAN_ADD_MENUS = "can_add_menus";

            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(MANAGER_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(MANAGER_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(CHEF_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(MANAGER_ROLE));
            }
        }
    }
}
