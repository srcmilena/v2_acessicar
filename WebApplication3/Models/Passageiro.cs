using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Passageiro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        [StringLength(11)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Atenção! esse campo é de preenchimento obrigatório")]
        [StringLength(11)]
        public string Cpf { get; set; }
    }
}
