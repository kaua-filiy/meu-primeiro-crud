using System.ComponentModel.DataAnnotations;
using TwTodos.Validators;

namespace TwTodos.Models;

public class Todo{
public int Id { get; set; }

[Display(Name="Titulo")]
[Required(ErrorMessage = "Campo {0} Obrigatorio")]
[StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
public string Title { get; set; } = string.Empty;
public DateTime CreatedAt { get; set; } = DateTime.Now;

[Display(Name = "Data de Entrega")]
[Required(ErrorMessage = "Campo {0} Obrigatorio")]
[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
[FutureOrPresent]
public DateOnly Deadline { get; set; }
public DateOnly? FinisheadAt{ get; set; }
}