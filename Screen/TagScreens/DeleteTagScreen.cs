using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("---------------------");
            Console.Write("Qual o id da Tag que deseja excluir? ");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Db.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir a tag");
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}