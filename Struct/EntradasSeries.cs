using System;

namespace DIO.Series
{
    public struct EntradasSeries
    {
        private int EntradaGenero { get; set; }
        private string EntradaTitulo { get; set; }
        private int EntradaAno { get; set; }
        private string EntradaDescricao { get; set; }

        public void coletarDados()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            EntradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            EntradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            EntradaDescricao = Console.ReadLine();
        }

        public int RetornaGenero()
        {
            return this.EntradaGenero;
        }

        public string RetornaTitulo()
        {
            return this.EntradaTitulo;
        }

        public int RetornaAno()
        {
            return this.EntradaAno;
        }

        public string RetornaDescricao()
        {
            return this.EntradaDescricao;
        }
    }
}