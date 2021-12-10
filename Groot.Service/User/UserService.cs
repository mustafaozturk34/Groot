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
    // kullanıcı işlemlerinin yapıldığı class 
    public class UserService : IUserService //interface
    {
        private readonly IMapper mapper; //Mapper çağrıldı

        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        // kullanıcı giriş işlemi
        public bool Login(string userName, string password)
        {
            bool result = false;
            using(var srv = new GrootContext())
            {
               result =  srv.User.Any(a => !a.IsDeleted && a.IsActive && a.UserName == userName && a.Password == password);
                
            }
            return result;
        }


        //kullanıcı ekleme işlemi
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

        //kullanıcıların listelendiği metod
        public General<Model.User.User> GetUsers()
        {
            var result = new General<Model.User.User>();

            using (var context = new GrootContext())
            {
                var data = context.User
                    .Where(x => !x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<Model.User.User>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir kullanıcı bulunamadı.";
                }
            }

            return result;
        }

        //kullanıcı güncelleme işlemi
        public General<Model.User.User> Update(int id, Model.User.User user)
        {
            var result = new General<Model.User.User>();

            using (var context = new GrootContext())
            {
                var updateUser = context.User.SingleOrDefault(i => i.Id == id);

                if (updateUser is not null)
                {
                    updateUser.Name = user.Name;
                    updateUser.UserName = user.UserName;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Password;

                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.User.User>(updateUser);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Kullanıcı bulunamadı.";
                }
            }

            return result;
        }

        //kullanıcı silme işlemi
        public General<Model.User.User> Delete(int id)
        {
            var result = new General<Model.User.User>();

            using (var context = new GrootContext())
            {
                var user = context.User.SingleOrDefault(i => i.Id == id);

                if (user is not null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.User.User>(user);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Kullanıcı bulunamadı.";
                    result.IsSuccess = false;
                }
            }

            return result;
        }



    }
}
