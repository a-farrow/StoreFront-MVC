using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreFront.DATA.EF.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF.Models
{
    public class CategoryMetadata
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is required!")]
        [StringLength(50, ErrorMessage = "Category Name must be 50 characters or less!")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Description")]
        public string? CategoryDescription { get; set; }
    }

    public class OrderMetadata
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Order Time")]
        [Required]
        public DateTime OrderTime { get; set; }

        [StringLength(80)]
        [Display(Name = "Ship To")]
        [Required]
        public string ShipToName { get; set; } = null!;

        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string ShipCity { get; set; } = null!;

        [StringLength(2)]
        [Display(Name = "State")]
        [DataType(DataType.Text)]
        public string? ShipState { get; set; }

        [StringLength(10)]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string ShipZip { get; set; } = null!;

        [StringLength(60)]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        [Required]
        public string ShipCountry { get; set; } = null!;
    }

    public class ProductMetadata
    {
        public int ProductID { get; set; }

        [StringLength(50)]
        [Display(Name = "Product")]
        [Required]
        public string ProductName { get; set; } = null!;

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        [Display(Name = "Product Status")]
        public int ProductStatusID { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [UIHint("Multilinetext")]
        public string? ProductDescription { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [Display(Name = "Price")]
        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [Display(Name = "Cost")]
        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal UnitCost { get; set; }

        [Required]
        [Range(0, short.MaxValue)]
        [Display(Name = "In Stock")]
        public int UnitsInStock { get; set; }

        [Required]
        [Range(0, short.MaxValue)]
        [Display(Name = "On Order")]
        public int UnitsOnOrder { get; set; }

        [Required]
        [Range(0, short.MaxValue)]
        [Display(Name = "Reorder Trigger")]
        public int ReorderTrigger { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2} lbs")]
        [Range(0, (double)decimal.MaxValue)]
        [Display(Name = "Unit Weight")]
        public decimal? UnitWeightLbs { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2} fl oz")]
        [Range(0, (double)decimal.MaxValue)]
        [Display(Name = "Unit Size")]
        public decimal? UnitSizeFlOunce { get; set; }

        [Display(Name = "Image")]
        public string? ProductImage { get; set; }
    }

    public class SupplierMetadata
    {
        public int SupplierID { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        [StringLength(50)]
        public string CompanyName { get; set; } = null!;

        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [StringLength(20, ErrorMessage = "Phone number must be no more than 20 characters!")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(2)]
        [DataType(DataType.Text)]
        public string? State { get; set; }

        [StringLength(60)]
        [DataType(DataType.Text)]
        public string? Country { get; set;}
    }

    public class CustomerMetadata
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Middle Initial")]
        public string? MiddleInitial { get; set; }

        [Required]
        [StringLength(75)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [StringLength(20, ErrorMessage = "Phone number must be no more than 20 characters!")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;

        [StringLength(2)]
        [DataType(DataType.Text)]
        public string? State { get; set; }

        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }

        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        public string Country { get; set; } = null!;
    }
}
        

