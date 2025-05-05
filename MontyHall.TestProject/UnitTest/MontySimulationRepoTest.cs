using MontyHall.Core.DTOs;
using MontyHall.Service.Interfaces;
using MontyHall.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.TestProject.UnitTest
{
	public class MontySimulationRepoTest
	{
		private IMontySimulationRepo _montyHallRepo = new MontySimulationRepo();
		public MontySimulationRepoTest()
		{

		}
		/// <summary>
		/// test case for switch doors for large number of simulation as per law of large numbers-- result should be around 2/3 ratio
		/// </summary>
		[Fact]
		public async Task SwitchDoorCase__WinningpercentageRange60To69()
		{
			// Arrange
			var simulation = new SimulationRequest
			{
				NumberOfSimulations = 1000,
				IsSwitched = true //switch the door
			};
			// Act
			var result =await _montyHallRepo.CalculateSimulationResult(simulation);
			// Assert			
			Assert.InRange(result.WinningPercentage, 60.00, 69.00);

		}

		/// <summary>
		/// test case for not switch doors for large number of simulation as per law of large numbers-result should be around 1/3 ratio
		/// </summary>
		[Fact]
		public async Task NotSwitchDoorCase_WinningpercentageRange30To39()
		{
			// Arrange
			var simulation = new SimulationRequest
			{
				NumberOfSimulations = 1000,
				IsSwitched = false //stay with the initial choice
			};
			// Act
			var result = await _montyHallRepo.CalculateSimulationResult(simulation);
			// Assert			
			Assert.InRange(result.WinningPercentage, 30.00, 39.00);

		}
	}
}
