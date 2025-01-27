using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Autualizar Novo Usuário");
            Console.WriteLine("------------------------");
            Console.Write("Id: "); var id = Console.ReadLine();
            Console.Write("Nome: "); var name = Console.ReadLine();
            Console.Write("Email: "); var email = Console.ReadLine();
            Console.Write("Senha: "); var password = Console.ReadLine();
            Console.Write("Biografia: "); var bio = Console.ReadLine();
            Console.Write("UrlImage: "); var Image = Console.ReadLine();
            Console.Write("slug: "); var Slug = Console.ReadLine();
            UpdateUser(new User {
                Id = int.Parse(id),
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

        public static void UpdateUser(User user)
        {
            try
            {
                var repositoryUser = new Repository<User>(Db.Connection);
                repositoryUser.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!");    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar usuario");
                Console.WriteLine(ex.Message);
            }
        }
    }
}