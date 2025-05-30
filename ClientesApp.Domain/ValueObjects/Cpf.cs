using System;
using System.Text.RegularExpressions;

namespace ClientesApp.Domain.ValueObjects
{
    /// <summary>
    /// Objeto de valor para definição de um tipo 'Cpf'
    /// </summary>
    public sealed class Cpf
    {
        /// <summary>
        /// Propriedade para retornar o valor do CPF
        /// </summary>
        public string Numero { get; }

        /// <summary>
        /// Construtor para instanciar o tipo Cpf
        /// </summary>
        public Cpf(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF não pode ser vazio.");

            var cpfNumeros = Regex.Replace(numero, "[^0-9]", "");

            if (!EhValido(cpfNumeros))
                throw new ArgumentException("CPF inválido.");

            Numero = cpfNumeros;
        }

        private bool EhValido(string cpf)
        {
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            var cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int primeiroDigito = CalcularDigito(cpfArray, 9, 10);
            int segundoDigito = CalcularDigito(cpfArray, 10, 11);

            return cpfArray[9] == primeiroDigito && cpfArray[10] == segundoDigito;
        }

        private int CalcularDigito(int[] cpf, int length, int pesoInicial)
        {
            int soma = 0;
            for (int i = 0; i < length; i++)
                soma += cpf[i] * (pesoInicial - i);

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}