using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZilloVersion1.Data;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.Articles
{

    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        public CreateModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
          
            return Page();
        }

        [BindProperty]
        public SubmittedArticle Article { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
       

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Article.ImageData = ms.ToArray();

                ms.Close();

                ms.Dispose();

            }

           

            _context.SubmittedArticles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
