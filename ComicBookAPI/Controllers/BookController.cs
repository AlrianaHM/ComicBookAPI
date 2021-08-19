using DatabaseService.DatabaseModel;
using DatabaseService.Dto;
using DatabaseService.Services;
using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<BookDto> books = BookServices.GetAll().Select(book => new BookDto(book));

                log.Info("[Get Books] Get all books");
                return Request.CreateResponse(HttpStatusCode.OK, books);
            }
            catch (Exception ex)
            {
                log.Error("[Get Books] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                Book book = BookServices.GetById(id);
                if (book != null)
                {
                    BookDto dto = new BookDto(book);

                    log.Info("[Get Book] Get book with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    log.Info("[Get Book] Book is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Get Book] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody]BookDto new_book)
        {
            try
            {
                Book book = new_book.ToBook();
                BookServices.Create(book);

                log.Info("[Create Book] Create book with id: " + new_book.Id);
                return Request.CreateResponse(HttpStatusCode.Created, new_book);
            }
            catch (Exception ex)
            {
                log.Error("[Create Book] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]BookDto new_book)
        {
            try
            {
                Book book = BookServices.GetById(id);
                if (book != null)
                {
                    BookServices.Update(book, new_book.ToBook());

                    log.Info("[Update Book] Update book with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK, new_book);
                }
                else
                {
                    log.Info("[Update Book] Book is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Update Book] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Book book = BookServices.GetById(id);
                if (book != null)
                {
                    BookServices.Delete(book);

                    log.Info("[Delete Book] Delete book with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    log.Info("[Delete Book] Book is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Delete Book] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
