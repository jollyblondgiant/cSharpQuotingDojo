using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required(ErrorMessage="What's your name?")]
        [MinLength(3, ErrorMessage="That's not a real name...")]
        [Display(Name="Name:")]
        public string User{get;set;}

        [Required(ErrorMessage="Please submit a quote")]
        [MinLength(8, ErrorMessage="Go on...")]
        [Display(Name="Quote:")]
        public string Text{get;set;}
    }
}