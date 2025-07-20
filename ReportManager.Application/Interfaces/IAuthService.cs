using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;

namespace ReportManager.Application.Interfaces
{
    public class IAuthService
    {
        string GenerateToken(string username);
        Task<bool> ValidateUserLogin(LoginDto loginDto);
    }
}
