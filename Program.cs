using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario;

            opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
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

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            string opcaoUsuario;
            
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries;");
            Console.WriteLine("2 - Inserir nova série;");
            Console.WriteLine("3 - Atualizar série;");
            Console.WriteLine("4 - Excluir série;");
            Console.WriteLine("5 - Visualizar séries;");
            Console.WriteLine("C - Limpar tela;");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            Console.Write("Opção: ");
            opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("[ Listar séries ]");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                if (!excluido)
                {
                    Console.WriteLine($"#ID {serie.retornaId()}: {serie.retornaTitulo()}");
                }
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine(" [ Inserir nova série ]");

            EntradasSeries entradas = new EntradasSeries();
            entradas.coletarDados();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradas.RetornaGenero(),
                                          titulo: entradas.RetornaTitulo(),
                                          ano: entradas.RetornaAno(),
                                          descricao: entradas.RetornaDescricao());
            
            repositorio.Insere(novaSerie);
        }
    
        private static void AtualizarSerie()
        {
            int indiceSerie;
            
            Console.WriteLine("[ Atualizar séries ]");

            Console.Write("Digite o id da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            EntradasSeries entradas = new EntradasSeries();
            entradas.coletarDados();

            Series atualizaSerie = new Series(id: indiceSerie,
                                              genero: (Genero)entradas.RetornaGenero(),
                                              titulo: entradas.RetornaTitulo(),
                                              descricao: entradas.RetornaDescricao(),
                                              ano: entradas.RetornaAno());
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
    
        private static void ExcluirSerie()
        {
            int indiceSerie;
            string respUsuario;

            Console.WriteLine(" [ Excluir série ] ");

            Console.Write("Digite o id da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            Console.Write("Deseja, realmente, excluir essa série? (S/N) ");
            respUsuario = Console.ReadLine().ToUpper();

            if (respUsuario.Equals("N"))
            {
                return;
            }

            Console.WriteLine($"Série com id {indiceSerie} excluída com sucesso!");

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            int indiceSerie;

            Console.WriteLine(" [ Visualizar série ] ");

            Console.Write("Digite o id da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

    }
}
