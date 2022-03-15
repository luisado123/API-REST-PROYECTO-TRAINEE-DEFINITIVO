using Infraestructure.Entity.Library;
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.Books
{

        public class ConsultBooksDto : BookDto
        {
        public int IdAutor { get; set; }
        public string editorial { get; set; }

        public string Autor { get; set; }


        public Autores_has_librosEntity Autores_Has_Libros { get; set; }





    }
    }


