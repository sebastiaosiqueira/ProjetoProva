using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Transportes.MVC.ViewModels
{
    public class TransportadoraViewModel
    {
        [Key]
        public int TransportadoraId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150  caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(20, ErrorMessage = "Máximo {0} 20 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o campo I.E")]
        [MaxLength(14, ErrorMessage = "Máximo {0} 14 caracteres")]
  
        public string IE { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        public string Email { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo {0} 10 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF")]
        [MaxLength(2, ErrorMessage = "Máximo {0} 2 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Preencha o campo Endereco")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Endereco { get; set; }

        
        [MaxLength(10, ErrorMessage = "Máximo {0} 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(50, ErrorMessage = "Máximo {0} 50 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Bairro { get; set; }

        public virtual IEnumerable<ClassificacaoViewModel> Classificacoes { get; set; }
        public virtual IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}