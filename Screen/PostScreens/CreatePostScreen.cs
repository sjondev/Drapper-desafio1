using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Criar Novo Post");
            Console.WriteLine("------------------------");

            Console.WriteLine("Prencha os campos obrigatorios para criar um Novo Post");
            Console.Write("Título: "); var title = Console.ReadLine();
            Console.Write("Conteúdo: "); var content = Console.ReadLine();
            Console.Write("Categoria do post: "); var categoryId = Console.ReadLine();
            Console.Write("Author do post: "); var authorId = Console.ReadLine();
            Console.Write("Sumario do post: "); var sumario = Console.ReadLine();
            Console.Write("Slug do post: "); var slug = Console.ReadLine();

            CreatePost(new Post { 
                Title = title,
                Body = content,
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Summary = sumario,
                Slug = slug
            });

            
            
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void CreatePost(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Db.Connection);
                repository.Create(post);
                Console.WriteLine("Post criado com sucesso!");    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel criar um novo post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}