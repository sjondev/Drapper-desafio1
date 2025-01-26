using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.RoleScreens
{
    public static class CreateRoleScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Crie um novo relatorio");
            Console.WriteLine("-------------------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            CreateRole(new Role {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void CreateRole(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Db.Connection);
                repository.Create(role);
                Console.WriteLine("Relatorio foi criado com sucesso!");    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel criar um novo relatorio!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}