using System;
using System.Collections.Generic;
using System.Linq;

namespace Oscarflix
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoMenuPrincipal = EscolhaMenuPrincipal();

            while (opcaoMenuPrincipal != "X")
            {
                switch (opcaoMenuPrincipal)
                {
                    case "1":
                        string opcaoPesquisa = EscolhaMenuPesquisa();
                        switch (opcaoPesquisa)
                        {
                            case "1":
                                VisualizarFilme();
                                break;
                            case "2":
                                FiltrarNome();
                                break;
                            case "3":
                                FiltrarGenero();
                                break;
                            case "4":
                                FiltrarAnoOscar();
                                break;
                            case "5":
                                FiltrarCategoriaOscar();
                                break;
                            case "6":
                                ListarFilmes();
                                break;
                            case "V":
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                if(opcaoMenuPrincipal != "C")
                {
                    Console.Write("Pressione Enter para continuar...");
                    Console.ReadLine();
                }
                
                opcaoMenuPrincipal = EscolhaMenuPrincipal();
            }
		}
        
        private static string EscolhaMenuPrincipal()
        {
            Console.WriteLine("---------------------------- OSCARFLIX ----------------------------");
            Console.WriteLine("Sua central de filmes vencedores do maior prêmio do cinema mundial!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("(1) Pesquisar filme(s)");
            Console.WriteLine("(2) Inserir novo filme");
            Console.WriteLine("(3) Atualizar filme");
            Console.WriteLine("(4) Excluir filme");
            Console.WriteLine("(C) Limpar a tela");
            Console.WriteLine("(X) Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string EscolhaMenuPesquisa()
        {
            Console.WriteLine("--- Menu de Pesquisas ---");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            
            Console.WriteLine("(1) Visualizar um filme pelo ID");
            Console.WriteLine("(2) Filtrar pelo título");
            Console.WriteLine("(3) Filtrar por gênero");
            Console.WriteLine("(4) Filtrar pelo ano da edição do Óscar");
            Console.WriteLine("(5) Filtrar por categoria da premiação");
            Console.WriteLine("(6) Listar todos filmes");
            Console.WriteLine("(V) Voltar ao Menu Principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o ID do filme que deseja exibir: ");
            int entradaId = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(entradaId);

            Console.WriteLine(filme);

            Console.WriteLine();
        }

        private static void FiltrarNome()
        {
            Console.WriteLine("---> Filtrar filmes pelo título");
            Console.WriteLine();

            Console.Write("Digite parte do título do filme para exibir a lista: ");
            string entradaNomeParcial = Console.ReadLine();

            var listaFiltrada = repositorio.FiltraPorNome(entradaNomeParcial);
            if (listaFiltrada.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Encontrado...");
                Console.WriteLine("... retornando ao Menu Principal");
                Console.WriteLine();
                return;
            }
            
            foreach (var filme in listaFiltrada)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.RetornaID(), filme.RetornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }

            Console.WriteLine();
        }

        private static void FiltrarGenero()
        {
            Console.WriteLine("---> Filtrar filmes pelo gênero");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha o gênero à filtrar dentre as opções acima: ");
            int entradaGenero  = int.Parse(Console.ReadLine());

            var listaFiltrada = repositorio.FiltraPorGenero((Genero)entradaGenero);
            if (listaFiltrada.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Encontrado...");
                Console.WriteLine("... retornando ao Menu Principal");
                Console.WriteLine();
                return;
            }
            
            foreach (var filme in listaFiltrada)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.RetornaID(), filme.RetornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }

            Console.WriteLine();
        }

        private static void FiltrarAnoOscar()
        {
            Console.WriteLine("---> Filtrar filmes pelo ano da Edição do Óscar");
            Console.WriteLine();

            Console.Write("Digite o ano à filtrar: ");
            int entradaAnoEdicao = int.Parse(Console.ReadLine());

            var listaFiltrada = repositorio.FiltraPorAnoOscar(entradaAnoEdicao);
            if (listaFiltrada.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Encontrado...");
                Console.WriteLine("... retornando ao Menu Principal");
                Console.WriteLine();
                return;
            }
            
            foreach (var filme in listaFiltrada)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.RetornaID(), filme.RetornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }

            Console.WriteLine();
        }

        private static void FiltrarCategoriaOscar()
        {
            Console.WriteLine("---> Filtrar filmes vencedores por categoria");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("Escolha a categoria do prêmio à filtrar dentre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            var listaFiltrada = repositorio.FiltraPorCategoria((Categoria)entradaCategoria);
            if (listaFiltrada.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Encontrado...");
                Console.WriteLine("... retornando ao Menu Principal");
                Console.WriteLine();
                return;
            }
            
            foreach (var filme in listaFiltrada)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.RetornaID(), filme.RetornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }

            Console.WriteLine();
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("---> Listar filmes");
            Console.WriteLine();
            var listaFilme = repositorio.Lista();

            if (listaFilme.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Cadastrado !");
                Console.WriteLine("... retornando ao Menu Principal");
                Console.WriteLine();
                return;
            }
            
            foreach (var filme in listaFilme)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.RetornaID(), filme.RetornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
            }
            
            Console.WriteLine();
        }

        private static void InserirFilme()
        {
            Console.WriteLine("---> Inserir filmes");
            Console.WriteLine();
            
            // Entradas do usuário
            Console.Write("1) Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("2) Escolha o gênero do filme dentre as opções acima: ");
            int entradaGenero  = int.Parse(Console.ReadLine());

            Console.Write("3) Digite o ano de publicação do filme: ");
            int entradaAnoPublicacao  = int.Parse(Console.ReadLine());

            Console.Write("4) Digite o ano da premiação do filme: ");
            int entradaAnoPremiacao  = int.Parse(Console.ReadLine());

            Console.Write("5a) Digite quantas premiações foram recebida pelo filme: ");
            int qtdPremiacoes = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.WriteLine("5b) Escolha a(s) categoria(s) da(s) premiação(ões) recebida(s) pelo filme dentre as opções acima");
            List<int> entradasCategoria  = new List<int>();
            for (int i = 1; i <= qtdPremiacoes; i++)
            {
                Console.Write("     Premio #{0}: ",i);
                entradasCategoria.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            // Criação do novo objeto
            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        titulo: entradaTitulo,
                                        genero: (Genero)entradaGenero,
                                        anoPremio: entradaAnoPremiacao,
                                        anoFilme: entradaAnoPublicacao,
                                        premiacao: entradasCategoria.Select(item => (Categoria) item).ToList());

            // Inserção da nova instância no repositório
            repositorio.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("---> Atualizar filme");
            Console.WriteLine();

            Console.Write("Digite o ID do filme: ");
            int entradaId = int.Parse(Console.ReadLine());
            Console.WriteLine("... Filme selecionado para atualização: {0}", repositorio.RetornaPorId(entradaId).RetornaTitulo());

            // Entradas do usuário
            Console.Write("1) Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("2) Escolha o gênero do filme dentre as opções acima: ");
            int entradaGenero  = int.Parse(Console.ReadLine());

            Console.Write("3) Digite o ano de publicação do filme: ");
            int entradaAnoPublicacao  = int.Parse(Console.ReadLine());

            Console.Write("4) Digite o ano da premiação do filme: ");
            int entradaAnoPremiacao  = int.Parse(Console.ReadLine());

            Console.Write("5a) Digite quantas premiações foram recebida pelo filme: ");
            int qtdPremiacoes = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.WriteLine("5b) Escolha a(s) categoria(s) da(s) premiação(ões) recebida(s) pelo filme dentre as opções acima");
            List<int> entradasCategoria  = new List<int>();
            for (int i = 1; i <= qtdPremiacoes; i++)
            {
                Console.Write("     Premio #{0}: ",i);
                entradasCategoria.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            // Criação do novo objeto
            Filme atualizadoFilme = new Filme(id: entradaId,
                                        titulo: entradaTitulo,
                                        genero: (Genero)entradaGenero,
                                        anoPremio: entradaAnoPremiacao,
                                        anoFilme: entradaAnoPublicacao,
                                        premiacao: entradasCategoria.Select(item => (Categoria) item).ToList());

            // Atualização da instância no repositório
            repositorio.Atualiza(entradaId, atualizadoFilme);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("---> Excluir filme");
            Console.WriteLine();

            Console.Write("Digite o ID do filme: ");
            int entradaId = int.Parse(Console.ReadLine());
            Console.WriteLine("... Filme selecionado para exclusão: {0}", repositorio.RetornaPorId(entradaId).RetornaTitulo());
            Console.WriteLine();
            Console.WriteLine("Tem certeza que deseja excluir o filme selecionado?");
            Console.Write("Digete S para confirmar ou N para cancelar: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            if (opcaoUsuario == "S")
            {
                repositorio.Exclui(entradaId);
            }
            
            Console.WriteLine();
        }
    }
}
