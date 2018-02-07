using Autenticacaoefcookie.Models;

namespace Autenticacaoefcookie.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(AutenticacaoContext contexto)
        {
            contexto.Database.EnsureCreated();

            var usuario = new Usuario()
            {
                Nome = "Fernando",
                Email = "fernando@gmail.com",
                Senha = "123456"
            };
            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao()
            {
                Nome = "Financeiro"
            };
            contexto.Permissoes.Add(permissao);

            var usuariopermissao = new UsuarioPermissao()
            {
                IdUsuario = usuario.IdUsuario,
                IdPermissao = permissao.IdPermissao
            };
            contexto.UsuariosPermissoes.Add(usuariopermissao);
            contexto.SaveChanges();

        }
    }
}