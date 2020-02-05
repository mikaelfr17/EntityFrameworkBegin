using BLL.Interfaces;
using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteService : IClienteService
    {
        public void Insert(Cliente cliente)
        {
            //Validar
            using (EstacionamentoDbContext db = new EstacionamentoDbContext())
            {
                //Exemplo de pesquisa de clientes que contenham a letra "a" no nome ordenados por cpf
                List<Cliente> clientes = db.Clientes.Where(cli => cli.Nome.Contains("a")).OrderBy(cli=> cli.CPF).ToList();

                //Retorna o valor toral já pago pelo cliente em todas as movimentações do primeiro cliente que tenha a letra "a" no nome
                double valor = clientes[0].Movimentacoes.Sum(soma => soma.ValorTotal);

                //Exemplo de pesquisa de vaga por ID
                //EXTREMAMENTE COMUM
                //O find é mais performático que o FirstOrDefault
                Vaga vaga = db.Vagas.Find(6);

                //Exemplo pesquisar por vagas livres
                List<Vaga> vagas = db.Vagas.Where(vag => vag.VagaLivre).ToList();

                //Exemplo para pesquisar as movimentações da data hoje, apenas para vagas de Helicoptero
                List<Movimentacao> movimentacoes = db.Movimentacoes.Where(m => m.DataEntrada.Date == DateTime.Now.Date && m.Vaga.TipoVaga == Entity.Enums.TipoVeiculo.Helicoptero).ToList();



                Cliente c = new Cliente()
                {
                    Nome = "Danizinho Bernart",
                    Ativo = true,
                    CPF = "901.917.069-49",
                    DataNascimento = DateTime.Now.AddYears(-25)
                };
                Vaga v = new Vaga()
                {
                    EhCoberta = true,
                    EhPreferencial = true,
                    TipoVaga = Entity.Enums.TipoVeiculo.Helicoptero,
                    VagaLivre = true
                };
                Movimentacao mov = new Movimentacao();
                mov.Cor = 0;
                mov.DataEntrada = DateTime.Now;
                mov.Modelo = "VW";
                mov.Vaga = v;
                mov.ValorTotal = v.CalcularPreco();

                db.Movimentacoes.Add(mov);
                db.SaveChanges();
                
                db.Clientes.Add(c);
                db.Vagas.Add(v);
                db.SaveChanges();

                //UPDATE
                //Ao buscar um dado do entity, existe um mecanismo conhecido como TRACKING
                //Este Mecanismo observa as alterações feitas no objeto e, quando o método 
                //SaveChanges é chamado na base, ele efetuará um update de tudo que foi alterado.
                Cliente cli1 = db.Clientes.Find(5);
                c.Nome += "Bernart";
                db.SaveChanges();

                Vaga vagaASerAtualizada = new Vaga();
                vagaASerAtualizada.ID = 3;
                vagaASerAtualizada.EhCoberta = true;
                vagaASerAtualizada.EhPreferencial = true;
                db.Entry<Vaga>(vagaASerAtualizada).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //Delete
                Vaga vagaASerExcluida = new Vaga();
                vagaASerAtualizada.ID = 3;
                db.Entry<Vaga>(vagaASerAtualizada).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }
        }
    }
}
