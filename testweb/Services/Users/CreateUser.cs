using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using FluentValidation;
using testweb.Models;

namespace testweb.Services.Users
{
    public class CreateUser
    {
        public class Request : IAsyncRequest<Response>
        {
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Street { get; set; }
            public string Streetnumber { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
        }

        public class Response : BaseResponse
        {

        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.CompanyId).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Login).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
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
                var user = new User()
                {
                    Name = message.Name,
                    City = message.City,
                    CompanyId = message.CompanyId,
                    Login = message.Login,
                    Password = message.Password,
                    Street = message.Street,
                    Streetnumber = message.Streetnumber,
                    Zip = message.Zip
                };

                try
                {
                    await _entity.InsertAsync(user);
                    return new Response { Message = "Successfully created" };
                }
                catch (Exception e)
                {
                    return new Response { Error = $"Error: {e.Message} - Operation not completed" };
                }
            }
        }
    }
}