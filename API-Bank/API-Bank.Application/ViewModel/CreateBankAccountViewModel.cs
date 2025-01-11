using API_Bank.Domain.Enum;

namespace API_Bank.Application.ViewModel;

public class CreateBankAccountViewModel
{
    public string Branch { get; set; } //
    public string? Number { get; set; }
    public AccountType Type { get; set; }//
    public string HolderName { get; set; }//
    public string HolderEmail { get; set; }//
    public string HolderDocument { get; set; }//
    public HolderType HolderType { get; set; }//
    public Status? Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //public string Agencia { get; set; }          // Branch
    //public string Numero { get; set; }           // Number
    //public TipoConta Tipo { get; set; }          // AccountType
    //public string NomeTitular { get; set; }      // HolderName
    //public string EmailTitular { get; set; }     // HolderEmail
    //public string DocumentoTitular { get; set; } // HolderDocument
    //public TipoTitular TipoTitular { get; set; } // HolderType
    //public Status Status { get; set; }           // Status
    //public DateTime CriadoEm { get; set; }       // CreatedAt
    //public DateTime AtualizadoEm { get; set; }   // UpdatedAt

}
