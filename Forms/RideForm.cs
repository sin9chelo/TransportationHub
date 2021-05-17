using System;
using System.Windows.Forms;
using TransportationHub.AllRides.Ride;
using TransportationHub.Vehicles;

namespace TransportationHub.Forms
{
    public partial class RideForm : Form
    {
        MainForm mainForm;


        protected string LicensePlate;
        protected double StartingPrice;
        protected int AmountOfPersons;
        protected double VolumeOfTheCargo;
        protected double WeightOfTheCargo;
        protected double Kilometres;
        protected int EndTime;

        Ride ride = new Ride();
        public RideForm()
        {
            InitializeComponent();
        }
        public RideForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;

            /*var PassangersVehicles = mainForm.rides.Vehicles.Where(t => t.Type.Equals("Car") || (t.Type.Equals("Van") && t.subType.Equals("Passanger")));
            var FreighterVehicles = mainForm.rides.Vehicles.Where(t => t.Type.Equals("Truck") || (t.Type.Equals("Van") && t.subType.Equals("Freighter")));

            List<Vehicle> passVehicles = new List<Vehicle>();
            passVehicles = PassangersVehicles.ToList();

            List<Vehicle> freightVehicles = new List<Vehicle>();
            freightVehicles = FreighterVehicles.ToList();*/


            foreach (Vehicle vehicle in mainForm.rides.Vehicles)
            {
                VehiclesListBox.Items.Add(vehicle.LicensePlate);
            }
        }

        private void AmountPassangerValue_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.AmountOfPersons = Convert.ToInt32(AmountPassangerValue.Text);
            }
            catch
            {

            }
        }

        private void VehiclesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.LicensePlate = VehiclesListBox.SelectedItem.ToString();
            }
            catch
            {

            }
        }

        private void StartingPriceValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.StartingPrice = Convert.ToDouble(StartingPriceValue.Text);
            }
            catch
            {

            }
        }

        private void KilometresValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Kilometres = Convert.ToDouble(KilometresValue.Text);
            }
            catch
            {

            }
        }

        private void VolumeValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.VolumeOfTheCargo = Convert.ToDouble(VolumeValue.Text);
            }
            catch
            {

            }
        }

        private void WeightValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.WeightOfTheCargo = Convert.ToDouble(WeightValue.Text);
            }
            catch
            {

            }
        }
        private void EndTimeValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.EndTime = Convert.ToInt32(EndTimeValue.Text);
            }
            catch
            {

            }
        }

        private void RegisterRide_Click(object sender, EventArgs e)
        {
            if (mainForm.rides.Vehicles.Count == 0)
                MessageBox.Show("There are no one vehicle available at this momemt");
            else
            {
                Vehicle vehicleToRemove = mainForm.rides.Vehicles[0];
                foreach (Vehicle vehicle in mainForm.rides.Vehicles)
                    if (LicensePlate.Equals(vehicle.LicensePlate))
                    {
                        if (vehicle.GetType().Name.Equals("FreighterTransport") && (vehicle.Type.Equals("Truck") || vehicle.Type.Equals("Van") && vehicle.subType.Equals("Freighter")))
                        {
                            FreighterTransport freighter = (FreighterTransport)vehicle;
                            if (freighter.MaximumVolume < this.VolumeOfTheCargo)
                                MessageBox.Show("You can't choose this vehicle(volume or weight of the cargo too big for this vehicle");
                            else
                            {
                                vehicleToRemove = vehicle;
                                ride = new Ride((FreighterTransport)vehicle, this.StartingPrice, this.Kilometres, DateTime.Now, DateTime.Now);
                                mainForm.rides.AllRides.Add(ride);
                                mainForm.rides.VehiclesOnRide.Add(vehicle);
                                VehiclesListBox.Items.Remove(vehicle.LicensePlate);
                                MessageBox.Show("Currently on ride");
                            }

                        }
                        else if (vehicle.GetType().Name.Equals("PassangerTransport") && (vehicle.Type.Equals("Car") || vehicle.Type.Equals("Van") && vehicle.subType.Equals("Passanger")))
                        {
                            PassangerTransport passanger = (PassangerTransport)vehicle;
                            if (passanger.MaximumPassangers < this.AmountOfPersons)
                                MessageBox.Show("You can't choose this vehicle(amount of passangers too big for this vehicle");
                            else
                            {
                                vehicleToRemove = vehicle;
                                ride = new Ride((PassangerTransport)vehicle, this.StartingPrice, this.Kilometres, DateTime.Now, DateTime.Now);
                                mainForm.rides.AllRides.Add(ride);
                                mainForm.rides.VehiclesOnRide.Add(vehicle);
                                VehiclesListBox.Items.Remove(vehicle.LicensePlate);
                                MessageBox.Show("Currently on ride");
                            }
                        }
                   

                    }
                mainForm.rides.Vehicles.Remove(vehicleToRemove);
            }

        }

        private void FinishRideButton_Click(object sender, EventArgs e)
        {
            mainForm.rides.AllRides.Remove(ride);
            ride.EndingTime = DateTime.Now;
            VehiclesListBox.Items.Add(ride.Vehicle.LicensePlate);
            mainForm.rides.CompletedRides.Add(ride);
            MessageBox.Show("Ride end");
        }
    }
}
