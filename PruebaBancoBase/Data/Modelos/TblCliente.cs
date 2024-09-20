using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Modelos;

public partial class TblCliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }
    [JsonIgnore]

    public virtual ICollection<TblOrdene> TblOrdenes { get; } = new List<TblOrdene>();
    [JsonIgnore]

    public virtual ICollection<TblPago> TblPagos { get; } = new List<TblPago>();
}
