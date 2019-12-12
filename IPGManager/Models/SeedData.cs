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

        public static void Populate(IPGManagerDBContext db)
        {

            if (!db.Professor.Any())


            {
                db.Professor.AddRange(
                 new Professor { Pnome = "	Tiago	", Unome = "	Lourenço	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("25-09-1950"), DepartamentoId = 1 },
                    new Professor { Pnome = "	Miguel	", Unome = "	Teixeira	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("12-03-1951"), DepartamentoId = 2 },
                        new Professor { Pnome = "	Afonso	", Unome = "	Figueiredo	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("12-03-1952"), DepartamentoId = 3 },
                        new Professor { Pnome = "	Antonio	", Unome = "	Manuel	", Contacto = "965125764", genero = "Masculino", DataNascimento = DateTime.Parse("13-03-1960"), DepartamentoId = 4 },
                        new Professor { Pnome = "	Morais	", Unome = "	Couves	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("12-06-1952"), DepartamentoId = 1 },
                        new Professor { Pnome = "	Carlos	", Unome = "	Silva	", Contacto = "965154224", genero = "Masculino", DataNascimento = DateTime.Parse("12-03-1970"), DepartamentoId = 2 },
                        new Professor { Pnome = "	Joao	", Unome = "	Costa	", Contacto = "965787524", genero = "Masculino", DataNascimento = DateTime.Parse("15-07-1981"), DepartamentoId = 3 },
                        new Professor { Pnome = "	Alberto	", Unome = "	Tavares	", Contacto = "965132524", genero = "Masculino", DataNascimento = DateTime.Parse("16-03-1952"), DepartamentoId = 4 },
                        new Professor { Pnome = "	Miguel	", Unome = "	Manuel	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("12-12-1980"), DepartamentoId = 1 },
                        new Professor { Pnome = "	Afonso	", Unome = "	Couves	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("12-04-1952"), DepartamentoId = 2 },
                        new Professor { Pnome = "	Antonio	", Unome = "	Silva	", Contacto = "965456224", genero = "Masculino", DataNascimento = DateTime.Parse("12-03-1952"), DepartamentoId = 3 },
                        new Professor { Pnome = "	Morais	", Unome = "	Costa	", Contacto = "965105224", genero = "Masculino", DataNascimento = DateTime.Parse("22-10-1952"), DepartamentoId = 4 },
                        new Professor { Pnome = "	Morais	", Unome = "	Manuel	", Contacto = "965605224", genero = "Masculino", DataNascimento = DateTime.Parse("28-06-1970"), DepartamentoId = 1 },
                        new Professor { Pnome = "	Joao	", Unome = "	Couves	", Contacto = "965105524", genero = "Masculino", DataNascimento = DateTime.Parse("02-11-1952"), DepartamentoId = 2 },
                        new Professor { Pnome = "	Alberto	", Unome = "	Silva	", Contacto = "964105254", genero = "Masculino", DataNascimento = DateTime.Parse("12-05-1980"), DepartamentoId = 3 },
                        new Professor { Pnome = "	Miguel	", Unome = "	Tavares	", Contacto = "965158624", genero = "Masculino", DataNascimento = DateTime.Parse("06-04-1952"), DepartamentoId = 4 }
);
                db.SaveChanges();
            }
        }

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            const string MANAGER_USERNAME = "peter@ipg.pt";
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
