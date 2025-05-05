using MontyHall.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Service.Interfaces
{
	public interface IMontySimulationRepo
	{
		/// <summary>
		/// calculate and return the simulation result of the game 
		/// </summary>
		/// <param name="numberOfSimulations"></param>
		/// <param name="isSwitch"></param>
		/// <returns></returns>		
		Task<SimulationResponse> CalculateSimulationResult(SimulationRequest simulation);
	}
}
