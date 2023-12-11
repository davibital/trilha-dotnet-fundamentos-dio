using DesafioEstacionamento.Models;

decimal precoInicial;
decimal precoPorHora;

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento");

Console.WriteLine("Digite o preço inicial: ");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Digite o preço por hora: ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

bool sistemaEmExecucao = true;

while (sistemaEmExecucao)
{
  Console.Clear();
  Console.WriteLine("Digite a sua opção: ");
  Console.WriteLine("1 - Cadastrar veículo");
  Console.WriteLine("2 - Remover veículo");
  Console.WriteLine("3 - Listar veículos");
  Console.WriteLine("4 - Encerrar");

  switch (Console.ReadLine())
  {
    case "1":
      estacionamento.AdicionarVeiculo();
      break;
    case "2":
      estacionamento.RemoverVeiculo();
      break;
    case "3":
      estacionamento.ListarVeiculos();
      break;
    case "4":
      sistemaEmExecucao = false;
      Console.WriteLine("Sistema encerrando...");
      break;
    default:
      Console.WriteLine("Opção inválida!");
      break;
  }

  Console.WriteLine("Pressione uma tecla para continuar.");
  Console.ReadLine();
}