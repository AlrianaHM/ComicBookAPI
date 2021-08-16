using DatabaseService.DatabaseModel;
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
                IEnumerable<Comic> comics = ComicServices.GetAll();
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
                    return Request.CreateResponse(HttpStatusCode.OK, comic);
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

        public HttpResponseMessage Post([FromBody]Comic new_comic)
        {
            try
            {
                ComicServices.Create(new_comic);
                return Request.CreateResponse(HttpStatusCode.Created, new_comic);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(Guid id, [FromBody]Comic new_comic)
        {
            try
            {
                Comic comic = ComicServices.GetById(id);
                if (comic != null)
                {
                    ComicServices.Update(comic, new_comic);
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
