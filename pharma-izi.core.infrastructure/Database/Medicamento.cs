using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Medicamento
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public Guid IdCategoriaMedicamento { get; set; }

    public decimal Valor { get; set; }

    public bool EnStock { get; set; }

    public Guid IdTipoIva { get; set; }

    public string FotoMedicamento { get; set; } = null!;

    public bool RequiereReceta { get; set; }

    public Guid IdMarcaMedicamento { get; set; }

    public virtual CategoriaMedicamento IdCategoriaMedicamentoNavigation { get; set; } = null!;

    public virtual MarcaMedicamento IdMarcaMedicamentoNavigation { get; set; } = null!;

    public virtual TipoIva IdTipoIvaNavigation { get; set; } = null!;

    public virtual ICollection<MedicinaReceta> MedicinaReceta { get; set; } = new List<MedicinaReceta>();
}
