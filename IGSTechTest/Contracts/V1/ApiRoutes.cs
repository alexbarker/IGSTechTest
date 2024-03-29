﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGSTechTest.Contracts.V1
{
    public static class ApiRoutes
    {
        //public const string Root = "api";
        //public const string Version = "v1";
        public const string Base = "v1";
        public static class Products
        {
            public const string GetAll = Base + "/products";

            public const string Update = Base + "/product/{productId}";

            public const string Get = Base + "/product/{productId}";

            public const string Delete = Base + "/product/{productId}";

            public const string Create = Base + "/product";

        }
    }
}
