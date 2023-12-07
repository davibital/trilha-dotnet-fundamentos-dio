using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Veiculo
    {
        private string placa;
        private string modelo;
        private string cor;

        public Veiculo(string placa, string modelo, string cor)
        {
            if (placaValida(placa))
            {
                this.placa = placa;
                this.modelo = modelo;
                this.cor = cor;
            }
            else
            {
                throw new ArgumentException($"A placa do carro é inválida: {placa}\nDeve ser seguido o padrão de Placa Mercosul. Exemplo: ABC-1D23");
            } 
        }

        private bool placaValida(string placa)
        {
            string padraoPlaca = @"^[A-Z]{3}-\d{1}[A-Z]{1}\d{2}$";

            return Regex.IsMatch(placa, padraoPlaca);
        }

        public override string ToString()
        {
            return $"Placa: {placa}\nModelo: {modelo}\nCor: {cor}";
        }
    }
}