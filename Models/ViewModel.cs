using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LOTR_API_Testing.Models
{
    public class ViewModel
    {
        [Display(Name = "Select Character to Get Quote!")]
        public List<SelectListItem> CharacterDD { get; set; } = [];

        [Display(Name = "Character")]
        public string CharacterID { get; set; } = string.Empty;

        [Display(Name = "Character Quote")]
        public string Quote { get; set; } = string.Empty;

        public ViewModel()
        {
            CharacterDD =
            [
                new SelectListItem { Text = "Aragon", Value = "5cd99d4bde30eff6ebccfbe6" },
                new SelectListItem { Text = "Arwen", Value = "5cd99d4bde30eff6ebccfc07" },
                new SelectListItem { Text = "Bilbo", Value = "5cd99d4bde30eff6ebccfc38" },
                new SelectListItem { Text = "Elrond", Value = "5cd99d4bde30eff6ebccfcc8" },
                new SelectListItem { Text = "Frodo", Value = "5cd99d4bde30eff6ebccfc15" },
                new SelectListItem { Text = "Gandalf", Value = "5cd99d4bde30eff6ebccfea0" },
                new SelectListItem { Text = "Gimili", Value = "5cd99d4bde30eff6ebccfd23" },
                new SelectListItem { Text = "Gollum", Value = "5cd99d4bde30eff6ebccfe9e" },
                new SelectListItem { Text = "Legolas", Value = "5cd99d4bde30eff6ebccfd81" },
                new SelectListItem { Text = "Samwise", Value = "5cd99d4bde30eff6ebccfd0d" }
            ];
        }
    }    
}
