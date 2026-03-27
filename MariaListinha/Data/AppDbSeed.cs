using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariaListinha.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MariaListinha.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Perfis de usuário (Roles)
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = "22164d6a-40c4-4ee5-b408-90b41dde37c5",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },

            new IdentityRole()
            {
                Id = "0298aec3-2f2a-479e-acb4-144422a15d7a",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Usuários
        List<AppUser> users = new()
        {
            new AppUser()
            {
                Id = "07c08a8c-48a4-4cde-b17f-7fedf5a95c79",
                Email = "admin@marialistinha.com",
                NormalizedEmail = "ADMIN@MARIALISTINHA.COM",
                UserName = "admin@marialistinha.com",
                NormalizedUserName = "ADMIN@MARIALISTINHA.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "Administrador",
                ProfilePicture = "/img/users/default.png"
            },
            new AppUser()
            {
                Id = "41e8ef46-4c13-43cb-9b7e-7222642df441",
                Email = "usuario@marialistinha.com",
                NormalizedEmail = "USUARIO@MARIALISTINHA.COM",
                UserName = "usuario@marialistinha.com",
                NormalizedUserName = "USUARIO@MARIALISTINHA.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "Usuário Teste",
                ProfilePicture = "/img/users/default.png"
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<AppUser>().HasData(users);
        #endregion

        #region Atribuição de Perfis
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id
            },
};
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Tarefas de exemplo
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Estudar programação",
                Description = "Estudar HTML, CSS, JavaScript ou banco de dados por 1 hora",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 2,
                Title = "Fazer amigurumi",
                Description = "Trabalhar um pouco no amigurumi ou aprender um ponto novo",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 3,
                Title = "Criar arte para post",
                Description = "Criar ou planejar um post para redes sociais",
                UserId = users[1].Id
            },
            new ToDo()
            {
                Id = 4,
                Title = "Praticar inglês",
                Description = "Estudar inglês por 20 minutos (vídeo, leitura ou app)",
                UserId = users[1].Id
            },
            new ToDo()
            {
                Id = 5,
                Title = "Organizar tarefas",
                Description = "Planejar o dia e organizar atividades e prioridades",
                UserId = users[2].Id
            },
            new ToDo()
            {
                Id = 6,
                Title = "Cuidar de mim",
                Description = "Separar um tempo para descanso, skincare ou algo que eu goste",
                UserId = users[2].Id
            },
        };
        builder.Entity<ToDo>().HasData(toDos);
        #endregion
    }
}
