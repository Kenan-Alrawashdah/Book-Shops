using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        //Id unique for each book
        [Key()]
        public long BookId { get; set; }

        //Title of the book(Required)
        [MaxLength(20, ErrorMessage = "It should not exceed 20 characters!")]
        [MinLength(5, ErrorMessage = "It must be more than 5 characters!")]
        [Required(ErrorMessage = "Title is Required!")]
        public string Title { get; set; }

        //Description of the book (length 5 – 100 (required) )
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description should have 5 up to 100 char!")]
        public string Description { get; set; }

        //Price of the book (minimum 1.50 $  - 1,500.00 $ (required) )
        [Required(ErrorMessage = "Price is Required")]
        [Range(1.5, 1500.0, ErrorMessage = "Fees should be between 1.5$ and 1500.0$!")]
        public double Price { get; set; }

        //Author of the book (length 5 – 30 (required) )
        [Required(ErrorMessage = "Authors is Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "It should between 5 to 30 characters!")]
        public string Authors { get; set; }

        //Published date (default Date-time-Now)
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        //Img of type URL
        [Display(Name = "Image Url(optional)", Prompt ="Enter url iamge")]
        [DataType(DataType.Url, ErrorMessage = "Please enter an image 'url'")]
        public string ImageUrl { get; set; }

        //#No of copies (minimum 1 – 100 (required) ) 
        [Range(1, 100, ErrorMessage = "It should between 1 to 100!")]
        public int Count { get; set; }

        //Category of the book
        public BookCategory Category { get; set; } 

    }
}
