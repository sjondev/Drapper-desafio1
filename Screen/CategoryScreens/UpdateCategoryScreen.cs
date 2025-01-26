using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar uma categoria");
            Console.WriteLine("--------------------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Category {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category) 
        {
            try
            {
                var repository = new Repository<Category>(Db.Connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}