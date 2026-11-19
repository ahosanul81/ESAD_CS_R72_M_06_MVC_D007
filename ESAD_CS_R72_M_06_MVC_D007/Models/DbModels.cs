using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D007.Models
{
    public class Category   
    {
        [Key]
        public int cId { get; set; }
        [Required, StringLength(50), Display(Name = "Category Name")]
        public string cName { get; set; }


        public virtual ICollection<Toy> Toys { get; set; } = new List<Toy>();
    }

    public class Toy
    {
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name = "Toy Name")]
        public string ToyName { get; set; }
        [Required, Column(TypeName = "Money"), DisplayFormat(DataFormatString ="{0:0.00}", ApplyFormatInEditMode =true)]
        public decimal Price { get; set; }

        [Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name ="Entry Date")]
        public DateTime StoreDate { get; set; }
        [Display(Name ="Picyure")]
        public string PicturePath { get; set; }

        [ForeignKey("Category"), Display(Name = "Category")]
        public int cId { get; set; }
        public virtual Category Category { get; set; }
    }


    public class ToyDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Toy> Toys { get; set; }
    }
}