using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.User
{
    public interface IUserService // interface oluşturuldu
    {
        //UserService classında kullanılacak metodlar burada tanımlandı.
        public bool Login(string userName, string password);
        public General<Groot.Model.User.User> Insert(Groot.Model.User.User newUser);
        public General<Model.User.User> GetUsers();
        public General<Model.User.User> Update(int id, Model.User.User user);
        public General<Model.User.User> Delete(int id);
    }
}
