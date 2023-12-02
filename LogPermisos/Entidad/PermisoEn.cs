using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPermisos.Entidad
{
    class PermisoEn
    {
        public int IdPermiso { get; set; }
        public int RolUsuarioId { get; set; }
        public int OpcionId { get; set; }
        public bool Permitido { get; set; }
    }
}
