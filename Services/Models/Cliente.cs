using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{

    public class Cliente
    {
        public int Id { get; set; } = 0;

        public DateTimeOffset? Created_at { get; set; } = DateTimeOffset.Now;

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Dni { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int LocalidadId { get; set; } = 0;
        public Localidad? Localidad { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
