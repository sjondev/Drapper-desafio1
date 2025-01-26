using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.CategoryScreens 
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar uma categoria");
            Console.WriteLine("--------------------------");
            Console.Write("Id: "); var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Db.Connection);
                repository.Delete(id);
                Console.WriteLine("Categoria excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir a categoria!");
                Console.WriteLine("----------------");
                Console.WriteLine(ex.Message);
            }
        }
    }
}