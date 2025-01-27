using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuário");
            Console.WriteLine("------------------------");
            Console.Write("ID do Usuário: ");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteUser(id);
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void DeleteUser(int id)
        {
            try
            {
                var userDelete = new Repository<User>(Db.Connection);
                userDelete.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}