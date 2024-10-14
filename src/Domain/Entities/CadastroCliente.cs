using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoOdontoPrev.Domain.Entities
{
    [Table("tb_cadastro_cliente")]
    public class CadastroClienteEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome_Completo { get; set; } = null!;

        [Required]
        [Phone]
        public string Telefone { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"\d{11}|\d{14}", ErrorMessage = "O CPF/CNPJ deve ter 11 ou 14 dígitos.")]
        public string CPF_CNPJ { get; set; } = null!;

        [Required]
        public string Genero { get; set; } = null!;

        [Required]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "A data de nascimento deve estar entre 01/01/1900 e 31/12/2100.")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(8)]
        public string CEP_Residencia { get; set; } = null!;

        [Required]
        public string Numero_Residencia { get; set; } = null!;

        [Required]
        public string Rua_Residencia { get; set; } = null!;

        [Required]
        public string Bairro_Residencia { get; set; } = null!;

        [Required]
        public string Complemento_Residencia { get; set; } = null!;

        [Required]
        public string Cidade_Residencia { get; set; } = null!;

        [Required]
        public string Estado_Residencia { get; set; } = null!;

        public string CEP_Preferencia { get; set; } = null!;
        public string Numero_Preferencia { get; set; } = null!;
        public string Rua_Preferencia { get; set; } = null!;
        public string Bairro_Preferencia { get; set; } = null!;
        public string Complemento_Preferencia { get; set; } = null!;
        public string Cidade__Preferencia { get; set; } = null!;
        public string Estado_Preferencia { get; set; } = null!;

        [Required]
        public string Senha { get; set; } = null!;
    }
}
