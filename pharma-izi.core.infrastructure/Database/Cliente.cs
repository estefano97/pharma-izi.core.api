using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public virtual ICollection<ClientesRegistro> ClientesRegistros { get; set; } = new List<ClientesRegistro>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
