﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Modelos;

public partial class TblProducto
{
    public int Id { get; set; }

    public int IdTblVendedor { get; set; }

    public string Producto { get; set; } = null!;

    public double Precio { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual TblVendedore IdTblVendedorNavigation { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<RelOrdenesProducto> RelOrdenesProductos { get; } = new List<RelOrdenesProducto>();
}
