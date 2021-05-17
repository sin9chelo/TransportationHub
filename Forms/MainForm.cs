using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TransportationHub.AllRides;
using TransportationHub.AllRides.Ride;
using TransportationHub.Vehicles;

namespace TransportationHub.Forms
{
    public partial class MainForm : Form
    {
        public Rides rides = new Rides();
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddNewVehicleButton_Click(object sender, EventArgs e)
        {
            NewVehicleForm form = new NewVehicleForm(this);
            form.Show();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            rides.Vehicles = rides.Vehicles.OrderBy(t => t.LicensePlate).ToList();

            rides.AllRides = rides.AllRides.OrderBy(t => t.StartingTime).ToList();
            rides.AllRides = rides.AllRides.OrderBy(t => t.Kilometres).ToList();
        }

        private void PresidentVehicalDataButtonToFile_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Vehicles.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, rides.Vehicles);
                MessageBox.Show("Serialize completed!");
            }

        }

        private void PresidentVehicalDataButtonFromFile_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Vehicles.dat", FileMode.OpenOrCreate))
            {
                rides.Vehicles = (List<Vehicle>)formatter.Deserialize(fs);
                MessageBox.Show("Deserialize completed!");
            }
        }

        private void ModifyVehicleButton_Click(object sender, EventArgs e)
        {
            ModifyForm form = new ModifyForm(this);
            form.Show();
        }

        private void ReserveRideButton_Click(object sender, EventArgs e)
        {
            RideForm form = new RideForm(this);
            form.Show();
        }

        private void InfoAboutRides_Click(object sender, EventArgs e)
        {
            foreach (Ride ride in this.rides.CompletedRides)
            {
                OutTextBox.AppendText("\n---------------------------------------------\n\r\n");
                OutTextBox.AppendText($" Vehicle(LicenseOlate) {ride.Vehicle.LicensePlate}\r\n");
                OutTextBox.AppendText($" Kilometres {ride.Kilometres}\r\n");
                OutTextBox.AppendText($" Starting price {ride.StartingPrice}\r\n");
                OutTextBox.AppendText($" Price of the ride {ride.PriceOfTheRide}\r\n");
                OutTextBox.AppendText($" Starting time {ride.StartingTime}\r\n");
                OutTextBox.AppendText($" Ending time {ride.EndingTime}\r\n");
                OutTextBox.AppendText("\n---------------------------------------------\n\r\n");
            }
        }

        private void InfoAboutRidesToFileButton_Click(object sender, EventArgs e)
        {

            try
            {

                using (StreamWriter sw = new StreamWriter("InfoAnoutRides.txt", false, System.Text.Encoding.Default))
                {
                    foreach (Ride ride in this.rides.CompletedRides)
                    {
                        sw.Write("\n---------------------------------------------\n\r\n");
                        sw.Write($" Vehicle(LicenseOlate) {ride.Vehicle.LicensePlate}\r\n");
                        sw.Write($" Kilometres {ride.Kilometres}\r\n");
                        sw.Write($" Starting price {ride.StartingPrice}\r\n");
                        sw.Write($" Price of the ride {ride.PriceOfTheRide}\r\n");
                        sw.Write($" Starting time {ride.StartingTime}\r\n");
                        sw.Write($" Ending time {ride.EndingTime}\r\n");
                        sw.Write("\n---------------------------------------------\n\r\n");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error during the writig to file");
            }

        }

        private void InfoAboutRidesFromFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("InfoAnoutRides.txt", System.Text.Encoding.Default))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        OutTextBox.AppendText(line + "\r\n");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error during the reading from file");
            }

        }
    }
}
