using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Models
{
    public class SequenceNumberBindingModel
    {
        [Required]
        [Display(Name="Magic Number")]
        [Range(1, long.MaxValue, ErrorMessage ="Number should be a positive whole number.")]
        public long Number { get; set; }

        [Display(Name = "Sequence Type Number")]
        [Range(0, 5, ErrorMessage = "Number should be a positive number between 1 & 5.")]
        public long SequenceTypeId { get; set; }
    }
}