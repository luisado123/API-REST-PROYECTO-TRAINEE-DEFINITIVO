using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Autores
{
   public class InsertAutoresDto
    {
        [MaxLength(100)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }
    }
}
