using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Paylocity.CodingChallenge.Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int NumberOfDependents { get; set; }

        public List<SelectListItem> DependentNumberList { get; } = new List<SelectListItem>();

        public IndexModel()
        {
            PopulateDependentNumberList();
        }

        #region HTTP Actions
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/EmployeeInformation", new { NumberOfDependents = NumberOfDependents });

        }
        #endregion

        private void PopulateDependentNumberList()
        {
            for (var i = 0; i <= 10; i++)
            {
                DependentNumberList.Add(new SelectListItem($"{(i == 0 ? "No" : i.ToString())} Dependent{(i == 1 ? "" : "s")}", i.ToString()));
            }
        }
    }
}
