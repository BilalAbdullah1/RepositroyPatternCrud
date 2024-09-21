using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using newproj.Data;
using newproj.Models;

namespace newproj.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersgriddataController : Controller
    {
        private CrudContext _context;

        public UsersgriddataController(CrudContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var users = _context.users.Select(i => new {
                i.userId,
                i.FullName,
                i.Email,
                i.Address,
                i.Password,
                i.ProfilePicture,
                i.DOB,
                i.Gender,
            });

            return Json(await DataSourceLoader.LoadAsync(users, loadOptions));
        }
     
    }
}