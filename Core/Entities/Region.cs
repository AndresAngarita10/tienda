using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

    public class Region
    {
        public int Id { get; set; }
        public string NombreRegion { get; set; }
        public int IdEstadoFk { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
