using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public List<Serie> Listar()
        {
            return listaSeries;
        }

        public Serie ListarPorId(int id)
        {
            return listaSeries[id];
        }

         public void Inserir(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public void Atualizar(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSeries[id].Excluir();
        }

        public int proximoId()
        {
            return listaSeries.Count;
        }
    }
}