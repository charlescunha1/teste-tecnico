using API_Bank.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace API_Bank.Application.ViewModel;

public class CreateBankAccountViewModel
{
    [StringLength(5, MinimumLength = 1, ErrorMessage = "O número da agência deve ter entre 1 e 5 caracteres.")]
    public string Branch { get; set; } 
    public AccountType Type { get; set; }
    [StringLength(200, MinimumLength = 2, ErrorMessage = "O nome do titular deve ter entre 2 e 200 caracteres.")]
    public string HolderName { get; set; }
    [EmailAddress]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "O nome do titular deve ter entre 2 e 200 caracteres.")]
    public string HolderEmail { get; set; }
    public string HolderDocument { get; set; }
    [Required]
    public HolderType HolderType { get; set; }
}
