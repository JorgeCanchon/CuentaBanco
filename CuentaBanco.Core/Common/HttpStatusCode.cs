﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Common
{
    public enum HttpStatusCode
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NotContent = 204,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }
}
