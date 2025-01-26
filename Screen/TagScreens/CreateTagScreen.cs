using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.TagScreens
{
    public class CreateTagScreen 
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("-------------------------");
            Console.Write("Insira um nome: ");
            var name = Console.ReadLine();

            Console.Write("Insira um Slug: ");
            var slug = Console.ReadLine();

            Create(new Tag {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create (Tag tag) {
            try
            {
                var repository = new Repository<Tag>(Db.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a tag!");
                Console.WriteLine("----------------");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}