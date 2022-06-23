using System.ComponentModel.DataAnnotations;

namespace SuperheroesMvcUI.Models
{
    public class PageIndexDisplay : IPageIndex
    {
        [Required]
        [Range(0,8,ErrorMessage = "No album page with this index!")]
        public int PageIndex { get; set; }
    }
}
