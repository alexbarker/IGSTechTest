using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using IGSTechTest.Cache;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
//using IGSTechTest.Contracts.V1.Requests.Queries;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
//using IGSTechTest.Extensions;
//using IGSTechTest.Helpers;
using IGSTechTest.Services;

namespace IGSTechTest.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
