
using System.ComponentModel.DataAnnotations;
namespace Transportes.MVC.ViewModels
{
    public class ClassificacaoViewModel
    {

        [Key]
        public int ClassificacaoId { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }

        public int TransportadoraId { get; set; }
        public virtual TransportadoraViewModel Transportadora { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0,c}")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal preco { get; set; }
    }
}