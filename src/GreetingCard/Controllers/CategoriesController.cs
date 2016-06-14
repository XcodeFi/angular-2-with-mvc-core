using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GreetingCard.Infrastructure.Repositories.Abstract;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GreetingCard.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        ICateRepository _cateRepository;
        ILoggingRepository _loggingRepository;
        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="authorizationService"></param>
        /// <param name="cateRepository"></param>
        /// <param name="loggingRepository"></param>
        public CategoriesController(IAuthorizationService authorizationService,
                             ICateRepository cateRepository,
                             ILoggingRepository loggingRepository)
        {
            _authorizationService = authorizationService;
            _cateRepository = cateRepository;
            _loggingRepository = loggingRepository;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
