using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class MovimentacaoMapConfig:EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoMapConfig()
        {
            this.ToTable("MOVIMENTACOES");
            this.Property(c => c.Placa).HasMaxLength(7);
            this.Property(c => c.Modelo).HasMaxLength(40);
        }
    }
}
