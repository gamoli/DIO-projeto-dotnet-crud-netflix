using System;
using System.Collections.Generic;

namespace Oscarflix
{
    public class Filme : EntidadeBase
    {
        // Atributos
        
        private string Titulo { get; set; }
        private Genero Genero { get; set; }
        private int AnoPremio { get; set; }
        private int AnoFilme { get; set; }
        private List<Categoria> Premiacao { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Filme(int id, string titulo, Genero genero, int anoPremio, int anoFilme, List<Categoria> premiacao)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.AnoPremio = anoPremio;
            this.AnoFilme = anoFilme;
            this.Premiacao = premiacao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título:                 " + this.Titulo + Environment.NewLine;
            retorno += "Gênero:                 " + this.Genero + Environment.NewLine;
            retorno += "Ano de publicação:      " + this.AnoFilme + Environment.NewLine;
            retorno += "Ano da edição do Óscar: " + this.AnoPremio + Environment.NewLine;
            if (this.Premiacao.Count > 1)
            {
                retorno += "Premiações recebidas:   ";
            }
            else
            {
                retorno += "Premiação recebida:     ";
            }
            for (int i = 0; i < this.Premiacao.Count; i++)
            {
                if (i == 0)
                {
                    retorno += this.Premiacao[i] + Environment.NewLine;
                }
                else
                {
                    retorno += "                        " + this.Premiacao[i] + Environment.NewLine;
                }
            }
            retorno += "Excluído:               " + this.Excluido;

            return retorno;
        }
        
        public int RetornaID()
        {
            return this.Id;
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public Genero RetornaGenero()
        {
            return this.Genero;
        }
        public int RetornaAnoPremio()
        {
            return this.AnoPremio;
        }
        public List<Categoria> RetornaPremiacao()
        {
            return this.Premiacao;
        }
        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
        public void MarcarExcluido()
        {
            this.Excluido = true;
        }
    }
}