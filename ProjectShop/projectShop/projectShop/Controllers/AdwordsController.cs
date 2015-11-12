using projectShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace projectShop.Controllers
{
    public class AdwordsController : ApiController
    {
        private reklameAPIEntities db = new reklameAPIEntities();

        public IQueryable<AdwordDTO> GetBooks()
        {
            var adwords = from ad in db.Adwords
                          select new AdwordDTO()
                          {
                              Id = ad.Id,
                              Name = ad.Name,
                              Url = ad.Url,
                              Image = ad.Image
                          };

            return adwords;
        }
        }

}
