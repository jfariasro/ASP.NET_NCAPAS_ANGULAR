using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace appWeb.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public DateTime? Fecharegistro { get; set; }
}
