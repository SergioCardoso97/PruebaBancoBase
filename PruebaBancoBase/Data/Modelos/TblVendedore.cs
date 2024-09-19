using System;
using System.Collections.Generic;

namespace Data.Modelos;

public partial class TblVendedore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<TblPago> TblPagos { get; } = new List<TblPago>();

    public virtual ICollection<TblProducto> TblProductos { get; } = new List<TblProducto>();
}
