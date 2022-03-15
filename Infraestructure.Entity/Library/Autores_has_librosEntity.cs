using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Library
{
    [Table("Autores_has_libros", Schema = "Library")]
    public class Autores_has_librosEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AutoresEntity")]
        public int IdAutor { get; set; }


        public AutoresEntity AutoresEntity { get; set; }
        [ForeignKey("BooksEntity")]
        public int IdBook { get; set; }

        public BooksEntity BooksEntity { get; set; }
    }
}
