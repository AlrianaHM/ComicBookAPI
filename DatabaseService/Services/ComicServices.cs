using DatabaseService.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Services
{
    public static class ComicServices
    {

        public static IEnumerable<Comic> GetAll()
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                return entities.Comics.ToList();
            }
        }

        public static Comic GetById(Guid id)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                var comic = entities.Comics.FirstOrDefault(b => b.Id.Equals(id));
                return comic;
            }
        }

        public static void Create(Comic new_comic)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Comics.Add(new_comic);
                entities.SaveChanges();
            }
        }

        public static void Update(Comic current_comic, Comic new_comic)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Comics.Attach(current_comic);
                current_comic.Title = new_comic.Title;
                current_comic.Author = new_comic.Author;
                current_comic.Status = new_comic.Status;
                current_comic.TotalVolume = new_comic.TotalVolume;

                entities.SaveChanges();
            }
        }

        public static void Delete(Comic deleted_comic)
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                entities.Comics.Attach(deleted_comic);
                entities.Comics.Remove(deleted_comic);
                entities.SaveChanges();
            }
        }
    }
}
