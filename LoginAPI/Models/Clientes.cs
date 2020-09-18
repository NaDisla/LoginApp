using System;
using System.Collections.Generic;

namespace LoginAPI.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            TareasClientes = new HashSet<TareasClientes>();
        }

        public int CliId { get; set; }
        public int? UsuId { get; set; }
        public string CliNombres { get; set; }
        public string CliApellidos { get; set; }
        public string CliTelFijo { get; set; }
        public string CliCelular { get; set; }
        public string CliDireccion { get; set; }
        public string CliCorreo { get; set; }
        public string CliGenero { get; set; }
        public string CliEstatus { get; set; }

        public virtual Usuarios Usu { get; set; }
        public virtual ICollection<TareasClientes> TareasClientes { get; set; }
    }
}
