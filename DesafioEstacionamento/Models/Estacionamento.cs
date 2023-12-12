using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial;
        private readonly decimal precoPorHora;
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
                if (PlacaExisteNoEstacionamento(placa)) throw new ArgumentException($"Já existe um veículo com a placa {placa} no estacionamento.");
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

        public void RemoverVeiculo(string placa)
        {
            try
            {
                if (!PlacaExisteNoEstacionamento(placa)) throw new ArgumentException($"Não existe nenhum veículo com a placa {placa} no estacionamento.");

                Veiculo veiculoARemover = veiculos.First(veiculo => veiculo.ObterPlaca().Equals(placa));
                Console.WriteLine("Removendo o veículo: " + veiculoARemover);
                veiculos.Remove(veiculoARemover);
                Console.WriteLine($"Veículo removido!\nTotal a pagar: {(precoInicial + precoPorHora).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-br"))}");
            } catch (ArgumentException e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine(e.Message);
            } catch (Exception e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
                veiculos.ForEach(veiculo => Console.WriteLine($"{veiculos.IndexOf(veiculo) + 1} - {veiculo})"));
            else
                Console.WriteLine("O estacionamento está vazio!");
        }

        private bool PlacaExisteNoEstacionamento(string placa)
        {
            return veiculos.Aggregate(false, (acc, veiculo) => 
            {
                if (veiculo.ObterPlaca().Equals(placa))
                    acc = true;
                return acc;
            });
        }
    }
}