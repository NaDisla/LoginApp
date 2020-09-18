using System;
using System.Collections.Generic;

namespace LoginAPI.Models
{
    public partial class TareasClientes
    {
        public int TarCliId { get; set; }
        public int CliId { get; set; }
        public string TarCliNombre { get; set; }
        public string TarCliDescripcion { get; set; }
        public DateTime TarCliFechaCreacion { get; set; }
        public string TarCliEstatus { get; set; }

        public virtual Clientes Cli { get; set; }
    }
}
