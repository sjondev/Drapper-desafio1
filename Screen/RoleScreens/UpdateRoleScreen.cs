using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar um papel");
            Console.WriteLine("------------------------");
            
            Console.Write("Id: ");  var id = Console.ReadLine();
            Console.Write("Nome: "); var name = Console.ReadLine();
            Console.Write("Slug: "); var slug = Console.ReadLine();

            UpdateRole(new Role{
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void UpdateRole(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Db.Connection);
                repository.Update(role);
                Console.WriteLine("Relatório atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possivel atualizar o Relario: {ex.Message}");
            }
        }
    }
}