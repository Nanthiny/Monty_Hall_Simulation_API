using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MontyHall.Core.DTOs;
using MontyHall.Service.Interfaces;

namespace MontyHall.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MontyHallController : ControllerBase
	{
		private readonly IMontySimulationRepo _montyHallRepo;
		public MontyHallController(IMontySimulationRepo montyHallRepo)
		{
			_montyHallRepo = montyHallRepo;
		}
		/// <summary>
		/// get winning/loosing chances of the game 
		/// </summary>
		/// <param name="simulation"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> GetSimulationResult([FromBody] SimulationRequest simulation)
		{
			try
			{
				//get and return simulations result
				return Ok(await _montyHallRepo.CalculateSimulationResult(simulation));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
