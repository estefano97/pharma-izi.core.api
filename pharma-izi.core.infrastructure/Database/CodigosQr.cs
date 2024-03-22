using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class CodigosQr
{
    public Guid Id { get; set; }

    public string? FechaEscaneo { get; set; }

    public string? Valor { get; set; }

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
