using ProjetoExoApi.Contexts;
using ProjetoExoApi.Interfaces;
using ProjetoExoApi.Models;

namespace ProjetoExoApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ProjetoExoApiContext _projetoExoApiContext;

        public UsuarioRepository(ProjetoExoApiContext context)
        {
            _projetoExoApiContext = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _projetoExoApiContext.Usuario.Find(id);

            if(usuarioBuscado == null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Tipo = usuario.Tipo;
                
                _projetoExoApiContext.Usuario.Update(usuarioBuscado);
                _projetoExoApiContext.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return _projetoExoApiContext.Usuario.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _projetoExoApiContext.Usuario.Add(usuario);
            _projetoExoApiContext.SaveChanges();
            
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _projetoExoApiContext.Usuario.Find(id);
            _projetoExoApiContext.Usuario.Remove(usuarioBuscado);
            _projetoExoApiContext.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _projetoExoApiContext.Usuario.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _projetoExoApiContext.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
