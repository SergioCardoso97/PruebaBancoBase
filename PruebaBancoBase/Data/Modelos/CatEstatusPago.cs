using System;
using System.Collections.Generic;

namespace Data.Modelos;

public partial class CatEstatusPago
{
    public int Id { get; set; }

    public string Estatus { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<TblPago> TblPagos { get; } = new List<TblPago>();
}
