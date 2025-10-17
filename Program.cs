using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImovelFicha;
using ProprietarioFicha;
using CasaFicha;
using ApartamentoFicha;

namespace CorretoraImobiliaria
{
    class Program
    {
        static List<Imovel> imoveis = new List<Imovel>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== CORRETORA IMOBILIÁRIA ===");
                Console.WriteLine("1 - Cadastrar Casa");
                Console.WriteLine("2 - Cadastrar Apartamento");
                Console.WriteLine("3 - Listar Imóveis");
                Console.WriteLine("4 - Alugar / Disponibilizar imóvel");
                Console.WriteLine("5 - Calcular Aluguel");
                Console.WriteLine("6 - Deletar imóvel");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1": CadastrarImovel("casa"); break;
                    case "2": CadastrarImovel("apartamento"); break;
                    case "3": ListarImoveis(); break;
                    case "4": AlugarOuLiberar(); break;
                    case "5": CalcularValor(); break;
                    case "6": DeletarImovel(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
        }

        static void CadastrarImovel(string tipo)
        {
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine()!;

            Console.Write("Número: ");
            int numero = int.Parse(Console.ReadLine()!);

            Console.Write("Nome do proprietário: ");
            string nome = Console.ReadLine()!;

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine()!;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;

            Proprietario p = new Proprietario(nome, telefone, cpf);

            Imovel imovel = tipo == "casa"
                ? new Casa(endereco, numero, p)
                : new Apartamento(endereco, numero, p);

            imoveis.Add(imovel);
            Console.WriteLine($"{tipo} cadastrada com sucesso!");
        }

        static void ListarImoveis()
        {
            if (imoveis.Count == 0)
            {
                Console.WriteLine("Nenhum imóvel cadastrado.");
                return;
            }

            for (int i = 0; i < imoveis.Count; i++)
            {
                var im = imoveis[i];
                Console.WriteLine($"\n[{i + 1}] {im.GetType().Name} - {im.GetEndereco()}, {im.GetNumero()}");
                Console.WriteLine(im.EstaAlugado());
                Console.WriteLine(im.ContatoProprietario());
            }
        }

        static void AlugarOuLiberar()
        {
            ListarImoveis();
            Console.Write("\nEscolha o ID do imóvel: ");
            int imList = int.Parse(Console.ReadLine()!) - 1;

            if (imList < 0 || imList >= imoveis.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            var im = imoveis[imList];
            im.SetAlugado(!im.GetAlugado());
            Console.WriteLine(im.EstaAlugado());
        }

        static void CalcularValor()
        {
            Console.Write("Valor diário do aluguel: ");
            int valor = int.Parse(Console.ReadLine()!);

            Console.Write("Quantidade de dias: ");
            int dias = int.Parse(Console.ReadLine()!);

            int total = valor * dias;
            Console.WriteLine($"Valor total: R$ {total}");
        }

        static void DeletarImovel()
        {
            ListarImoveis();
            Console.Write("\nEscolha o ID do imóvel para deletar: ");
            int imDisp = int.Parse(Console.ReadLine()!) - 1;

            if (imDisp < 0 || imDisp >= imoveis.Count)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            imoveis.RemoveAt(imDisp);
            Console.WriteLine("Imóvel removido com sucesso!");
        }
    }
}
