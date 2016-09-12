using MediatR;
using StructureMap.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using testweb.Services;
using testweb.Services.Users;
using testweb.Services.Companies;

namespace testweb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _mediator.SendAsync(new GetCompanyById.Request { Id = id });

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCompany.Request request)
        {
            var result = await _mediator.SendAsync(request);

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditUser(int id)
        {
            var model = await _mediator.SendAsync(new GetUserById.Request { Id = id });

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUser.Request request)
        {
            var result = await _mediator.SendAsync(request);

            return View();
        }
    }
}