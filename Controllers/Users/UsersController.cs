using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API_TRC.Models;
using API_TRC.Models.User;

namespace API_TRC.Controllers.Users
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        // GET api/users
        public IHttpActionResult GetUserDetail(long id)
        {
            using (var context = new testing_ali_fullstackEntities())
            {
                var usuario = context.users_test_daniel_chacon.Where(r => r.id == id).FirstOrDefault();
                return Ok(usuario);
            }
        }

        // POST api/users/
        public IHttpActionResult CreateUser(users_test_daniel_chacon model)
        {
            using (var context = new testing_ali_fullstackEntities())
            {
                if (model.name == null)
                {
                    return BadRequest("El nombre es obligatorio");
                }

                if (model.lastname == null)
                {
                    return BadRequest("El apellido es obligatorio");
                }

                if (model.email == null)
                {
                    return BadRequest("El email es obligatorio");
                }

                if (model.phone == null)
                {
                    return BadRequest("El telefono es obligatorio");
                }

                if (model.birthdate == null)
                {
                    return BadRequest("La fecha de nacimiento es obligatorio");
                }

                var newUser = new users_test_daniel_chacon()
                {
                    name = model.name,
                    second_name = model.second_name,
                    lastname = model.lastname,
                    second_lastname = model.second_lastname,
                    email = model.email,
                    phone = model.phone,
                    birthdate = model.birthdate,
                    register_date = DateTime.Now,
                    status = true
                };

                try
                {
                    context.users_test_daniel_chacon.Add(newUser);
                    context.SaveChanges();

                    return Ok(new UserResponse()
                    {
                        Name = newUser.name,
                        SecondName = newUser.second_name,
                        Lastname = newUser.lastname,
                        SecondLastname = newUser.second_lastname,
                        Email = newUser.email,
                        Phone = newUser.phone,
                        Birthdate = newUser.birthdate.ToString("d"),
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}