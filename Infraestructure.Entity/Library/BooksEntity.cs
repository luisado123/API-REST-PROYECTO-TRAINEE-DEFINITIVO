using Infraestructure.Entity.Model;

using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Library
{
  
        [Table("Book", Schema = "Library")]
        public class BooksEntity
        {
            [Key]
            public int IdBook { get; set; }
   


         
            [MaxLength(100)]
            public string Titulo { get; set; }
          
        

            

            [MaxLength(300)]
            public string Sinopsis { get; set; }


            



        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }

        public EditorialEntity EditorialEntity { get; set; }


    }
    }
