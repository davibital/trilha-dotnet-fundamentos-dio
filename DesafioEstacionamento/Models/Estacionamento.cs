using System;
using System.Collections.Generic;
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

        }

        public void RemoverVeiculo()
        {

        }

        public void ListarVeiculos()
        {
            
        }
    }
}