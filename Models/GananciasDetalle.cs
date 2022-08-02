
using System.ComponentModel.DataAnnotations;


public class GananciaDetalle
{
    [Key]
    public int GananciaDetalleId { get; set; }

    public int GananciaId { get; set; }

    public int JugadaId { get; set; }

    public int LoteriaId { get; set; }

    public int TipoJugadaId { get; set; }

    public string NombreLoteria { get; set; }

    public string Nombre { get; set; }

    public double Montojugado { get; set; }

    public double MontoGanancia { get; set; }

}