using System;

namespace GBE.Screen.RoleScreens
{
    public static class MenuRoleScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categoria");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar categoria");
            Console.WriteLine("2 - Cadastrar categoria");
            Console.WriteLine("3 - Atualizar categoria");
            Console.WriteLine("4 - Excluir categoria");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}