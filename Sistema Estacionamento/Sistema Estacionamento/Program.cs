using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            string modelo, placa;

            Console.WriteLine("Bem vindo ao estacionamento, digite a opção para começar:");
            Carro carro = new Carro();

            do
            {
                Console.WriteLine("1- Estacionar\n2-Retirar\n3-Procurar carro\n4-Listar carros\n5-Sair");
                opcao = int.Parse(Console.ReadLine());

                Estacionamento estacionamento = new Estacionamento();

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o modelo do veículo:");
                        carro.Modelo = Console.ReadLine();

                        Console.WriteLine("Informe a placa do veículo:");
                        carro.Placa = Console.ReadLine();


                        estacionamento.EstacionarCarro(carro);

                        Console.WriteLine("Carro estacionado");

                        break;

                    case 2:
                        Console.WriteLine("Informe a placa do carro:");
                        placa = Console.ReadLine();

                        estacionamento.RemoverCarro(carro, placa);

                        Console.WriteLine("Carro removido");

                        break;

                    case 3:

                        Console.WriteLine("Informe a placa do carro:");
                        placa = Console.ReadLine();

                        estacionamento.ProcurarCarro(carro, placa);
                        break;

                    case 4:

                        estacionamento.ListarVeiculos();
                        break;
                }
            } while (opcao != 5);
        }
    }

    class Estacionamento
    {
        private List<Carro> estacionados = new List<Carro>();
        private double tempoEstacionado;

        public void EstacionarCarro(Carro carro)
        {
            estacionados.Add(carro);
        }

        public void RemoverCarro(Carro carro, string placa)
        {
            if (carro.Placa == placa)
            {
                estacionados.Remove(carro);
            }
            else
            {
                Console.WriteLine("Placa não encontrada");
            }
               

        }

        public string ProcurarCarro(Carro carro, string placa)
        {
            if(carro.Placa == placa && estacionados.Contains(carro))
            {
                return "Carro encontrado";
            }

            return "Não encontrado";
        }

        public void ListarVeiculos()
        {
            foreach (var item in estacionados)
            {
                Console.WriteLine($"Carro: {item.Modelo} | Placa: {item.Placa}");
            }
        }
    }

    class Carro
    {
        private string placa;
        private string modelo;

        public string Placa
        {
            set { placa = value; }
            get { return placa; }
        }

        public string Modelo
        {
            set { modelo = value; }
            get { return modelo; }
        }

        public Carro()
        {

        }

        public Carro(string placa, string modelo)
        {
            this.placa = placa;
            this.modelo = modelo;
        }
    }
}
