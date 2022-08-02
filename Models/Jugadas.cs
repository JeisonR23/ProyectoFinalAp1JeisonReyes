
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Jugadas
{

    [Key]
    public int JugadaId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;

    public double Monto { get; set; }

    [Required(ErrorMessage = "Favor Selecionar una Loteria")]
    public int LoteriaId { get; set; }

    [Required(ErrorMessage = "Favor Selecionar un tipo de jugada")]

    public int TipoJugadaId { get; set; }

    public string NombreLoteria { get; set; }

    public string Nombre { get; set; }

    public double MontoGanancia { get; set; }

    [ForeignKey("JugadaId")]
    public List<JugadaDetalle> Detalle { get; set; } = new List<JugadaDetalle>();

}

