using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IPGManager.Models
{
    public class SeedData
    {
        private const string ADMIN_ROLE = "admin";
        private const string MANAGER_ROLE = "manager";

        public static void Populate(IPGManagerDBContext db)
        {
           if (!db.Generos.Any()) {
                db.Generos.AddRange(
                    new GeneroLista { id = 1, Genero = "Masculino" },
                    new GeneroLista { id = 2, Genero = "Feminino" },
                    new GeneroLista { id = 3, Genero = "Outro" }
                    );
                
            }

            if (!db.Funcionario.Any())
            {
                db.Funcionario.AddRange(
                    new Funcionario { Nome = "Joana Frade", Contacto = "912545145", DataNascimento = DateTime.Parse("30-09-1952", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 3 },
                    new Funcionario { Nome = "José Albino", Contacto = "965105224", DataNascimento = DateTime.Parse("25-07-1950", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 1, CargoId = 5 },
                    new Funcionario { Nome = "Alberto Quintas", Contacto = "925447159", DataNascimento = DateTime.Parse("03-05-1960", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 1, CargoId = 7 },
                    new Funcionario { Nome = "Bernardina Rodrigues", Contacto = "936645792", DataNascimento = DateTime.Parse("09-03-1964", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 9 },
                    new Funcionario { Nome = "Carla Vieira", Contacto = "962874412", DataNascimento = DateTime.Parse("11-08-1960", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 8 },
                    new Funcionario { Nome = "Cátia Gulhermino", Contacto = "914582443", DataNascimento = DateTime.Parse("14-07-1955", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 9 },
                    new Funcionario { Nome = "Tiago Santos", Contacto = "934875124", DataNascimento = DateTime.Parse("29-09-1992", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 1 },
                    new Funcionario { Nome = "Telma Pontes", Contacto = "924587455", DataNascimento = DateTime.Parse("17-09-1995", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 8 },
                    new Funcionario { Nome = "Carolina Cruz", Contacto = "965478454", DataNascimento = DateTime.Parse("21-05-1984", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 3 },
                    new Funcionario { Nome = "António Saraiva", Contacto = "915474574", DataNascimento = DateTime.Parse("19-01-1983", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 1, CargoId = 10 },
                    new Funcionario { Nome = "Gonçalo Alves", Contacto = "255471454", DataNascimento = DateTime.Parse("01-01-1972", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 1, CargoId = 11 },
                    new Funcionario { Nome = "Raquel Josefa", Contacto = "936745412", DataNascimento = DateTime.Parse("08-07-1963", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 4 },
                    new Funcionario { Nome = "Paula Sobrancelha", Contacto = "969795597", DataNascimento = DateTime.Parse("25-09-1950", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 2, CargoId = 2 },
                    new Funcionario { Nome = "Miguel Lopes", Contacto = "915625648", DataNascimento = DateTime.Parse("21-04-1950", CultureInfo.CreateSpecificCulture("fr-FR")), GeneroId = 1, CargoId = 8 }
                );



                db.SaveChanges();
            }

            if (!db.Professor.Any())
            {
                db.Professor.AddRange(
                    new Professor { Nome = "Tiago Lourenço", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("25-09-1950", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 1 },
                    new Professor { Nome = "Miguel Teixeira", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1951", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 2 },
                    new Professor { Nome = "Afonso Figueiredo	", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 3 },
                    new Professor { Nome = "Antonio Manuel", Contacto = "965125764", GeneroId = 1, DataNascimento = DateTime.Parse("13-03-1960", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 4 },
                    new Professor { Nome = "Morais Couves", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-06-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 1 },
                    new Professor { Nome = "Carlos Silva", Contacto = "965154224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1970", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 2 },
                    new Professor { Nome = "Joao Costa", Contacto = "965787524", GeneroId = 1, DataNascimento = DateTime.Parse("15-07-1981", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 3 },
                    new Professor { Nome = "Alberto	Tavares	", Contacto = "965132524", GeneroId = 1, DataNascimento = DateTime.Parse("16-03-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 4 },
                    new Professor { Nome = "Miguel Manuel", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-12-1980", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 1 },
                    new Professor { Nome = "Afonso Couves", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("12-04-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 2 },
                    new Professor { Nome = "Antonio Silva", Contacto = "965456224", GeneroId = 1, DataNascimento = DateTime.Parse("12-03-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 3 },
                    new Professor { Nome = "Morais Costa", Contacto = "965105224", GeneroId = 1, DataNascimento = DateTime.Parse("22-10-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 4 },
                    new Professor { Nome = "Morais Manuel", Contacto = "965605224", GeneroId = 1, DataNascimento = DateTime.Parse("28-06-1970", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 1 },
                    new Professor { Nome = "Joao Couves", Contacto = "965105524", GeneroId = 1, DataNascimento = DateTime.Parse("02-11-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 2 },
                    new Professor { Nome = "Alberto Silva", Contacto = "964105254", GeneroId = 1, DataNascimento = DateTime.Parse("12-05-1980", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 3 },
                    new Professor { Nome = "Miguel Tavares", Contacto = "965158624", GeneroId = 1, DataNascimento = DateTime.Parse("06-04-1952", CultureInfo.CreateSpecificCulture("fr-FR")), DepartamentoId = 4 }
                );



                db.SaveChanges();
            }

            if (!db.Cargo.Any())
            {
                db.Cargo.AddRange(
                    new Cargo { NomeCargo = "Auxiliar", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Coordenador de Curso", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Director da Escola", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Director de Curso", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Ginásio", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Jardineiro", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Papelaria", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Presidente", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Professor", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Rececção", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Secretaria", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Supervisor Geral", Descricao = "Descrição do Cargo", NivelCargo = 1 },
                    new Cargo { NomeCargo = "Supervisor Secretaria", Descricao = "Descrição do Cargo", NivelCargo = 1 }
                );
                db.SaveChanges();
            }

        }

       /* public static void Populate(IPGManagerDBContext db)
        {
            // ...
        }*/


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

            /*
            user = await userManager.FindByNameAsync("test@ipg.pt");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "test@ipg.pt",
                    Email = "test@ipg.pt"
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }*/

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

        }
    }
}
