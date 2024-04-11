using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;
using MyGarden.Core.Models;
using MyGarden.Data.Data;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Controllers
{
    public class AccountController
    {
        MyGardenDb myGardenDb = new MyGardenDb();
        public void UserRegister(UserViewModel userViewModel)
        {
            var user = new User()
            {
                Id = new Guid(),
                Username = userViewModel.Username,
                Password = userViewModel.Password,
                Name = userViewModel.Name
            };
            myGardenDb.Users.Add(user);
            myGardenDb.SaveChanges();
        }

        public void WorkerRegister(WorkerViewModel workerViewModel)
        {
            var worker = new Worker()
            {
                Id = new Guid(),
                Username = workerViewModel.Username,
                Password = workerViewModel.Password,
                Name = workerViewModel.Name
            };
            myGardenDb.Workers.Add(worker);
            myGardenDb.SaveChanges();
        }

        public Guid LogInUser(LogInViewModel logInViewModel)
        {
            Guid Id = Guid.Empty;

            User user = myGardenDb.Users.FirstOrDefault(u => u.Id == logInViewModel.Id);
            if (user.Password == logInViewModel.Password)
            {
                Id = logInViewModel.Id;
            }
            return Id;
        }

        public Guid LogInWorker(LogInViewModel logInViewModel)
        {
            Guid Id = Guid.Empty;
            Worker worker = myGardenDb.Workers.FirstOrDefault(w => w.Id == logInViewModel.Id);
            if (worker.Password == logInViewModel.Password)
            {
                Id = logInViewModel.Id;
            }
            return Id;
        }

        public Guid IsUser(string username)
        {
            Guid id = Guid.Empty;
            User user = myGardenDb.Users.FirstOrDefault(u => u.Username == username);
            if (user != null) id = user.Id;
            return id;
        }
        public Guid IsWorker(string username)
        {
            Guid id = Guid.Empty;
            Worker worker = myGardenDb.Workers.FirstOrDefault(w => w.Username == username);
            if (worker != null) id = worker.Id;
            return id;
        }

        public string GetUserName(Guid id)
        {
            User user = myGardenDb.Users.FirstOrDefault(u => u.Id == id);
            return user.Name;
        }
        public string GetUsername(Guid id)
        {
            User user = myGardenDb.Users.FirstOrDefault(u => u.Id == id);
            return user.Username;
        }

        public string GetWorkerName(Guid id)
        {
            Worker worker = myGardenDb.Workers.FirstOrDefault(w => w.Id == id);
            return worker.Name;
        }
        public string GetWorkerUsername(Guid id)
        {
            Worker worker = myGardenDb.Workers.FirstOrDefault(w => w.Id == id);
            return worker.Username;
        }

        public void UpdateUser(UserUpdateViewModel userUpdateViewModel)
        {
            User user = myGardenDb.Users.Find(userUpdateViewModel.Id);
            if (userUpdateViewModel.Username != "")
            {
                user.Username = userUpdateViewModel.Username;
            }
            if (userUpdateViewModel.Name != "")
            {
                user.Name = userUpdateViewModel.Name;
            }
            if (userUpdateViewModel.Password != "")
            {
                user.Password = userUpdateViewModel.Password;
            }
            myGardenDb.Update(user);
            myGardenDb.SaveChanges();
        }

        public void UpdateWorker(WorkerUpdateViewModel workerUpdateViewModel)
        {
            Worker worker = myGardenDb.Workers.Find(workerUpdateViewModel.Id);
            if (workerUpdateViewModel.Username != "")
            {
                worker.Username = workerUpdateViewModel.Username;
            }
            if (workerUpdateViewModel.Name != "")
            {
                worker.Name = workerUpdateViewModel.Name;
            }
            if (workerUpdateViewModel.Password != "")
            {
                worker.Password = workerUpdateViewModel.Password;
            }
            myGardenDb.Update(worker);
            myGardenDb.SaveChanges();
        }
    }
}
