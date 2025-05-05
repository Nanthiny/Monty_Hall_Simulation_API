using MontyHall.Core.DTOs;
using MontyHall.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Service.Services
{
	/// <summary>
	/// concrete implementaion of IMontySimulationRepo
	/// </summary>
	public class MontySimulationRepo : IMontySimulationRepo
	{
		public MontySimulationRepo()
		{

		}
		/// <summary>
		/// method implemenation of CalculateSimulationResult
		/// calculate possibility of winning among number of simulations
		/// </summary>
		/// <param name="simulation"></param>
		/// <returns>SimulationRequest</returns>
		public async Task<SimulationResponse> CalculateSimulationResult(SimulationRequest simulation)
		{
			//initialize list of tasks
			List<Task<int>> tasks = new List<Task<int>>();
			//add operation into tasks
			for (int i = 0; i < simulation.NumberOfSimulations; i++)
			{
				tasks.Add(Task.Run(() => GetWinCount(simulation)));
			}
			//get result from tasks execution
			int[] results = await Task.WhenAll(tasks);
			//get sum of all result of each simulation
			var wins=results.Sum();
			//initialize list to assign resposes
			List<GameWinningResponse> responses = new List<GameWinningResponse>
			{ new GameWinningResponse { Label = "Chances to win", Value = wins },
				new GameWinningResponse { Label = "Chances to loose", Value = simulation.NumberOfSimulations - wins
				} };
			return new SimulationResponse { NumberOfSimulations = simulation.NumberOfSimulations, GameWinningResponses = responses, WinningPercentage = (Math.Round((wins / (double)simulation.NumberOfSimulations) * 100, 2)) };
		}
		/// <summary>
		/// get random choice will be chance to win or loose
		/// </summary>
		/// <param name="simulation"></param>
		/// <returns></returns>
		private int GetWinCount(SimulationRequest simulation)
		{
			//initialize variable to store winning chances
			int wins = 0;
			//initialize random object 
			var rand = new Random();
			//get list of door numbers
			List<int> doorNumbers = GetDoorNumbers(3);
			//randomly set door number which contains car from 1 to 3				
			int carDoorNumber = rand.Next(1, 4);
			//randomly set door number to gamer as initial choice car from 1 to 3
			int gamerChoice = rand.Next(1, 4);
			//find door number which not gamer choice and not the door which contains car
			int presenterChoice = doorNumbers.First(d => d != carDoorNumber && d != gamerChoice);
			//check if user prefer to switch door or not 
			if (simulation.IsSwitched)
			{
				//if user prefer to switch door, need to set gamer choice as not the one presenter choosed and initially gamer choosed-that will be latest gamer's choice
				gamerChoice = doorNumbers.First(d => d != gamerChoice && d != presenterChoice);
			}
			//if gamer's choice is the door number which contains the car, then gamer is winner. winning chance increased by 1
			if (gamerChoice == carDoorNumber)
			{
				wins++;
			}
			return wins;
		}
		/// <summary>
		/// create and return list of door numbers
		/// </summary>
		/// <param name="totalDoors"></param>
		/// <returns></returns>
		private List<int> GetDoorNumbers(int totalDoors)
		{
			//create a list of doors
			List<int> doors = new List<int>();
			for (int i = 1; i <= totalDoors; i++)
			{
				doors.Add(i);
			}
			return doors;
		}

	}
}
