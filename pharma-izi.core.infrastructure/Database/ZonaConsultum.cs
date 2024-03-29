﻿using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class ZonaConsultum
{
    public Guid Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<StockMedicamentoZona> StockMedicamentoZonas { get; set; } = new List<StockMedicamentoZona>();
}
