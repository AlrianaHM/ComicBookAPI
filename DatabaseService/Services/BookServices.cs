using DatabaseService.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Services
{
    public static class BookServices
    {
        public static IEnumerable<Book> GetAll()
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                return entities.Books.ToList();
            }
        }

        public static Book GetById(Guid id)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                var book = entities.Books.FirstOrDefault(b => b.Id.Equals(id));
                return book;
            }
        }

        public static void Create(Book new_book)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Books.Add(new_book);
                entities.SaveChanges();
            }
        }

        public static void Update(Book current_book, Book new_book)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Books.Attach(current_book);

                current_book.Release_Date = new_book.Release_Date;
                current_book.Cover = new_book.Cover;
                current_book.ComicId = new_book.ComicId;
                current_book.VolumeNumber = new_book.VolumeNumber;
                current_book.IsHave = new_book.IsHave;

                entities.SaveChanges();
            }
        }

        public static void Delete(Book deleted_book)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Books.Attach(deleted_book);
                entities.Books.Remove(deleted_book);
                entities.SaveChanges();
            }
        }
    }
}
