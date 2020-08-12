﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTIssueExample.Contracts
{
    public interface IAuthenticationManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateToken(); 
    }
}
