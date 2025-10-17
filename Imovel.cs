using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProprietarioFicha;

namespace ImovelFicha
{
    public abstract class Imovel
    {
        protected string endereco;
        protected int numero;
        protected bool alugado;
        public Proprietario proprietario;

        public Imovel(string endereco, int numero, Proprietario proprietario)
        {
            this.endereco = endereco;
            this.numero = numero;
            this.alugado = false;
            this.proprietario = proprietario;
        }

        public string GetEndereco() => endereco;
        public void SetEndereco(string novoEndereco) => endereco = novoEndereco;

        public int GetNumero() => numero;
        public void SetNumero(int novoNumero) => numero = novoNumero;

        public bool GetAlugado() => alugado;
        public void SetAlugado(bool status) => alugado = status;

        public string ContatoProprietario()
        {
            return $"Proprietário: {proprietario.Nome} | Tel: {proprietario.Telefone} | CPF: {proprietario.CPF}";
        }

        public int CalcularAluguel(int valorDiario, int dias)
        {
            return valorDiario * dias;
        }

        public abstract string EstaAlugado();

    }
}