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
        private readonly IWorkingHoursService _workingHoursService;
        private readonly ICourtTypeService _courtTypeService;

        public CourtsController(ICourtService courtService, IWorkingHoursService workingHoursService, ICourtTypeService courtTypeService)
        {
            _courtService = courtService;
            _workingHoursService = workingHoursService;
            _courtTypeService = courtTypeService;
        }


        // GET: CourtsController
        public async Task<ActionResult> Index()
        {
            var courts = _courtService.GetAllCourts(User.GetUserId().Value);
            return View(courts);
        }

        // GET: CourtsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var coutDetails = await _courtService.GetCourt(id, User.GetUserId().Value);
            coutDetails.CourtType = await _courtTypeService.GetCourtTypById(id);
            return View(coutDetails);
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
                if (ModelState.IsValid)
                {

                    var userId = User.GetUserId();
                    courtDto.UserId = userId.Value;
                    await _courtService.Add(courtDto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return View(courtDto);
                }
            }
            catch (Exception e)
            {
                return View(courtDto);
            }

        }

        // GET: CourtsController/Create
        public async Task<ActionResult> AddWorkingHours(int Id)
        {
            //Id Represent The Court Id
            var court = _courtService.GetAllCourts(User.GetUserId().Value)?.FirstOrDefault(c => c.Id == Id);

            if (court is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var workingHours = await _workingHoursService.GetAsync(Id);
            ViewBag.CourtId = Id;

            return View(workingHours);
        }

        // POST: CourtsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddWorkingHours(WorkinghourDto workingHourDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (workingHourDto.AllDays)
                    {
                        workingHourDto.FromDay = null;
                        workingHourDto.ToDay = null;
                    }
                    if (workingHourDto.AllTimes)
                    {
                        workingHourDto.FromTime = null;
                        workingHourDto.ToTime = null;
                    }
                    var result = workingHourDto.Id is null ? await _workingHoursService.AddAsync(workingHourDto, User.GetUserId().Value) : await _workingHoursService.EditAsync(workingHourDto, User.GetUserId().Value);
                    if (result is null)
                    {
                        return View();
                    }
                    return RedirectToAction(nameof(Details), result.CourtId);
                }
            }
            catch (Exception e)
            {
                return View(workingHourDto);
            }
            return View(workingHourDto);
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
