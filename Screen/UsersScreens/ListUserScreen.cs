using System;
using System.Linq.Expressions;
using GBE.Models;
using GBE.Repositories;
using GBE.Repository;

namespace GBE.Screen.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("------------------------");
            Console.WriteLine(" 1 - Lista de Usuários");
            Console.WriteLine(" 2 - Lista de Usuários com Cargos");
            Console.WriteLine(" 3 - Lista de Usuários com os Posts");
            Console.WriteLine(" 0 - Voltar ao Menu Principal");

            Console.Write("Digite: "); var value = int.Parse(Console.ReadLine()!);
            if (value == 1) {
                Console.Clear();
                Console.ReadKey();
                ListUsers();
                Console.Write("Digite 1 para voltar: "); var back = int.Parse(Console.ReadLine()!);
                if(back == 1) {
                    Console.Clear();
                    Console.ReadKey();
                    Load();
                } else {
                    Console.Clear();
                    Console.ReadKey();
                    MenuUserScreen.Load();
                }
            } else if (value == 2) {
                Console.Clear();
                ListUserWithRole();
                Console.Write("Digite 1 para voltar: "); var back = int.Parse(Console.ReadLine()!);
                if(back == 1) {
                    Console.Clear();
                    Console.ReadKey();
                    Load();
                } else {
                    Console.Clear();
                    Console.ReadKey();
                    MenuUserScreen.Load();
                }
            } else if (value == 3) {
                ListUserWithPost();
                Console.Write("Digite 1 para voltar: "); var back = int.Parse(Console.ReadLine()!);
                if(back == 1) {
                    Console.Clear();
                    Console.ReadKey();
                    Load();
                } else {
                    Console.Clear();
                    Console.ReadKey();
                    MenuUserScreen.Load();
                }
            }
        }

        public static void ListUsers()
        {
            try
            {
                var listUser = new Repository<User>(Db.Connection);
                var users = listUser.Get();
                foreach (var user in users) {
                    Console.WriteLine($"| ID: {user.Id} | Name: {user.Name} | Email: {user.Email} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel usar esta lista de Usuários");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ListUserWithRole() {
            try
            {
                var listUser = new UserRepository(Db.Connection);
                var users = listUser.GetWithRole();
                foreach (var user in users) {
                    Console.WriteLine($"| ID: {user.Id} | Name: {user.Name} | Email: {user.Email} |");
                    foreach (var role in user.Roles) {
                        Console.WriteLine($" Nome do cargo: {role.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel listar os usuários com cargos!");
                Console.WriteLine(ex.Message);
            }
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
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel listar os usuários com posts!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}