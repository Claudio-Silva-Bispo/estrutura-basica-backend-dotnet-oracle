using System.ComponentModel.DataAnnotations;

namespace ProjetoOdontoPrev.Application.DTOs
{
    public class CadastroClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome_Completo { get; set; } = null!;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone deve ser válido.")]
        public string Telefone { get; set; } = null!;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        public string CPF_CNPJ { get; set; } = null!;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        public string Genero { get; set; } = null!;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CEP da residência é obrigatório.")]
        public string CEP_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "O número da residência é obrigatório.")]
        public string Numero_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "A rua da residência é obrigatória.")]
        public string Rua_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "O bairro da residência é obrigatório.")]
        public string Bairro_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "O complemento da residência é obrigatório.")]
        public string Complemento_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "A cidade da residência é obrigatória.")]
        public string Cidade_Residencia { get; set; } = null!;

        [Required(ErrorMessage = "O estado da residência é obrigatório.")]
        public string Estado_Residencia { get; set; } = null!;

        public string CEP_Preferencia { get; set; } = null!;
        public string Numero_Preferencia { get; set; } = null!;
        public string Rua_Preferencia { get; set; } = null!;
        public string Bairro_Preferencia { get; set; } = null!;
        public string Complemento_Preferencia { get; set; } = null!;
        public string Cidade__Preferencia { get; set; } = null!;
        public string Estado_Preferencia { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; } = null!;
    }
}
