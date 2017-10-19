namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    public class Vehicle
    {
        /// <summary>
        /// Vehicle identifier.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Defines profile of vehicle and adjusts the routing accordingly.<br/>
        /// Values: car|truck|heavytruck<br/>
        /// Default: car
        /// </summary>
        public string Profile { get; set; } = "car";

        /// <summary>
        /// Fixed cost when vehicle is in use.<br/>
        /// Default: 100
        /// </summary>
        public double FixedCost { get; set; } = 100;

        /// <summary>
        /// Cost per km.<br/>
        /// Default: 1
        /// </summary>
        public double CostPerKm { get; set; } = 1;

        /// <summary>
        /// Cost per hour.<br/>
        /// Default: 0
        /// </summary>
        public double CostPerHour { get; set; } = 0;


        /// <summary>
        /// Vehicle pickup location.
        /// </summary>
        public string StartLocationId { get; set; }

        /// <summary>
        /// Vehicle return location.
        /// </summary>
        public string EndLocationId { get; set; }

        /// <summary>
        /// Maximum capacity of transported items in any given time.<br/>
        /// Default: &lt;no limit&gt;
        /// </summary>
        public uint[] MaxCapacity { get; set; }

        /// <summary>
        /// Earliest/latest time when the vehicle is available for service.<br/>
        /// Default: &lt;no limit&gt;
        /// </summary>
        public Availability Availability { get; set; }
    }
}