using Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRB.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        [MinLength(2, ErrorMessageResourceName = "No_less_than", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(120, ErrorMessageResourceName = "No_more_than", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Is_required", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }




        [Display(Name = "Category", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "Is_required", ErrorMessageResourceType = typeof(Resource))]
        [ForeignKey("Category")]
        public int? CategoryID { get; set; }


        [Display(Name = "Category", ResourceType = typeof(Resources.Resource))]
        public virtual Category Category { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "Must_be_greater", ErrorMessageResourceType = typeof(Resource))]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceName = "Is_required", ErrorMessageResourceType = typeof(Resource))]
        public decimal Price { get; set; }

        
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        [MinLength(5, ErrorMessageResourceName = "No_less_than", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(500, ErrorMessageResourceName = "No_more_than", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Is_required", ErrorMessageResourceType = typeof(Resource))]
        public string Description { get; set; }

        [Display(Name = "Modified", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Modified { get; set; }
    }
}
