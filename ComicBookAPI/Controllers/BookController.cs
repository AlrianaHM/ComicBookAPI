using DatabaseService.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicBookAPI.Controllers
{
    public class BookController : ApiController
    {

        public IEnumerable<Book> Get()
        {
            using (ComicBookEntities entities = new ComicBookEntities())
            {
                return entities.Books.ToList();
            }
        }

    }
}
