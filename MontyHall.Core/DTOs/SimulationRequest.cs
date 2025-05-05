using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Core.DTOs
{
	public class SimulationRequest
	{
		public int NumberOfSimulations { get; set; }
		public bool IsSwitched { get; set; }
	}
}
