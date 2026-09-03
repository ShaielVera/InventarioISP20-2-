using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    [Table("clientes")]
    public class Cliente: BaseModel
    {
        [PrimaryKey("id",false)]
        public int? id { get; set; }

        [Column("created_at")]
        public DateTime? created_at { get; set; } = DateTime.Now;

        [Column("firstname")]
        public string firstname { get; set; }

        [Column("lastname")]
        public string lastname { get; set; }

        [Column("dni")]
        public string dni { get; set; }

        [Column("address")]
        public string address { get; set; }
    }
}
