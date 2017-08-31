using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CinemaOL.Services;
using CinemaOL.Models;

namespace CinemaOL.Controllers
{
    public class ServiceController : BaseController
    {
        public ServiceController(IOptions<GlobalOption> globalOptions) : base(globalOptions)
        {

        }

        [HttpPost]
        public IActionResult FillDateList([FromBody]VMSelectShow obj)
        {
            try
            {
                return Json(_dbAccess.FillDateList(obj.pMovieTitle));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult FillTimeList([FromBody]VMSelectShow obj)
        {
            try
            {
                return Json(_dbAccess.FillTimeList(obj.pMovieTitle, obj.pMovieDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
