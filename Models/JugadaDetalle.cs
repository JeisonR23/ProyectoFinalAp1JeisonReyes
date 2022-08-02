
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class JugadaDetalle
{
    [Key]
    public int JugadaDetalleId { get; set; }

    public int JugadaId { get; set; }

    public int GananciaId { get; set; }

    public int LoteriaId { get; set; }

    public int TipoJugadaId { get; set; }

    public string NombreLoteria { get; set; }

    public string Nombre { get; set; }

    public double Monto { get; set; }

    public double MontoGanancia { get; set; }

    public Ganancias ganancia {get; set;}

}