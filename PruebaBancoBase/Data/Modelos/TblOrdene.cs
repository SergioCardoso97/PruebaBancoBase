using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Modelos;

public partial class TblOrdene
{
    public int Id { get; set; }

    public int IdTblCliente { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual TblCliente IdTblClienteNavigation { get; set; } = null!;

    public virtual ICollection<RelOrdenesProducto> RelOrdenesProductos { get; } = new List<RelOrdenesProducto>();
    [JsonIgnore]

    public virtual ICollection<TblPago> TblPagos { get; } = new List<TblPago>();
}
