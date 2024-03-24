using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class StockMedicamentoZona
{
    public Guid Id { get; set; }

    public Guid IdZona { get; set; }

    public Guid IdMedicamento { get; set; }

    public bool EnStock { get; set; }

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;

    public virtual ZonaConsultum IdZonaNavigation { get; set; } = null!;
}
