using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using BugCatcher.WebApplication.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugCatcher.UI.Controllers
{
    public class QueryController : BaseController
    {
        private readonly ILogRepository _logRepo;
        private readonly IQueryRepository _queryRepository;
        private readonly UserManager<UserEntity> _userRepository;

        public QueryController(IQueryRepository queryRepository,ILogRepository logRepo, UserManager<UserEntity> userRepository) :base(userRepository)
        {
            _logRepo = logRepo;
            _queryRepository = queryRepository;
            _userRepository = userRepository;
        }

        public IActionResult QueryList()
        {
            var queries = _queryRepository.GetList(x => x.IsActive == true);

            return View(queries);
        }

        public IActionResult NewQuery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewQuery(QueryEntity queryEntity)
        {
            try
            {
                ModelState.Remove("Id");

                if (ModelState.IsValid)
                {
                    const string sql = @"SELECT * FROM ITEM ";

                    queryEntity.Query.RemoveSqlTags();
                    queryEntity.Query = sql + queryEntity.Query;
                    queryEntity.CreUser = await CurrentUser;

                    _queryRepository.Add(queryEntity);
                    return RedirectToAction("EditQuery", new { id = queryEntity.Id });
                }
                else
                    return View();
            }
            catch (System.Exception ex)
            {
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return View();
            }
        }

        public IActionResult EditQuery(int id)
        {
            var ent = _queryRepository.Get(x => x.Id == id);

            if (ent != null)
                return View(ent);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EditQuery(QueryEntity queryEntity)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                queryEntity.ModUser =(await CurrentUser).UserName;
                _queryRepository.Update(queryEntity);
                return RedirectToAction("QueryList");
            }
            else
                return View(queryEntity);
        }

        public ActionResult Delete(int id)
        {
            var ent = _queryRepository.Get(x=>x.Id==id);

            if (ent != null)
            {
                _queryRepository.Delete(ent);
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }
    }
}