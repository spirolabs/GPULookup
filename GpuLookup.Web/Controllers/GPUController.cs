﻿using GpuLookup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GpuLookup.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class GPUController : ApiController
    {
        readonly GpuService gpuService;
        public GPUController (GpuService gpuService)
        {
            this.gpuService = gpuService;
        }
        [Route("api/getAll"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var gpus = gpuService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, gpus);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        } 
    }
}