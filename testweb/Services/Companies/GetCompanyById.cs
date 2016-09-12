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
    public class GetCompanyById
    {
        public class Request : IAsyncRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response : BaseResponse
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

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
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
                var company = await _entity.GetById<Company>(message.Id.ToString());

                return new Response
                {
                    CompanyId = company.CompanyId,
                    Name = company.Name,
                    Description = company.Description,
                    Street = company.Street,
                    Streetnumber = company.Streetnumber,
                    City = company.City,
                    Zip = company.Zip,
                    CompanyType = company.CompanyType
                };
            }
        }
    }
}