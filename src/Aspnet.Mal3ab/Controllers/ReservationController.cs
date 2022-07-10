using AspnetRun.Application.Interfaces;
using AspnetRun.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspnet.Mal3ab.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICourtService _courtService;
        private readonly IReservationService _reservationService;
        public ReservationController(ICourtService courtService, IReservationService reservationService)
        {
            _courtService = courtService;
            _reservationService = reservationService;
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
            //reservation.Court = court;
            reservation.CourtId = court.Id;
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
