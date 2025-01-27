using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Criar Novo Usuário");
            Console.WriteLine("------------------------");
            Console.Write("Nome: "); var name = Console.ReadLine();
            Console.Write("Email: "); var email = Console.ReadLine();
            Console.Write("Senha: "); var password = Console.ReadLine();
            Console.Write("Biografia: "); var bio = Console.ReadLine();
            Console.Write("UrlImage: "); var Image = Console.ReadLine();
            Console.Write("slug: "); var Slug = Console.ReadLine();
            CreateUser(new User {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = Image,
                Slug = Slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void CreateUser(User user)
        {
            try 
            {
                var RepositoryCreateUser = new Repository<User>(Db.Connection);
                RepositoryCreateUser.Create(user);
                Console.WriteLine("Usuário criado com sucesso!");
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}