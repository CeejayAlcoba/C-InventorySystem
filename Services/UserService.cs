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



        public void UpdateUsername(User user, int Id)
        {
            var userId = _unitOfWork.Users.GetById(Id);
            userId.Username = user.Username;
            userId.Firstname = user.Firstname;
            userId.Lastname = user.Lastname;
            _unitOfWork.Complete();
        }
        public void DeleteUser(int userId)
        {
            var getUserId = _unitOfWork.Users.GetById(userId);
            _unitOfWork.Users.Remove(getUserId);
            _unitOfWork.Complete();
        }

    }
}
