using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
