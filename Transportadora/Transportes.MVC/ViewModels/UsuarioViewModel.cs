﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Transportes.Domain.Entities;
namespace Transportes.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2  caracteres")]
        public string Nome { get; set; }
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo {0} 11 caracteres")]
        [MinLength(11, ErrorMessage = "Minimo {0} 11 caracteres")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Preencha o Endereco")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Endereco { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo {0} 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(50, ErrorMessage = "Máximo {0} 50 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF")]
        [MaxLength(2, ErrorMessage = "Máximo {0} 2 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} 2 caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(150, ErrorMessage = "Máximo {0} 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0}2 caracteres")]
        public string Cidade { get; set; }

        public virtual IEnumerable<TransportadoraViewModel> Transportadoras { get; set; }

        public virtual IEnumerable<ClassificacaoViewModel> Classificacoes { get; set; }
    }
}