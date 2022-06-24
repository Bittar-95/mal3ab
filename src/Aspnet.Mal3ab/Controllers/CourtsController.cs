using AspnetRun.Application.Interfaces;
using AspnetRun.Shared.Dtos;
using AspnetRun.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Aspnet.Mal3ab.Controllers
{
    [Authorize]
    public class CourtsController : Controller
    {
        private readonly ICourtService _courtService;

        public CourtsController(ICourtService courtService)
        {
            _courtService = courtService;
        }


        // GET: CourtsController
        public async Task<ActionResult> Index()
        {
            var courts =  _courtService.GetAll(User.GetUserId().Value);
            return View(courts);
        }

        // GET: CourtsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourtsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourtDto courtDto)
        {
            try
            {
                var userId = User.GetUserId();
                courtDto.UserId = userId.Value;
                await _courtService.Add(courtDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: CourtsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourtsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
