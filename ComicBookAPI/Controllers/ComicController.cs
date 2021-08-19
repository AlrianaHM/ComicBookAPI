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
    public class ComicController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<ComicDto> comics = ComicServices.GetAll().Select(comic => new ComicDto(comic));

                log.Info("[Get Comics] Get all comics");
                return Request.CreateResponse(HttpStatusCode.OK, comics);
            }
            catch (Exception ex)
            {
                log.Error("[Get Comics] Error: ", ex.InnerException);
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

                    log.Info("[Get Comic] Get comics with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    log.Info("[Get Comic] Comic is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Get Comic] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody]ComicDto new_comic)
        {
            try
            {
                ComicServices.Create(new_comic.ToComic());

                log.Info("[Create Comic] Create comics with id: " + new_comic.Id);
                return Request.CreateResponse(HttpStatusCode.Created, new_comic);
            }
            catch (Exception ex)
            {
                log.Error("[Create Comic] Error: ", ex.InnerException);
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

                    log.Info("[Update Comic] Create comics with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK, new_comic);
                }
                else
                {
                    log.Info("[Update Comic] Comic is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Update Comic] Error: ", ex.InnerException);
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

                    log.Info("[Delete Comic] Create comics with id: " + id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    log.Info("[Delete Comic] Comic is not found - id: " + id);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Comic is not found");
                }
            }
            catch (Exception ex)
            {
                log.Error("[Delete Comic] Error: ", ex.InnerException);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
