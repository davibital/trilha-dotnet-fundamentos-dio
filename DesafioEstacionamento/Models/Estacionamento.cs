using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;    
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Informe o modelo do veículo: ");
            string modelo = Console.ReadLine();
            Console.WriteLine("Informe a cor do veículo: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Informe a placa do veículo: ");
            string placa = Console.ReadLine();

            try
            {
                veiculos.Add(new Veiculo(placa, modelo, cor));
            } 
            catch (ArgumentException e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
            }
        }

        public void RemoverVeiculo()
        {

        }

        public void ListarVeiculos()
        {
            
        }
    }
}