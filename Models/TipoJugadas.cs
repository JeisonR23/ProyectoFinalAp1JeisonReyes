
using System.ComponentModel.DataAnnotations;

public class TipoJugada
{
    [Key]
    public int TipoJugadaId { get; set; }
    public int LoteriaId { get; set; }
    
    [Required(ErrorMessage = "Favor Selecionar un tipo de jugada")]
    public string NombreJugada { get; set; }
}