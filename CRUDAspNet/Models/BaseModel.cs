using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNet.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Date ajout")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Date de dernière modification")]
        public DateTime UpdatedAt { get; set; }

        public BaseModel()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
