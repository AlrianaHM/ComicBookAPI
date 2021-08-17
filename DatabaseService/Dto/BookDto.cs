using DatabaseService.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Dto
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public DateTime? Release_Date { get; set; }
        public string Cover { get; set; }
        public Guid ComicId { get; set; }
        public int VolumeNumber { get; set; }
        public bool IsHave { get; set; }

        public BookDto()
        {
            Id = Guid.NewGuid();
            VolumeNumber = -1;
            IsHave = false;
        }

        public BookDto(Book book)
        {
            Id = book.Id;
            Release_Date = book.Release_Date;
            Cover = book.Cover;
            ComicId = book.ComicId;
            VolumeNumber = book.VolumeNumber;
            IsHave = book.IsHave;
        }

        public Book ToBook()
        {
            try
            {
                var book = new Book();
                book.Id = this.Id;
                book.Release_Date = this.Release_Date;
                book.Cover = this.Cover;
                book.ComicId = this.ComicId;
                book.VolumeNumber = this.VolumeNumber;
                book.IsHave = this.IsHave;
                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
