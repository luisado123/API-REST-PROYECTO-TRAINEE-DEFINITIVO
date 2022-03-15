using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Vet
{
    [Table("Autores", Schema = "Library")]
    public class AutoresEntity
    {
        [Key]
        public int IdAutor { get; set; }
       
        
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }
    }
}
