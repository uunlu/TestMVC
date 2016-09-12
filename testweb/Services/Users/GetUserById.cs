using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using FluentValidation;
using testweb.Models;

namespace testweb.Services
{
    public class GetUserById
    {
        public class Request : IAsyncRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response : BaseResponse
        {
            public string Name { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Street { get; set; }
            public string Streetnumber { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
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
                var user = await _entity.GetById<User>(message.Id.ToString());

                return new Response
                {
                    Name = user.Name,
                    Login = user.Login,
                    Password = user.Password,
                    Street = user.Street,
                    Streetnumber = user.Streetnumber,
                    City = user.City,
                    Zip = user.Zip,
                };
            }
        }
    }
}