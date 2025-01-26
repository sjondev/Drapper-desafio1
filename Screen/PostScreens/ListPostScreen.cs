using System;
using GBE.Models;
using GBE.Repositories;
using GBE.Repository;

namespace GBE.Screen.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Lista de Posts");
            Console.WriteLine("------------------------");
            ListPostWithCategoryAndAuthor();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void ListPost()
        {
            var repository = new Repository<Post>(Db.Connection);
            var posts = repository.Get();
            foreach (var post in posts) {
                Console.WriteLine($"| ID: {post.Id} | Title: {post.Title} |");
            }
        }

        public static void ListPostWithCategoryAndAuthor() {
            var postRepository = new PostRepository(Db.Connection);
            var listPostsItems = postRepository.GetPostsWithCategoryAndAuthor();
            foreach (var post in listPostsItems) {
                Console.WriteLine($"| Id: {post.Id} \n| Title: {post.Title} \n| Conteudo: {post.Body} \n| Sumario: {post.Summary} \n| Nome do author: {post.Author.AuthorName} | \n data de criacao: {post.CreateDate} \n| data de utima atualização: {post.LastUpdateDate} \n");            
            }
        }
    }
}