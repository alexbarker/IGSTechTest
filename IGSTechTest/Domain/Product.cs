using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
using IGSTechTest.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGSTechTest.Domain
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
