using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Roles");
            Console.WriteLine("------------------------");
            ListRole();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void ListRole() 
        {
            var repository = new Repository<Role>(Db.Connection);
            var items = repository.Get();
            foreach (var item in items) {
                Console.WriteLine($"| ID: {item.Id} | Name: {item.Name} | Slug: {item.Slug} |");
            }
        }
    }
}