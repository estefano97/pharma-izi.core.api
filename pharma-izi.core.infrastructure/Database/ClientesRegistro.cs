using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class ClientesRegistro
{
    public Guid Id { get; set; }

    public string Password { get; set; } = null!;

    public Guid IdCliente { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool AceptoTerminosCondiciones { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
