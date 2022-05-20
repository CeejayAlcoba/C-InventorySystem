using Domain.Entities;
using Domain.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Services.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IAccountService accountService, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {

            var salt = _accountService.GenerateSalt(user.Password);
            var hashedPassword = _accountService.GenerateHashPassword(user.Password, salt);
            var newUser = new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Username = user.Username,
                HashPassword = hashedPassword,
                Salt = salt
            };

            _unitOfWork.Users.Add(newUser);
            _unitOfWork.Complete();
        }



        public User UpdateUsername(User user, int Id)
        {
            var userId = _unitOfWork.Users.GetById(Id);

            var validatePassword = _accountService.GenerateHashPassword(user.CurrentPassword, userId.Salt);
            if (validatePassword != userId.HashPassword) return null;
            else
            {
                var salt = _accountService.GenerateSalt(user.Password);
                var hashedPassword = _accountService.GenerateHashPassword(user.Password, salt);

                userId.Username = user.Username;
                userId.Firstname = user.Firstname;
                userId.Lastname = user.Lastname;
                userId.HashPassword = hashedPassword;
                userId.Salt = salt;

                _unitOfWork.Complete();
                return userId;
            }
            
        }
        public User DeleteUser(int userId)
        {
            var user = _unitOfWork.Users.GetById(userId);
            if (user.IsDelete == false)
            {
                user.IsDelete = true;
                _unitOfWork.Complete();
                return user;
            }
            else return null;
        }
        public User RecoverUser(int userId)
        {
            var user = _unitOfWork.Users.GetById(userId);
            if (user.IsDelete == true)
            {
                user.IsDelete = false;
                _unitOfWork.Complete();
                return user;
            }
            else return null;
            
        }
        public IEnumerable GetUser(bool isDelete = false)
        {
            var getUser = _unitOfWork.Users.GetAll();
            var filter = getUser.Where(c => c.IsDelete == isDelete);
            return filter;
        }

    }
}
