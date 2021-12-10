using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.User
{
    public interface IUserService
    {
        public General<Groot.Model.User.User> Insert(Groot.Model.User.User newUser);
    }
}
