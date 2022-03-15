using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Books
{
    public class InsertBooksDto
    {

        [MaxLength(100)]
       
        public string Sinopsis { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }

      
               
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }


    }
}
