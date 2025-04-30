using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain.entites.identity;
using Microsoft.AspNetCore.Identity;
using services.abstractions;
using shared.identitydtos;

namespace services
{
    public class authenticationservice(UserManager<user> usermanager, IMapper mapper) : Iauthenticationservice
    {

        public async Task<userresultdto> login(logindto userlogindto)
        {
            var user = await usermanager.FindByEmailAsync(userlogindto.email);
            if (user is null)
                throw new Exception("user not found");
            var result = await usermanager.CheckPasswordAsync(user, userlogindto.password);
            if (!result)
                throw new Exception("password is incorrect");
            return new userresultdto
            (
                user.DisplayName,
                user.Email,
                "token"
            );
        }

        public async Task<userresultdto> register(registerdto userregisterdto)
        {
            var user = new user {
                DisplayName = userregisterdto.displayname,
                Email = userregisterdto.email,
                UserName = userregisterdto.username,
                PhoneNumber = userregisterdto.phonenumber
            };
            var result =await usermanager.CreateAsync(user, userregisterdto.password);
            if(!result.Succeeded)
            {
                throw new Exception("problem registering user");
            }
            return new userresultdto
            (
                user.DisplayName,
                user.Email,
                "token"
            );

        }
    }
}
