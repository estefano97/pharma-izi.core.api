using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class CategoriaMedicamento
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoMedicamento { get; set; } = null!;

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
