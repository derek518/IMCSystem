using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;
using NLog;

using IMCSystem.Server.Models;

namespace IMCSystem.Server.Controllers
{
    public class UsersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET api/users
        //public IQueryable<User> Get()
        //{
        //    UserRepository repository = new UserRepository();
            
        //    return repository.GetAll();
        //}

        //// GET api/users/1
        //public User Get(string id)
        //{
        //    UserRepository repository = new UserRepository();

        //    return repository.Get(id);
        //}

        //// POST api/users 
        //public void Post([FromBody]User value)
        //{
        //    logger.Debug("Post Enter... value:" + value.ToJson<User>());

        //    UserRepository repository = new UserRepository();

        //    repository.Add(value);

        //    logger.Debug("Post Leave... value:" + value.ToJson<User>());
        //}

        //// PUT api/users/1 
        //public void Put(string id, [FromBody]User value)
        //{
        //    logger.Debug("Put value:" + value.ToJson<User>());
        //}

        //// DELETE api/users/1 
        //public void Delete(string id)
        //{
        //    logger.Debug("Delete id:" + id.ToString());

        //    UserRepository repository = new UserRepository();
        //    repository.Delete(id);
        //}
    }
}
