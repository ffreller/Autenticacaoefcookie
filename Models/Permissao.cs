using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacaoefcookie.Models {
    public class Permissao {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int IdPermissao { get; set; }

        [StringLength (100, MinimumLength = 4)]
        [Required]
        public string Nome { get; set; }
        public ICollection<UsuarioPermissao> UsuariosPermissoes { get; set; }
    }
}