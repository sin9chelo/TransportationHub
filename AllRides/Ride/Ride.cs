using System;
using TransportationHub.Vehicles;

namespace TransportationHub.AllRides.Ride
{
    public class Ride
    {
        private Vehicle vehicle;
        private int amountOfPersons;
        private int volumeOfTheCargo;
        private int weightOfTheCargo;
        private double priceOfTheRide;
        private double startingPrice = 0;
        private double kilometres;
        private DateTime startingTime;
        private DateTime endingTime;
        public Vehicle Vehicle { get => this.vehicle; set => this.vehicle = value; }
        public int AmountOfPersons { get => this.amountOfPersons; set => this.amountOfPersons = value; }
        public int VolumeOfTheCargo { get => this.volumeOfTheCargo; set => this.volumeOfTheCargo = value; }
        public int WeightOdTheCargo { get => this.weightOfTheCargo; set => this.weightOfTheCargo = value; }
        public double PriceOfTheRide { get => this.priceOfTheRide; set => this.priceOfTheRide = value; }
        public double StartingPrice { get => this.startingPrice; set => this.startingPrice = value; }

        public double Kilometres { get => this.kilometres; set => this.kilometres = value; }
        public DateTime StartingTime { get => this.startingTime; set => this.startingTime = value; }
        public DateTime EndingTime { get => this.endingTime; set => this.endingTime = value; }

        public Ride()
        {

        }

        public Ride(FreighterTransport freighter, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = freighter;
            this.Kilometres = kilometres;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
        public Ride(PassangerTransport passanger, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = passanger;
            this.Kilometres = kilometres;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
        public Ride(PassangerTransport passanger, double startingPrice, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = passanger;
            this.Kilometres = kilometres;
            this.StartingPrice = startingPrice;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
        public Ride(FreighterTransport freighter, double startingPrice, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = freighter;
            this.Kilometres = kilometres;
            this.StartingPrice = startingPrice;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
        public Ride(PassangerTransport passanger, int amountOfPersons, double startingPrice, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = passanger;
            this.AmountOfPersons = amountOfPersons;
            this.Kilometres = kilometres;
            this.StartingPrice = startingPrice;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
        public Ride(FreighterTransport freighter, int volumeOfTheCargo, int weightOfTheCargo, double startingPrice, double kilometres, DateTime startingTime, DateTime endingTime)
        {
            this.Vehicle = freighter;
            this.VolumeOfTheCargo = volumeOfTheCargo;
            this.WeightOdTheCargo = weightOfTheCargo;
            this.Kilometres = kilometres;
            this.StartingPrice = startingPrice;
            this.PriceOfTheRide = Vehicle.PricePerKm * Kilometres + StartingPrice;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
        }
    }
}
