using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.CategoryScreens
{
    public class CreateCategoryScreen 
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Nova Categoria");
            Console.WriteLine("-------------------------");
            Console.Write("Insira um nome: "); var name = Console.ReadLine();
            Console.Write("Insira um Slug: "); var slug = Console.ReadLine();

            Create(new Category {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create (Category category) {
            try
            {
                var repository = new Repository<Category>(Db.Connection);
                repository.Create(category);
                Console.WriteLine("Categoria criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a categoria!");
                Console.WriteLine("----------------");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}