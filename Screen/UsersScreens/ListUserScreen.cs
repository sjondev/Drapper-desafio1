using System;
using GBE.Repositories;

namespace GBE.Screen.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("------------------------");
            ListUserWithPost();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void ListUsers()
        {

        }

        public static void ListUserWithPost() 
        {
            try
            {
                var listUser = new UserRepository(Db.Connection);
                var users = listUser.GetWithPost();
                foreach (var user in users)
                {
                    Console.WriteLine($"| ID: {user.Id} | Name: {user.Name} | Email: {user.Email} | ");
                    foreach (var item in user.Posts) {
                        Console.WriteLine($" Titulo do post: {item.Title}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possivel listar os usuários com posts!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}