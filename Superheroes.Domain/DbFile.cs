using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Domain
{
    public class DbFile
    {
        [Key]
        public int FileId { get; set; }
        public byte[] Body { get; set; }
        [Required]
        public string ContentType { get; set; }
    }
}
