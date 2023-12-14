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

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            if (EstacionamentoEstaVazio()) return;

            Console.WriteLine("Selecione o veículo que deseja remover do estacionamento, indicando o seu índice: ");

            try
            {
                int indice = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Removendo o veículo: " + veiculos[indice]);
                veiculos.RemoveAt(indice);
                Console.WriteLine($"Veículo removido!\nTotal a pagar: {(precoInicial + precoPorHora).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-br"))}");
            } 
            catch (FormatException e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("O índice precisa ser um número.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("O índice digitado não corresponde a nenhum veículo.");
            } 
            catch (Exception e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
            }
        }

        public void ListarVeiculos()
        {
            if (EstacionamentoEstaVazio())
                Console.WriteLine("O estacionamento está vazio!");
            else
            {
                Console.WriteLine("Veículos estacionados: ");
                veiculos.ForEach(veiculo => Console.WriteLine($"{veiculos.IndexOf(veiculo) + 1} - {veiculo}"));
            }
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

        private bool EstacionamentoEstaVazio()
        {
            return !veiculos.Any();
        }
    }
}