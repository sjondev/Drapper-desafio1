using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.RoleScreens
{
    public static class DeleteRoleScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar um relario");
            Console.WriteLine("--------------------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            DeleteRole(int.Parse(id));

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void DeleteRole(int id)
        {
            try
            {
                var repository = new Repository<Role>(Db.Connection);
                repository.Delete(id);
                Console.WriteLine("Relario excluído com sucesso!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir um relatorio.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}