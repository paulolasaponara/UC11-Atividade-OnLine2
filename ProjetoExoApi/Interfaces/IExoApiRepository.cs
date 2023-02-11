using ProjetoExoApi.Models;

namespace ProjetoExoApi.Interfaces
{
    public interface IExoApiRepository
    {
        List<ExoApi> Ler();

        void Cadastrar(ExoApi exoApi);

        void Atualizar(int id, ExoApi exoApi);

        void Deletar(int id);

        ExoApi BuscarPorId(int id);

    }
}
