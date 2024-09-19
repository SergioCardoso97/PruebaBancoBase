using System;
using System.Collections.Generic;

namespace Data.Modelos;

public partial class RelOrdenesProducto
{
    public int Id { get; set; }

    public int IdTblProductos { get; set; }

    public int IdTblOrdenes { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual TblOrdene IdTblOrdenesNavigation { get; set; } = null!;

    public virtual TblProducto IdTblProductosNavigation { get; set; } = null!;
}
