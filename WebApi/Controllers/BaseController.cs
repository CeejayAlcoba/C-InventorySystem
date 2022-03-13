using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public User GetCurrentUser()
        {
            var userJson = HttpContext.Items["User"].ToString();

            var user = JsonSerializer.Deserialize<User>
                (userJson);
            return user;
        }

    }
}
