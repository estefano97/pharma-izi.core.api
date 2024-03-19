using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class Pedido
{
    public Guid Id { get; set; }

    public Guid IdReceta { get; set; }

    public Guid IdEstadoPedido { get; set; }

    public Guid IdPago { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaEntrega { get; set; }

    public virtual EstadoPedido IdEstadoPedidoNavigation { get; set; } = null!;

    public virtual Pago IdPagoNavigation { get; set; } = null!;

    public virtual Receta IdRecetaNavigation { get; set; } = null!;
}
