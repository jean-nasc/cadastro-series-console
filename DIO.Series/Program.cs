using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("\nObrigado por utilizar nossos serviços!\n");
            Console.ReadKey();
        }

        private static int ListarSeries()
        {
            Console.WriteLine("\n--- Lista de Séries ---\n");

            var lista = repositorio.Listar();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não há séries para exibir!");
                return 0;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaNome(), serie.retornaStatus() ? "*Ativo*" : "*Inativo*");
            }

            return lista.Count;
        }

        private static void InserirSerie()
        {
            Console.WriteLine("\n--- Inserir Série ---\n");

            var serie = DadosCadastrais(0, true);

            repositorio.Inserir(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("\n--- Atualizar Série ---");

            if(ListarSeries() == 0) return;

            Console.WriteLine("\nInforme o ID da série que deseja atualizar:");
            Console.Write("\nSua opção: ");
            int opcaoUsuario = int.Parse(Console.ReadLine());

            var serie = DadosCadastrais(opcaoUsuario);

            repositorio.Atualizar(opcaoUsuario, serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("\n--- Excluir Série ---");

            if(ListarSeries() == 0) return;

            Console.WriteLine("\nInforme o ID da série que deseja excluir:");
            Console.Write("\nSua opção: ");
            int opcaoUsuario = int.Parse(Console.ReadLine());

            repositorio.Excluir(opcaoUsuario);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("\n--- Visualizar Série ---");

            if(ListarSeries() == 0) return;

            Console.WriteLine("\nInforme o ID da série que deseja visualizar:");
            Console.Write("\nSua opção: ");
            int opcaoUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.ListarPorId(opcaoUsuario).ToString());
        }

        private static Serie DadosCadastrais(int id = 0, bool cadastro = false)
        {
            Console.WriteLine("--- Escolha a Categoria ---");

            foreach(int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("\nSua opção: ");
            int categoria = int.Parse(Console.ReadLine());
            var cat = (Categoria)categoria;

            Console.Write("\nNome: ");
            string nome = Console.ReadLine();

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Serie serie = new Serie
            (
                cadastro ? repositorio.proximoId() : id,
                nome,
                cat,
                ano,
                descricao
            );

            return serie;
        }

        public static string obterOpcaoUsuario()
        {
            Console.WriteLine("\n--- Informe a opção desejada: ---");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair\n");

            Console.Write("Sua opção: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }
    }
}
