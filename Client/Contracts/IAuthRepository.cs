﻿using Client.DTOs;
using Client.DTOs.Auths;
using Client.Models;

namespace Client.Contracts
{
    public interface IAuthRepository : IRepository<Account, string>
    {
        public Task<ResponseDto<string>> SignIn(SignInDto loginDto);

        public Task<ResponseDto<SignUpDto>> SignUp(SignUpDto signUpDto);
        public Task<ResponseDto<ForgotPasswordDto>> ForgetPassword(ForgotPasswordDto forgotPasswordDto);
        public Task<ResponseDto<ChangePasswordDto>> ResetPassword(ChangePasswordDto changePasswordDto);
    }
}