using System;
using GBE.Screen.CategoryScreens;
using GBE.Screen.PostScreens;
using GBE.Screen.RoleScreens;
using GBE.Screen.TagScreens;
using GBE.Screen.UserScreens;
using Microsoft.Data.SqlClient;

namespace GBE
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=SA;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Db.Connection = new SqlConnection(CONNECTION_STRING);
            Db.Connection.Open();

            Load();

            Db.Connection.Close();
        }

        private static void Load() {
            Console.Clear();
            Console.WriteLine("Meu Gerenciador");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();

            Console.Write("Digite: ");
            var optioins = short.Parse(Console.ReadLine()!);

            switch (optioins) {
                case 3:
                    Console.Clear();
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    Console.Clear();
                    MenuTagScreen.Load();
                    break;
                
                case 5:
                    Console.Clear();
                    MenuUserScreen.Load();
                    break;

                case 6:
                    Console.Clear();
                    MenuPostScreen.Load();
                    break;

                case 7:
                    Console.Clear();
                    MenuRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }   
}
