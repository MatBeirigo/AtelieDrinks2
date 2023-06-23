using System.ComponentModel.DataAnnotations;

namespace AtelieDrinks.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
