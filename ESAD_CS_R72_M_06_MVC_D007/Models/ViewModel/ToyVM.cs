using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D007.Models.ViewModel
{
    public class ToyVM
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name = "Toy Name")]
        public string ToyName { get; set; }
        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Entry Date")]
        public DateTime StoreDate { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        [ForeignKey("Category"), Display(Name = "Category")]
        public int cId { get; set; }
        public string cName { get; set; }
        public HttpPostedFileBase Picture { get; set; }

        public virtual Category Category { get; set; }
    }
}