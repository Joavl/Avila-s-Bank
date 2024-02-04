using System;

namespace Banco_POO
{
    /// <summary>
    /// Classe principal que contém a lógica do programa para interagir com uma conta bancária.
    /// </summary>
    class Program
    {
        // Conta bancária usada no programa
        static ContaBancaria conta;

        /// <summary>
        /// Método principal que inicia o programa.
        /// </summary>
        /// <param name="args">Argumentos da linha de comando (não utilizados neste programa).</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Avila'S Bank!");

            // Solicita o nome do usuário
            Console.Write("Digite seu nome: ");
            string nomeUsuario = Console.ReadLine();

            // Cria uma conta corrente com um saldo inicial de 10000
            conta = new ContaCorrente(nomeUsuario, 10000);

            // Exibe o menu principal
            ExibirMenu();
        }

        /// <summary>
        /// Exibe o menu principal e direciona para as opções escolhidas pelo usuário.
        /// </summary>
        static void ExibirMenu()
        {
            Console.WriteLine($"\nBem-vindo, {conta.Nome}!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Sacar");
            Console.WriteLine("3. Visualizar Saldo e Histórico");
            Console.WriteLine("4. Sair");

            // Lê a opção escolhida pelo usuário
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                // Executa a ação correspondente à opção escolhida
                RealizarAcao(opcao);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            // Volta para o menu principal
            ExibirMenu();
        }

        /// <summary>
        /// Executa a ação correspondente à opção escolhida pelo usuário.
        /// </summary>
        /// <param name="opcao">Opção escolhida pelo usuário.</param>
        static void RealizarAcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    RealizarDeposito();
                    break;
                case 2:
                    RealizarSaque();
                    break;
                case 3:
                    VisualizarSaldoEHistorico();
                    break;
                case 4:
                    Console.WriteLine("Obrigado por usar o Avila'S Bank. Até logo!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        /// <summary>
        /// Realiza um depósito na conta bancária.
        /// </summary>
        static void RealizarDeposito()
        {
            Console.Write("Digite o valor para depositar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.Write("Digite uma observação para o depósito: ");
                string obs = Console.ReadLine();

                // Executa o depósito na conta
                conta.Depositar(valor, DateTime.Now, obs);
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        /// <summary>
        /// Realiza um saque na conta bancária.
        /// </summary>
        static void RealizarSaque()
        {
            Console.Write("Digite o valor para sacar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.Write("Digite uma observação para o saque: ");
                string obs = Console.ReadLine();

                try
                {
                    // Tenta realizar a operação de saque na conta
                    conta.RealizarOperacao(-valor, DateTime.Now, obs);
                    Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao sacar: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        /// <summary>
        /// Exibe o saldo atual e o histórico de transações da conta bancária.
        /// </summary>
        static void VisualizarSaldoEHistorico()
        {
            Console.WriteLine($"Saldo atual: {conta.Saldo:C}");
            Console.WriteLine("\nHistórico de Transações:");

            // Exibe todas as transações no histórico da conta
            foreach (var transacao in conta.HistoricoTransacoes)
            {
                Console.WriteLine($"{transacao.Data} - {transacao.Descricao}: {transacao.Valor:C}");
            }
        }
    }
}
