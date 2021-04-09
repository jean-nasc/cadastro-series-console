using System;

namespace DIO.Series.Classes
{
    public class Serie : Base
    {
        private string Nome { get; set; }
        private Categoria Categoria { get; set; }
        private int Ano { get; set; }
        private string Descricao { get; set; }
        private bool Ativo { get; set; }

        public Serie(int Id, string Nome, Categoria Categoria, int Ano, string Descricao)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Categoria = Categoria;
            this.Ano = Ano;
            this.Descricao = Descricao;
            this.Ativo = true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "\nNome: " + this.Nome + (this.Ativo ? " *Ativo* " : " *Inativo* ") + Environment.NewLine;
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao;

            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaStatus()
        {
            return this.Ativo;
        }

        public void Excluir()
        {
            this.Ativo = false;
        }
    }
}