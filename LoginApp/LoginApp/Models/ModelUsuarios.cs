using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.Models
{
    public class ModelUsuarios
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuNombreReal { get; set; }
        public string UsuClave { get; set; }
    }
}
