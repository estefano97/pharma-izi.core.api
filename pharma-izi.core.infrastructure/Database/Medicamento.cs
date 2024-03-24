using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Medicamento
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public Guid IdCategoriaMedicamento { get; set; }

    public Guid IdTipoIva { get; set; }

    public string FotoMedicamento { get; set; } = null!;

    public bool RequiereReceta { get; set; }

    public Guid IdMarcaMedicamento { get; set; }

    public string? IdFybeca { get; set; }

    public virtual CategoriaMedicamento IdCategoriaMedicamentoNavigation { get; set; } = null!;

    public virtual MarcaMedicamento IdMarcaMedicamentoNavigation { get; set; } = null!;

    public virtual TipoIva IdTipoIvaNavigation { get; set; } = null!;

    public virtual ICollection<PresentacionesMedicamento> PresentacionesMedicamentos { get; set; } = new List<PresentacionesMedicamento>();

    public virtual ICollection<StockMedicamentoZona> StockMedicamentoZonas { get; set; } = new List<StockMedicamentoZona>();
}
