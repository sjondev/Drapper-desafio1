using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorias");
            Console.WriteLine("------------------------");
            ListCategory();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void ListCategory()
        {
            var repository = new Repository<Category>(Db.Connection);
            var items = repository.Get();
            foreach (var item in items) Console.WriteLine($"| ID: {item.Id} | Nome: {item.Name} | Slug: {item.Slug} |");
        }
    }
}