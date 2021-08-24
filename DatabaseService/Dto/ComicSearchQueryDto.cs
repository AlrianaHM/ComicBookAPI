using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Dto
{
    public class ComicSearchQueryDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int TotalVolume { get; set; }

        public ComicSearchQueryDto()
        {
            Title = string.Empty;
            Author = string.Empty;
            Status = string.Empty;
            TotalVolume = -1; // set -1 to not filter by Total volume = 0
        }

        public string Print()
        {
            string result = "Query:\n";

            if (!string.IsNullOrEmpty(this.Title))
            {
                result += "Title: " + this.Title + "\n";
            }

            if (!string.IsNullOrEmpty(this.Author))
            {
                result += "Author: " + this.Author + "\n";
            }

            if (!string.IsNullOrEmpty(this.Status))
            {
                result += "Status: " + this.Status + "\n";
            }

            if (this.TotalVolume >= 0)
            {
                result += "TotalVolume: " + this.TotalVolume + "\n";
            }

            return result;
        }
    }
}
