using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Models;

namespace ZilloVersion1.Data
{
    public class ZilloContext : IdentityDbContext<ApplicationUser>
    {
        public ZilloContext(DbContextOptions<ZilloContext> options)
            : base(options)
        {
        }

        public DbSet<SubmittedArticle> SubmittedArticles { get; set; }

        public DbSet<ApprovedArticle> ApprovedArticles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubmittedArticle>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<SubmittedArticle>().ToTable("SubmittedArticle");


            modelBuilder.Entity<ApprovedArticle>().HasKey(a => a.ApprovedArticleId);
            modelBuilder.Entity<ApprovedArticle>().ToTable("ApprovedArticle");



        }
    }
}
