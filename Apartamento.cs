using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImovelFicha;
using ProprietarioFicha;

namespace ApartamentoFicha
{
    public class Apartamento : Imovel
    {
        public Apartamento(string endereco, int numero, Proprietario proprietario)
            : base(endereco, numero, proprietario)
        {
        }

        public override string EstaAlugado()
        {
            return alugado 
                ? $"O apartamento de número {numero} está alugado." 
                : $"O apartamento de número {numero} está disponível.";
        }       
    }
}