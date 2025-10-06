using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models.Requests;

public record TodoRequest(
    [Required(ErrorMessage = "É necessário adicionar um título para a tarefa.")]
    string Title, 
    [Required(ErrorMessage = "É necessário dizer se a tarefa foi concluída.")]
    bool Done
);