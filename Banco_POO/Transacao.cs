using System;

namespace Banco_POO
{
    /// <summary>
    /// Classe base para representar uma transação bancária.
    /// </summary>
    public class Transacao
    {
        /// <summary>
        /// Valor da transação.
        /// </summary>
        public decimal Valor { get; }

        /// <summary>
        /// Data e hora da transação.
        /// </summary>
        public DateTime Data { get; }

        /// <summary>
        /// Descrição da transação.
        /// </summary>
        public string Descricao { get; }

        /// <summary>
        /// Construtor da classe Transacao.
        /// </summary>
        /// <param name="valor">Valor da transação.</param>
        /// <param name="data">Data e hora da transação.</param>
        /// <param name="descricao">Descrição da transação.</param>
        public Transacao(decimal valor, DateTime data, string descricao)
        {
            Valor = valor;
            Data = data;
            Descricao = descricao;
        }
    }

    /// <summary>
    /// Classe derivada para representar uma transação de poupança.
    /// </summary>
    public class TransacaoPoupanca : Transacao
    {
        /// <summary>
        /// Construtor da classe TransacaoPoupanca.
        /// </summary>
        /// <param name="valor">Valor da transação.</param>
        /// <param name="data">Data e hora da transação.</param>
        /// <param name="descricao">Descrição da transação.</param>
        public TransacaoPoupanca(decimal valor, DateTime data, string descricao) : base(valor, data, descricao) { }
    }
}
