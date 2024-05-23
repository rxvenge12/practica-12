using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace practica_12
{
    public partial class Form1 : Form
    {
        // Создаем классы для данных об автомобилях и производителях
        public class Car
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public int Year { get; set; }
        }

        public class CarManufacturer
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаем списки для данных об автомобилях и производителях
            List<Car> cars = new List<Car>
            {
                new Car { Model = "Camry", Manufacturer = "Toyota", Year = 2020 },
                new Car { Model = "Accord", Manufacturer = "Honda", Year = 2019 },
                new Car { Model = "Civic", Manufacturer = "Honda", Year = 2021 },
                new Car { Model = "Corolla", Manufacturer = "Toyota", Year = 2018 },
                new Car { Model = "CR-V", Manufacturer = "Honda", Year = 2020 },
                new Car { Model = "Rav4", Manufacturer = "Toyota", Year = 2019 },
                new Car { Model = "Fit", Manufacturer = "Honda", Year = 2021 },
                new Car { Model = "Highlander", Manufacturer = "Toyota", Year = 2017 }
            };

            List<CarManufacturer> manufacturers = new List<CarManufacturer>
            {
                new CarManufacturer { Name = "Toyota", Country = "Japan" },
                new CarManufacturer { Name = "Honda", Country = "Japan" },
                new CarManufacturer { Name = "Ford", Country = "USA" },
                new CarManufacturer { Name = "Chevrolet", Country = "USA" }
            };

            // Используем LINQ для выборки данных из двух источников
            var query = from car in cars
                        join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                        select new
                        {
                            Model = car.Model,
                            Year = car.Year,
                            Manufacturer = manufacturer.Name,
                            Country = manufacturer.Country
                        };

            // Привязываем результаты к DataGridView на форме
            dataGridView1.DataSource = query.ToList();
        }
    }
}
