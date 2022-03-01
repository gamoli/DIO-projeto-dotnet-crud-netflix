using System;
using System.Collections.Generic;
using System.Linq;
using Oscarflix.Interfaces;


namespace Oscarflix
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilmes = new List<Filme>();
        public void Atualiza(int id, Filme objeto)
        {
            listaFilmes[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaFilmes[id].MarcarExcluido();
        }

        public void Insere(Filme objeto)
        {
            listaFilmes.Add(objeto);
        }

        public List<Filme> Lista()
        {
            return listaFilmes;
        }

        public int ProximoId()
        {
            return listaFilmes.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaFilmes[id];
        }

        public List<Filme> FiltraPorNome(string nomeParcial)
        {
            var listaFiltrada = (from filmes in listaFilmes
                where filmes.RetornaTitulo().ToUpper().Contains(nomeParcial.ToUpper())
                select filmes).ToList();

            return listaFiltrada;
        }

        public List<Filme> FiltraPorGenero(Genero genero)
        {
            var listaFiltrada = (from filmes in listaFilmes
                where filmes.RetornaGenero() == genero
                select filmes).ToList();

            return listaFiltrada;
        }

        public List<Filme> FiltraPorAnoOscar(int ano)
        {
            var listaFiltrada = (from filmes in listaFilmes
                where filmes.RetornaAnoPremio() == ano
                select filmes).ToList();

            return listaFiltrada;
        }

        public List<Filme> FiltraPorCategoria(Categoria categoria)
        {
            var listaFiltrada = (from filmes in listaFilmes
                where filmes.RetornaPremiacao().Contains(categoria)
                select filmes).ToList();

            return listaFiltrada;
        }
    }
}