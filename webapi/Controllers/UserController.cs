using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Models;

namespace webapi.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        
        static List<UserModel> _context = new List<UserModel>()
        {
        new UserModel{UserId = 1, UserName = "Büşra", BirthPlace = "Bursa", BirthYear = "1985"},
        new UserModel{UserId = 2, UserName = "Ezgi", BirthPlace = "İstanbul", BirthYear = "1990"},
        new UserModel{UserId = 3, UserName = "Emre", BirthPlace = "İzmir", BirthYear = "1970"},
        new UserModel{UserId = 4, UserName = "Ece", BirthPlace = "Ankara", BirthYear = "1980"}
        };

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _context.ToList();
        }

        // GET api/<controller>/5
        [HttpGet]
        public UserModel Get(int id)
        {
            var user = _context.Where(x => x.UserId == id).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //API, userID parametresi ile istek almalı, bu isteğin karşılığında kullanıcı adi, doğum yeri ve doğum tarihi bilgilerini dönmeli
        }

    }
}