using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImovelFicha;
using ProprietarioFicha;

namespace CasaFicha
{
    public class Casa : Imovel
    {
        public Casa(string endereco, int numero, Proprietario proprietario) : base(endereco, numero, proprietario)
        {
        }

        public override string EstaAlugado()
        {
            return alugado ? "A casa está alugada." : "A casa está disponível.";
        }
    }
}
