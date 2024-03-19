using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Pago
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Evidencia { get; set; }

    public Guid IdTipoPago { get; set; }

    public decimal Valor { get; set; }

    public bool Estado { get; set; }

    public virtual TiposPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
