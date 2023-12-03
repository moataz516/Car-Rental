using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using System.Globalization;
using AutoMapper;
using CarRental.Services.CarSer;
using CarRental.Services.Reservation;
using Newtonsoft.Json;
using Newtonsoft;


namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationCarService _resService;



        public ReservationsController(IReservationCarService resService)
        {
            _resService = resService;
        }


        [HttpPost("AvailableCar")]
        public async Task<IActionResult> CarSearchAsync([FromBody] CarSearchDto model)
        {
            if(!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var data = await _resService.GetAvailableCars(model);
            if(data is null || !data.Any())
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("isCarAvailable")]
        public async Task<IActionResult> IsCarAvailableAsync([FromBody] CarSearchDto model)
        {
            bool data = await  _resService.IsCarAvailable(model);
            
            return data ? Ok(data) : BadRequest("The Car is Reserved in this period of time ");
            
        }

        [HttpPost("makeReservation")]
        public async Task<ActionResult> MakeReservation(ReservationAndPaymentDto model)
        {
            try
            {
               bool data =  await this._resService.MakeReservation(model);
                if (!data)
                    return BadRequest("Something Wrong, please try again!");
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest("An error occurred: " + ex.Message);

            }
        }


        [HttpPost("checkReservationReference")]
        public async Task<ActionResult> CheckReservationByRefAsync([FromBody] ReservationByRefForm model)
        {
            bool data = await _resService.CheckReservationByReferenceID(model);
            if (!data)
                return BadRequest("Reservation Not Found");
            return Ok(data);
        }

        [HttpGet("getReservationReference/{id}")]
        public async Task<ActionResult> GetReservationByRefAsync(string id)
        {
            var data = await _resService.GetReservationByReferenceID(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }



        [HttpGet("GetOwnerReservation/{id}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetCarOwnerReservation(string id)
        {
            var data = await _resService.GetReservationByUser(id);
            if(data is null)
            {
                return NoContent();
            }
            
            return Ok(data);
        }


        [HttpPost("ChangeReservationStatus")]
        public async Task<bool> ChangeReservationStatus([FromBody]RStatusDto model)
        {
            await _resService.ChangeReservationStatus(model);
            return true;
        }

        [HttpDelete("deleteReservation/{id}")]
        public async Task<ActionResult> DeleteReservationAsync(string id) {

            bool resDeleted = await _resService.DeleteReservation(id);
            if (!resDeleted)
                return BadRequest("SomeThing went wrong!");
            return NoContent();
        }


    }
}
