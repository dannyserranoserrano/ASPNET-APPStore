using Microsoft.AspNetCore.Identity;

namespace AppStore.Models.Domain;

public class LoadDatabase
{
    public static async Task InsertarData(
                                            DataBaseContext context,
                                            UserManager<ApplicationUser> usuarioManager,
                                            RoleManager<IdentityRole> roleManager
                                        )
    {
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("ADMIN"));
        }

        if (!usuarioManager.Users.Any())
        {
            var usuario = new ApplicationUser
            {
                Nombre = "Danny",
                Email = "dannyserranoserrano@gmail.com",
                UserName = "danny"
            };

            await usuarioManager.CreateAsync(usuario, "123456");
            await usuarioManager.AddToRoleAsync(usuario, "ADMIN");

        }
        if (!context.Categorias!.Any())
        {
            await context.Categorias!.AddRangeAsync(
            new Categoria { Nombre = "Drama" },
            new Categoria { Nombre = "Comedia" },
            new Categoria { Nombre = "Terror" },
            new Categoria { Nombre = "Acción" },
            new Categoria { Nombre = "Romance" },
            new Categoria { Nombre = "Fantasía" }
            );

            await context.SaveChangesAsync();

        }
        if (!context.Libros!.Any())
        {
            await context.Libros!.AddRangeAsync(
            new Libro
            {
                Titulo = "El Quijote de la Mancha",
                CreateDate = "06/06/1486",
                Imagen = "quijote.jpg",
                Autor = "Miguel De Cervantes"
            },
            new Libro
            {
                Titulo = "Harry Potter",
                CreateDate = "20/09/1994",
                Imagen = "harry.jpg",
                Autor = "Benito Perez"
            }
            );
            await context.SaveChangesAsync();
        }
        if (!context.LibroCategorias!.Any())
        {
            await context.LibroCategorias!.AddRangeAsync(
             new LibroCategoria { CategoriaId = 1, LibroId = 1 },
             new LibroCategoria { CategoriaId = 1, LibroId = 2 }
             );
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }

}
