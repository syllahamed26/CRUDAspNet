using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNet.Models
{
    [Table("Employes")]
    public class EmployeModel:BaseModel
    {
        [Required]
        [DisplayName("Nom & Prénom(s)")]
        public String FullName { get; set; }
        [Required]
        [DisplayName("Matricule")]
        public String Code { get; set; }
        [Required]
        public String Poste { get; set; }
        [Required]
        public String Bureau { get; set; }
    }
}
