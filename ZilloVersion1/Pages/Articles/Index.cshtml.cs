using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Data;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly ZilloVersion1.Data.ZilloContext _context;

        //creating a new zillo context model to access the db
        public IndexModel(ZilloVersion1.Data.ZilloContext context)
        {
            _context = context;
        }

        //creating a new IList of ApprovedArticle objects
        public IList<ApprovedArticle> Article { get; set; } = default!;
       

        //Storing the ApprovedArticles object on a list of Articles 
        public async Task OnGetAsync()
        {
            if (_context.SubmittedArticles != null)
            {
                Article = await _context.ApprovedArticles.ToListAsync();
                
            }
        }
    }
}
