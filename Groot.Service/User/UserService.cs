using AutoMapper;
using Groot.DB.Entities.DataContext;
using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public bool Login(string userName, string password)
        {
            bool result = false;
            using(var srv = new GrootContext())
            {
                srv.User.Any(a => !a.IsDeleted && a.IsActive && a.UserName == userName && a.Password == password);
            }
            return result;
        }


        public General<Model.User.User> Insert(Groot.Model.User.User newUser)
        {
            var result = new General<Model.User.User>() { IsSuccess = false};
            try
            {
                var model = mapper.Map<Groot.DB.Entities.User>(newUser);
                using (var srv = new GrootContext())
                {
                    model.Idatetime = DateTime.Now;
                    srv.User.Add(model);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<Groot.Model.User.User>(model);
                    result.IsSuccess = true;
                }
            }
            catch (Exception)
            {

                result.ExceptionMessage = "Beklenmeyen bir sorun oluştu.";
            }

            return result;
        }
    }
}
