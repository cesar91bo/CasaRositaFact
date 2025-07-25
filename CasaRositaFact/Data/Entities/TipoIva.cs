﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CasaRositaFact.Data.Entities
{
    public class TipoIva
    {
        [Key]
        public int IdTipoIva { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [Precision(18, 2)]
        public decimal Porcentaje { get; set; } = 0.0m;
        public ICollection<PrecioArticulo> PreciosArticulos { get; set; } = new List<PrecioArticulo>();
    }
}
