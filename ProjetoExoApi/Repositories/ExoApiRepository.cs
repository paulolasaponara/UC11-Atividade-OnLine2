using ProjetoExoApi.Contexts;
using ProjetoExoApi.Interfaces;
using ProjetoExoApi.Models;

namespace ProjetoExoApi.Repositories
{
    public class ExoApiRepository : IExoApiRepository
    {
        private readonly ProjetoExoApiContext _projetoExoApiContext;

        public ExoApiRepository(ProjetoExoApiContext context)
        {
            _projetoExoApiContext= context;
        }

        public void Atualizar(int id, ExoApi exoApi)
        {
            ExoApi exoApiBuscado = _projetoExoApiContext.ExoApi.Find(id);

            if (exoApiBuscado != null)
            {
                exoApiBuscado.NomeDoProjeto = exoApi.NomeDoProjeto;
                exoApiBuscado.DataInicio = exoApi.DataInicio;
                exoApiBuscado.Tecnologia = exoApi.Tecnologia;
            }

            _projetoExoApiContext.ExoApi.Update(exoApiBuscado);
            _projetoExoApiContext.SaveChanges();
        }

        public ExoApi BuscarPorId(int id)
        {
            return _projetoExoApiContext.ExoApi.Find(id);
        }
                
        public void Cadastrar(ExoApi exoApi)
        {
            _projetoExoApiContext.ExoApi.Add(exoApi);
            _projetoExoApiContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            ExoApi exoApi = _projetoExoApiContext.ExoApi.Find(id);
            _projetoExoApiContext.ExoApi.Remove(exoApi);
            _projetoExoApiContext.SaveChanges();
        }

        public List<ExoApi> Ler()
        {
            return _projetoExoApiContext.ExoApi.ToList();
        }
    }
}
