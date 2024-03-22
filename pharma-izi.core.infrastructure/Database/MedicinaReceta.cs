using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class MedicinaReceta
{
    public Guid Id { get; set; }

    public Guid IdReceta { get; set; }

    public Guid IdTipoIva { get; set; }

    public bool RequiereReceta { get; set; }

    public Guid IdPresentacionMedicinaReceta { get; set; }

    public virtual ICollection<DetalleMedicina> DetalleMedicinas { get; set; } = new List<DetalleMedicina>();

    public virtual PresentacionesMedicamento IdPresentacionMedicinaRecetaNavigation { get; set; } = null!;

    public virtual Receta IdRecetaNavigation { get; set; } = null!;

    public virtual TipoIva IdTipoIvaNavigation { get; set; } = null!;
}
