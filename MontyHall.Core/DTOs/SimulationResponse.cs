using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Core.DTOs
{
	public class SimulationResponse
	{
		public int NumberOfSimulations { get; set; }
		public List<GameWinningResponse> GameWinningResponses { get; set; }
		public double WinningPercentage { get; set; }

	}
	public class GameWinningResponse
	{
		public string Label { get; set; }
		public double Value { get; set; }

	}
}
