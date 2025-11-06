using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.ViewModels.Categories
{
    public class QueryCategory
    {
        [StringLength(100, ErrorMessage = "Name filter cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [StringLength(500, ErrorMessage = "Description filter cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [DataType(DataType.Date, ErrorMessage = "MinCreatedDate must be a valid date.")]
        public DateTime? MinCreatedDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "MaxCreatedDate must be a valid date.")]
        public DateTime? MaxCreatedDate { get; set; }
    }
}
