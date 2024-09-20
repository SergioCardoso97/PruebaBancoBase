using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Modelos;

public partial class TblPago
{
    public int Id { get; set; }

    public int IdTblCliente { get; set; }

    public int IdTblVendedores { get; set; }

    public int IdTblOrdenes { get; set; }

    public int IdCatEstatus { get; set; }

    public string Concepto { get; set; } = null!;

    public int CantidadProductos { get; set; }

    public double MontoTotal { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual CatEstatusPago IdCatEstatusNavigation { get; set; } = null!;
    public virtual TblCliente IdTblClienteNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual TblOrdene IdTblOrdenesNavigation { get; set; } = null!;
    public virtual TblVendedore IdTblVendedoresNavigation { get; set; } = null!;
}
