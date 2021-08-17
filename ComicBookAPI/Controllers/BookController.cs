using DatabaseService.DatabaseModel;
using DatabaseService.Dto;
using DatabaseService.Services;
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

        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<BookDto> books = BookServices.GetAll().Select(book => new BookDto(book));
                return Request.CreateResponse(HttpStatusCode.OK, books);
            }
            catch (Exception ex)
            {
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
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody]BookDto new_book)
        {
            try
            {
                Book book = new_book.ToBook();
                BookServices.Create(book);
                return Request.CreateResponse(HttpStatusCode.Created, new_book);
            }
            catch (Exception ex)
            {
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
                    return Request.CreateResponse(HttpStatusCode.OK, new_book);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
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
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
