using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class TipoIva
{
    public Guid Id { get; set; }

    public decimal Valor { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

    public virtual ICollection<MedicinaReceta> MedicinaReceta { get; set; } = new List<MedicinaReceta>();
}
