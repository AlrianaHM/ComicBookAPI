using DatabaseService.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Dto
{
    public class ComicDto
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int TotalVolume { get; set; }

        public ComicDto()
        {
            Id = Guid.NewGuid();
        }

        public ComicDto(Comic comic)
        {
            Id = comic.Id;
            Title = comic.Title;
            Author = comic.Author;
            Status = comic.Status;
            TotalVolume = comic.TotalVolume;
        }

        public Comic ToComic()
        {
            try
            {
                Comic comic = new Comic();
                comic.Id = this.Id;
                comic.Title = this.Title;
                comic.Author = this.Author;
                comic.Status = this.Status;
                comic.TotalVolume = this.TotalVolume;
                return comic;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
