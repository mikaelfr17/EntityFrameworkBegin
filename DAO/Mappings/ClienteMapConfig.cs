using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class ClienteMapConfig: EntityTypeConfiguration<Cliente>
    {
        public ClienteMapConfig()
        {
            //DEFINE NOME DA TABELA DA ENTIDADE DESCRITA ACIMA 
            this.ToTable("CLIENTES");
            //CONFIGURA A PROPRIEDADE NOME A SER VARCHAR(50) NOT NULL
            this.Property(c => c.Nome).HasMaxLength(50);
            this.Property(c => c.CPF).IsFixedLength().HasMaxLength(14);
            this.Property(c => c.DataNascimento).HasColumnName("date");
        }
    }
}
