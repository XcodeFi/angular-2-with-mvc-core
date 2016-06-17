using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GreetingCard.Infrastructure.Repositories.Abstract;
using GreetingCard.Infrastructure.Core;
using GreetingCard.Models.CategoryViewModels;
using GreetingCard.Entities;

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

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{page:int=0}/{pageSize=12}")]
        public async Task<IActionResult> Get(int? page, int? pageSize)
        {
            PaginationSet<CategoryViewModel> pagedSet = new PaginationSet<CategoryViewModel>();

            try
            {
                if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                {
                    int currentPage = page.Value;
                    int currentPageSize = pageSize.Value;

                    IEnumerable<Category> _cates = null;
                    int _totalCates = new int();

                    _cates = _cateRepository
                        .AllIncluding(a => a.Cards)
                        .OrderBy(a => a.Id)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize);

                    _totalCates = _cateRepository.GetAll().Count();

                    //IEnumerable<CategoryViewModel> _albumsVM = Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumViewModel>>(_albums);

                    pagedSet = new PaginationSet<Category>()
                    {
                        Page = currentPage,
                        TotalCount = _totalCates,
                        TotalPages = (int)Math.Ceiling((decimal)_totalCates / currentPageSize),
                        Items = _cates
                    };
                }
                else
                {
                    CodeResultStatus _codeResult = new CodeResultStatus(401);
                    return new ObjectResult(_codeResult);
                }
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            return new ObjectResult(pagedSet);
        }


    }
}
