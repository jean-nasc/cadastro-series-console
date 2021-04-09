using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Listar();
        T ListarPorId(int id);
        void Inserir(T entidade);
        void Atualizar(int id, T entidade);
        void Excluir(int id);
        int proximoId();
    }
}