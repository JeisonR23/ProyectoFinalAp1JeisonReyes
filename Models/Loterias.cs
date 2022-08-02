
using System.ComponentModel.DataAnnotations;

public class Loterias
{
    [Key]
    public int LoteriaId { get; set; }

    [Required(ErrorMessage = "Favor Selecionar una loteria")]
    public string Nombre { get; set; }

}