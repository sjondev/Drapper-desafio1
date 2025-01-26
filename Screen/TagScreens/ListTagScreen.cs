using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.TagScreens 
{
    public class ListTagScreen 
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags");
            Console.WriteLine("-----------------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void List() 
        {
            var repository = new Repository<Tag>(Db.Connection);
            var tags = repository.Get();
            foreach (var tag in tags) {
                Console.WriteLine($"| ID: {tag.Id} | Name: {tag.Name} | Slug: {tag.Slug} |");
            }
        }
    }
}