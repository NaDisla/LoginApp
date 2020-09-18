using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoginAPI.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int UsuId { get; set; }
        public int RolId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuNombreReal { get; set; }
        public string UsuClave { get; set; }
        [JsonIgnore]
        public virtual Roles Rol { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
