using APIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIDemo.Controllers
{
    public class ListItemsController : ApiController
    {
        private static List<CustomListItem> _listItems { get; set; } = new List<CustomListItem>();
        // GET api/<controller>
       

        // GET api/<controller>/5
        public IEnumerable<CustomListItem> Get()
        {
            return _listItems;
        }


        public HttpResponseMessage Post([FromBody]CustomListItem model)
        {
            if (string.IsNullOrEmpty(model?.Text))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if (_listItems.Count > 0)
            {
                maxId = _listItems.Max(x => x.Id);
            }
            model.Id = maxId + 1;
            _listItems.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}