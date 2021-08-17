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
    public class ComicController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<ComicDto> comics = ComicServices.GetAll().Select(comic => new ComicDto(comic));
                return Request.CreateResponse(HttpStatusCode.OK, comics);
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
                Comic comic = ComicServices.GetById(id);
                if (comic != null)
                {
                    ComicDto dto = new ComicDto(comic);
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody]ComicDto new_comic)
        {
            try
            {
                ComicServices.Create(new_comic.ToComic());
                return Request.CreateResponse(HttpStatusCode.Created, new_comic);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]ComicDto new_comic)
        {
            try
            {
                Comic comic = ComicServices.GetById(id);
                if (comic != null)
                {
                    ComicServices.Update(comic, new_comic.ToComic());
                    return Request.CreateResponse(HttpStatusCode.OK, new_comic);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
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
                Comic comic = ComicServices.GetById(id);
                if (comic != null)
                {
                    ComicServices.Delete(comic);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
