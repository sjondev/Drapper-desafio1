using System.Collections.Generic;
using Dapper;
using GBE.Models;
using System.Linq;
using GBE.Repository;
using Microsoft.Data.SqlClient;

namespace GBE.Repositories 
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<User> GetWithRole() 
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM 
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query, 
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
                
            return users;
        }
        public List<User> GetWithPost()
        {
            var query = @"
                SELECT TOP (100) 
                    [u].[Id] AS [UserId],
                    [u].[Name],
                    [u].[Email],
                    [u].[PasswordHash],
                    [u].[Bio],
                    [u].[Image],
                    [u].[Slug],
                    [p].[Id] AS [PostId],
                    [p].[Title] AS [PostTitle],
                    [p].[Summary] AS [PostSummary],
                    [p].[Body] AS [PostBody],
                    [p].[Slug] AS [PostSlug]
                FROM 
                    [User] u
                LEFT JOIN 
                    [Post] p ON [p].[AuthorId] = [u].[Id];
            ";

            var users = new List<User>();
            
            var items = _connection.Query<User, Post, User>(
                query,
                (user, post) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        usr.Posts = new List<Post>();
                        if (post != null)
                            usr.Posts.Add(post);

                        users.Add(usr);
                    }
                    else
                    {
                        if (post != null)
                            usr.Posts.Add(post);
                    }

                    return user;
                },
                splitOn: "PostId");

            return users;
        }
    }
}