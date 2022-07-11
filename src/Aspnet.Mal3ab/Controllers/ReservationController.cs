using AspnetRun.Application.Interfaces;
using AspnetRun.Shared.Dtos;
using AspnetRun.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspnet.Mal3ab.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICourtService _courtService;
        private readonly IReservationService _reservationService;
        private readonly IWorkingHoursService _workingHoursService;
        public ReservationController(ICourtService courtService, IReservationService reservationService, IWorkingHoursService workingHoursService)
        {
            _courtService = courtService;
            _reservationService = reservationService;
            _workingHoursService = workingHoursService;
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ReservationController/Create
        public async Task<ActionResult> Create(int Id)
        {
            var court = await _courtService.GetCourt(Id, null);
            if (court == null)
            {
                return NotFound();
            }
            var reservation = new ReservationDto();
            reservation.Court = court;
            reservation.CourtId = court.Id;
            ViewBag.BookingTimes = (await _reservationService.Get(DateTime.Now)).Select(t => t.From.ToString("HH:mm").Trim());
            var wInfo = await _workingHoursService.GetAsync(Id);
            if (wInfo.FromDay != null && wInfo.ToDay != null)
            {
                var minVal = Math.Min((int)wInfo.FromDay.Value, (int)wInfo.ToDay.Value);
                wInfo.ToDay = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), Math.Max((int)wInfo.FromDay.Value, (int)wInfo.ToDay.Value));
                wInfo.FromDay = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), minVal);
            }
            ViewBag.WrokingInfo = wInfo;
            return View(reservation);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationDto reservationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reservationDto.Id = null;
                    await _reservationService.Add(reservationDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(reservationDto);
            }
            catch (Exception ms)
            {
                return View(reservationDto);
            }

        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
