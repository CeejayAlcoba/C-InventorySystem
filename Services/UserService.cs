using Domain.Entities;
using Domain.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Services.Contructs;
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
        public UserService(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        public void AddUser(string firstname,string lastname,string username, string password)
        {
            var salt = _accountService.GenerateSalt(password);
            var hashedPassword = _accountService.GenerateHashPassword(password, salt);
            var user = new User
            {
                Firstname=firstname,
                Lastname = lastname,
                Username = username,
                HashPassword = hashedPassword,
                Salt = salt
            };

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        
        
    }
}
