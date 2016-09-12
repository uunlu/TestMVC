using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using FluentValidation;
using testweb.Models;

namespace testweb.Services.Companies
{
    public class CreateCompany
    {
        public class Request : IAsyncRequest<Response>
        {
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Street { get; set; }
            public string Streetnumber { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public int CompanyType { get; set; }
        }

        public class Response : BaseResponse
        {

        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.CompanyId).NotEmpty();
                RuleFor(x => x.Street).NotEmpty();
                RuleFor(x => x.Streetnumber).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Zip).NotEmpty();
                RuleFor(x => x.CompanyType).NotEmpty();
            }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            private IEntityService _entity;
            public Handler(IEntityService entity)
            {
                _entity = entity;
            }

            public async Task<Response> Handle(Request message)
            {
                var customer = new Company()
                {
                    Name = message.Name,
                    City = message.City,
                    CompanyId = message.CompanyId,
                    CompanyType = message.CompanyType,
                    Description = message.Description,
                    Street = message.Street,
                    Streetnumber = message.Streetnumber,
                    Zip = message.Zip
                };

                try
                {
                    await _entity.InsertAsync(customer);
                    return new Response { Message = "Euccessfully created" };
                }
                catch(Exception e)
                {
                    return new Response { Error = $"Error: {e.Message} - Operation not completed" };
                }
            }
        }
    }
}