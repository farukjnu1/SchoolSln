using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels.ViewModels;
using DataModels.EntityModels.SchoolModel;
using DataServices.Infrastructure.School;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels.ViewModels.School;
using Newtonsoft.Json;

namespace SchoolWebApi.api.Cl
{
    //[Route("api/[controller]")]
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AllowAll")]
    [ApiController]
    public class ClController
    {
        #region Variable Declaration & Initialization
        private ClService _manager = null;
        #endregion

        #region Constructor
        public ClController()
        {
            _manager = new ClService();
        }
        #endregion

        #region All Http Methods
        // GET: api/Section/getbypage
        [HttpGet("[action]")]//, BasicAuthorization]
        public async Task<object> getbypage([FromQuery] int pageNumber, int pageSize)
        {
            object result = null; object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameters cmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());

                vmCmnParameters cmnParam = new vmCmnParameters();
                cmnParam.pageNumber = pageNumber;
                cmnParam.pageSize = pageSize;
                resdata = await _manager.GetWithPage(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        // GET: api/Section/getbyid
        [HttpGet("[action]")]//, BasicAuthorization]
        public async Task<object> getbyid([FromQuery] int id)
        {
            object result = null; object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameters cmnParam = JsonConvert.DeserializeObject<vmCmnParameters>(data[0].ToString());
                resdata = await _manager.GetByID(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // POST: api/Section/saveupdate
        [HttpPost("[action]")]//, BasicAuthorization]
        public async Task<object> saveupdate([FromBody]object[] data)
        {
            object result = null; object resdata = null;
            try
            {
                VmCl model = JsonConvert.DeserializeObject<VmCl>(data[0].ToString());
                if (model != null)
                {
                    resdata = await _manager.SaveUpdate(model);
                }
            }
            catch (Exception) { }

            return result = new
            {
                resdata
            };
        }

        // DELETE: api/zone/delete
        [HttpDelete("[action]")]//, BasicAuthorization]
        public async Task<object> delete([FromQuery] int id)
        {
            object result = null; object resdata = string.Empty;
            try
            {
                resdata = await _manager.Delete(id);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }
        #endregion

    }
}

