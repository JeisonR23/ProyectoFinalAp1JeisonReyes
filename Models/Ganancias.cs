using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ganancias
{
    [Key]
    public int GananciaId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    public double montoJugado { get; set; }

    public double Totalganancias { get; set; }


    [ForeignKey("GananciaId")]
    public List<GananciaDetalle> Detalle { get; set; } = new List<GananciaDetalle>();
}
