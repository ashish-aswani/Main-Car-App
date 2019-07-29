using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
	public class EnumMakeStyleAndServiceType
	{
		public enum EnumMake
		{
			SelectMake,
			Honda,
			Maruti,
			Hyundai,
			Tata
		}

		public enum EnumStyle
		{
			SelectModel,
			Sedan,
			HatchBack,
			Suv,
			Sportz
		}

		public enum EnumServiceType
		{
			FullService,
			AirConditioning,
			Brakes,
			Electrical,
			DiagnosticsAndEngineRepair,
			OilFluidsAndMaintenance,
			TyresSteeringAndSuspension,
			OtherService
		}
	}
}