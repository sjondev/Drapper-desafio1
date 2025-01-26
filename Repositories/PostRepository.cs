using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using GBE.Models;
using GBE.Repository;

namespace GBE.Repositories 
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Post> GetPostsWithCategoryAndAuthor()
        {
            var query = @"
                SELECT 
                    [p].[Id],
                    [p].[Title],
                    [p].[Summary],
                    [p].[Body],
                    [p].[Slug],
                    [p].[CreateDate],
                    [p].[LastUpdateDate],
                    [c].[Id] AS [CategoryId],
                    [c].[Name] AS [CategoryName],
                    [u].[Id] AS [AuthorId],
                    [u].[Name] AS [AuthorName]
                FROM 
                    [Post] AS [p]
                INNER JOIN 
                    [Category] AS [c] ON [p].[CategoryId] = [c].[Id]
                INNER JOIN 
                    [User] AS [u] ON [p].[AuthorId] = [u].[Id]";

            var posts = new List<Post>();
            var result = _connection.Query<Post, Category, User, Post>(
                query,
                (post, category, author) =>
                {
                    if (post != null)
                    {
                        if (category != null)
                        {
                            post.Category = category;
                        }
                        if (author != null)
                        {
                            post.Author = author;
                        }
                    }
                    return post;
                },
                splitOn: "CategoryId,AuthorId");

            return result.ToList();
        }

    }
}
