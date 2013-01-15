using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComicArchiver.Models
{
    public class ComicSeries
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string IssuesOwned { get; set; }
        public int CurrentIssue { get; set; }
    }

    public class ComicSeriesDbContext : DbContext
    {
        public DbSet<ComicSeries> ComicsOwned { get; set; }
    }
}