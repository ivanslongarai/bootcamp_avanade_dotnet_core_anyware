using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.InputModel
{
    public class GameInputModel
    {
        // Fail fast principle, it fails as soon as possible...

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve possuir de 3 a 100 caracteres")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Producer { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public decimal Price { get; set; }
    }
}
