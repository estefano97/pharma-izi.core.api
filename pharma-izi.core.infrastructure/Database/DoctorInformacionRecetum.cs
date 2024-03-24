using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class DoctorInformacionRecetum
{
    public Guid Id { get; set; }

    public string Valor { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public Guid IdDoctor { get; set; }

    public virtual Doctore IdDoctorNavigation { get; set; } = null!;
}
