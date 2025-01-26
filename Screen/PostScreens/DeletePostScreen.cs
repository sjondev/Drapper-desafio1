using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Excluir Post");
            Console.WriteLine("------------------------");
            Console.Write("ID do Post: "); var id = Console.ReadLine();
            DeletePost(int.Parse(id));
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        public static void DeletePost(int id)
        {
            try
            {
                var repository = new Repository<Post>(Db.Connection);
                repository.Delete(id);
                Console.WriteLine("Post excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir o post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}