using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Atualizar Post");
            Console.WriteLine("--------------------------");
            Console.Write("Id: "); var id = Console.ReadLine();
            Console.Write("Título: "); var title = Console.ReadLine();
            Console.Write("Conteúdo: "); var content = Console.ReadLine();
            Console.Write("Resumo: "); var summary = Console.ReadLine();
            Console.Write("Novo Slug: "); var slug = Console.ReadLine();
            Console.Write("Nova Categoria: "); var categoryId = Console.ReadLine();
            Console.Write("Novo Author: "); var authorId = Console.ReadLine();

            UpdatePost(new Post {
                Id = int.Parse(id),
                Title = title,
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Body = content,
                Slug = slug,
                Summary = summary
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void UpdatePost(Post post)
        { 
            try
            {
                var repository = new Repository<Post>(Db.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}