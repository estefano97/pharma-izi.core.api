using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Receta
{
    public Guid Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public Guid IdDoctor { get; set; }

    public Guid IdCliente { get; set; }

    public DateTime FechaRegistro { get; set; }

    public Guid IdCodigoQr { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual CodigosQr IdCodigoQrNavigation { get; set; } = null!;

    public virtual Doctore IdDoctorNavigation { get; set; } = null!;

    public virtual ICollection<MedicinaReceta> MedicinaReceta { get; set; } = new List<MedicinaReceta>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
