using System;
using GBE.Models;
using GBE.Repository;

namespace GBE.Screen.TagScreens 
{
    public class UpdateTagScreen 
    {
            public static void Load() 
            {
                Console.Clear();
                Console.WriteLine("Atualizado uma tag");
                Console.WriteLine("-----------------------");
                Console.Write("Id: ");
                var id = Console.ReadLine();

                Console.Write("Nome: ");
                var name = Console.ReadLine();

                Console.Write("Slug: ");
                var description = Console.ReadLine();

                Update(new Tag {
                    Id = int.Parse(id),
                    Name = name,
                    Slug = description
                });
                
                Console.ReadKey();
                MenuTagScreen.Load();
            }

            public static void Update(Tag tag)
            {
                try
                {
                    var repository = new Repository<Tag>(Db.Connection);
                    repository.Update(tag);
                    Console.WriteLine("Tag atualizada com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possivel atualizar a tag");
                    Console.WriteLine(ex.Message);
                }
            }
    }
}