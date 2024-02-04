using System;
using System.Collections.Generic;

namespace Banco_POO
{
    /// <summary>
    /// Classe abstrata que representa uma conta bancária genérica.
    /// </summary>
    abstract class ContaBancaria
    {
        /// <summary>
        /// Obtém o número único da conta.
        /// </summary>
        public Guid Numero { get; }

        /// <summary>
        /// Obtém ou define o nome associado à conta.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Lista que armazena todas as transações realizadas na conta.
        /// </summary>
        protected List<Transacao> listaTransacoes = new List<Transacao>();

        /// <summary>
        /// Obtém o saldo atual da conta, calculado com base nas transações.
        /// </summary>
        public decimal Saldo
        {
            get
            {
                decimal saldo = 0;
                foreach (var transacao in listaTransacoes)
                {
                    saldo += transacao.Valor;
                }
                return saldo;
            }
        }

        /// <summary>
        /// Construtor da classe base da conta bancária.
        /// </summary>
        /// <param name="nome">Nome associado à conta.</param>
        /// <param name="valor">Valor inicial da conta.</param>
        public ContaBancaria(string nome, decimal valor)
        {
            Numero = Guid.NewGuid();
            Nome = nome;
            Depositar(valor, DateTime.Now, "Saldo Inicial");
        }

        /// <summary>
        /// Realiza um depósito na conta.
        /// </summary>
        /// <param name="valor">Valor a ser depositado.</param>
        /// <param name="data">Data do depósito.</param>
        /// <param name="obs">Observação associada ao depósito.</param>
        public void Depositar(decimal valor, DateTime data, string obs)
        {
            RealizarOperacao(valor, data, obs);
        }

        /// <summary>
        /// Realiza uma operação genérica na conta (pode ser depósito ou saque).
        /// </summary>
        /// <param name="valor">Valor da operação (positivo para depósito, negativo para saque).</param>
        /// <param name="data">Data da operação.</param>
        /// <param name="obs">Observação associada à operação.</param>
        public void RealizarOperacao(decimal valor, DateTime data, string obs)
        {
            Transacao transacao = CriarTransacao(valor, data, obs);
            AdicionarTransacao(transacao);
        }

        /// <summary>
        /// Método abstrato para criar uma transação específica dependendo do tipo de conta.
        /// </summary>
        /// <param name="valor">Valor da transação.</param>
        /// <param name="data">Data da transação.</param>
        /// <param name="obs">Observação associada à transação.</param>
        /// <returns>Uma instância de Transacao.</returns>
        protected abstract Transacao CriarTransacao(decimal valor, DateTime data, string obs);

        /// <summary>
        /// Adiciona uma transação à lista de transações.
        /// </summary>
        /// <param name="transacao">Transação a ser adicionada.</param>
        private void AdicionarTransacao(Transacao transacao)
        {
            listaTransacoes.Add(transacao);
        }

        /// <summary>
        /// Obtém o histórico completo de transações na conta.
        /// </summary>
        public IEnumerable<Transacao> HistoricoTransacoes => listaTransacoes.AsReadOnly();
    }

    /// <summary>
    /// Classe que representa uma conta corrente, derivada da classe ContaBancaria.
    /// </summary>
    class ContaCorrente : ContaBancaria
    {
        /// <summary>
        /// Construtor da classe ContaCorrente.
        /// </summary>
        /// <param name="nome">Nome associado à conta corrente.</param>
        /// <param name="valor">Valor inicial da conta corrente.</param>
        public ContaCorrente(string nome, decimal valor) : base(nome, valor) { }

        /// <summary>
        /// Implementação específica para criar uma transação de conta corrente.
        /// </summary>
        /// <param name="valor">Valor da transação.</param>
        /// <param name="data">Data da transação.</param>
        /// <param name="obs">Observação associada à transação.</param>
        /// <returns>Uma instância de Transacao.</returns>
        protected override Transacao CriarTransacao(decimal valor, DateTime data, string obs)
        {
            return new Transacao(valor, data, obs);
        }
    }

    /// <summary>
    /// Classe que representa uma conta poupança, derivada da classe ContaBancaria.
    /// </summary>
    class ContaPoupanca : ContaBancaria
    {
        /// <summary>
        /// Construtor da classe ContaPoupanca.
        /// </summary>
        /// <param name="nome">Nome associado à conta poupança.</param>
        /// <param name="valor">Valor inicial da conta poupança.</param>
        public ContaPoupanca(string nome, decimal valor) : base(nome, valor) { }

        /// <summary>
        /// Implementação específica para criar uma transação de conta poupança.
        /// </summary>
        /// <param name="valor">Valor da transação.</param>
        /// <param name="data">Data da transação.</param>
        /// <param name="obs">Observação associada à transação.</param>
        /// <returns>Uma instância de TransacaoPoupanca.</returns>
        protected override Transacao CriarTransacao(decimal valor, DateTime data, string obs)
        {
            return new TransacaoPoupanca(valor, data, obs);
        }
    }
}
