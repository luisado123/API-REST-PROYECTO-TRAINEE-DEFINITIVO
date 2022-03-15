﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
   public class AutoresDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "los nombres Son requeridos")]
        [MaxLength(300)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son Obligatorios")]
        [MaxLength(100)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
    }
}
