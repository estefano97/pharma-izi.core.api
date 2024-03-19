using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class DetalleMedicina
{
    public Guid Id { get; set; }

    public Guid IdMedicinaReceta { get; set; }

    public string? Descripcion { get; set; }

    public virtual MedicinaReceta IdMedicinaRecetaNavigation { get; set; } = null!;
}
