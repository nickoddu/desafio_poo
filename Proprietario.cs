using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProprietarioFicha
{
    public class Proprietario
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Proprietario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }
    }
}
