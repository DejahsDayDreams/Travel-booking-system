using System;

class TravelBookings
{
    public string Location { get; set; }
    public string Currency { get; set; }
    public double ExchangeRate { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Set console colors
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear(); //removes the console's default color

        // Locations array
        string[] locations = { "New York", "Canberra", "Tokyo", "London", "Moscow" };

        // Currencies array
        string[] currencies = { "USD", "AUD", "JPY", "GBP", "RUB" };

        // Conversion rates array
        double[] conversionRates = { 16.00, 12.00, 0.14, 21.65, 0.21 };

        // Vehicle array
        string[] cars = { "Renault Kwid", "Volkswagen Polo Vivo", "Toyota Corolla Quest", "Volkswagen T-Roc", "BMW 3 Series" };

        // Vehicle costs array
        double[] carCosts = { 100.00, 120.00, 150.00, 300.00, 380.00 };

        // Hotels array
        string[] hotels = { "1 Star", "2 Star", "3 Star", "4 Star", "5 Star" };

        // Hotel costs array
        double[] hotelCosts = { 200.00, 300.00, 400.00, 500.00, 600.00 };

        // Create an array to store the TravelBookings objects
        TravelBookings[] travelBookings = new TravelBookings[locations.Length];

        // Populate the travelBookings array
        for (int i = 0; i < locations.Length; i++)
        {
            travelBookings[i] = new TravelBookings
            {
                Location = locations[i],
                Currency = currencies[i],
                ExchangeRate = conversionRates[i]
            };
        }

        while (true)
        {
            Console.WriteLine("  Welcome to Travelstart!!!!\n");

            // Display the location choices
            Console.WriteLine("  Please select an option below:");
            Console.WriteLine("  0. Exit");
            for (int i = 0; i < locations.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {locations[i]}");
            }

            // Prompt the user to select the location
            int locationIndex;
            while (true)
            {
                Console.Write("  Enter the number of your chosen location: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("  Exiting the program...");
                    return;
                }
                if (!int.TryParse(input, out locationIndex) || locationIndex < 1 || locationIndex > locations.Length)
                {
                    Console.WriteLine("  Invalid input. Please try again.");
                }
                else
                {
                    break;
                }
            }

            TravelBookings selectedOption = travelBookings[locationIndex - 1];

            // Access the selected option's properties
            string selectedLocation = selectedOption.Location;
            string selectedCurrency = selectedOption.Currency;
            double conversionRate = selectedOption.ExchangeRate;

            // Display the car choices
            Console.WriteLine("\n  Please select an option below:");
            Console.WriteLine("  0. Exit");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {cars[i]}");
            }

            // Prompt the user to select the hired vehicle
            int carIndex;
            while (true)
            {
                Console.Write("  Enter the number of your chosen hired vehicle: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("  Exiting the program...");
                    return;
                }
                if (!int.TryParse(input, out carIndex) || carIndex < 1 || carIndex > cars.Length)
                {
                    Console.WriteLine("  Invalid input. Please try again.");
                }
                else
                {
                    break;
                }
            }

            string selectedCar = cars[carIndex - 1];
            double selectedCarCost = carCosts[carIndex - 1];

            // Display the hotel choices
            Console.WriteLine("\n  Please select an option below:");
            Console.WriteLine("  0. Exit");
            for (int i = 0; i < hotels.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {hotels[i]}");
            }

            // Prompt the user to select the hotel
            int hotelIndex;
            while (true)
            {
                Console.Write("  Enter the number of your chosen hotel: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("  Exiting the program...");
                    return;
                }
                if (!int.TryParse(input, out hotelIndex) || hotelIndex < 1 || hotelIndex > hotels.Length)
                {
                    Console.WriteLine("  Invalid input. Please try again.");
                }
                else
                {
                    break;
                }
            }

            string selectedHotel = hotels[hotelIndex - 1];
            double selectedHotelCost = hotelCosts[hotelIndex - 1];

            // Calculate the total cost in the chosen currency
            double flightCostInCurrency = 200;
            double carCostInCurrency = selectedCarCost;
            double hotelCostInCurrency = selectedHotelCost;
            double totalCostInCurrency = flightCostInCurrency + carCostInCurrency + hotelCostInCurrency;

            // Convert the costs to ZAR (South African Rand)
            double flightCostInZAR = flightCostInCurrency * conversionRate;
            double carCostInZAR = carCostInCurrency * conversionRate;
            double hotelCostInZAR = hotelCostInCurrency * conversionRate;
            double totalCostInZAR = totalCostInCurrency * conversionRate;

            // Display the costs in the chosen currency and ZAR
            Console.WriteLine();
            Console.Write("  Your travel details:");
            Console.WriteLine();
            Console.WriteLine($"  You have selected {selectedLocation} as your location of choice at a cost of R{flightCostInZAR.ToString("F2")}.");
            Console.WriteLine($"  You have selected a {selectedCar} at the cost of R{carCostInZAR.ToString("F2")}.");
            Console.WriteLine($"  You have selected a {selectedHotel} hotel at the cost of R{hotelCostInZAR.ToString("F2")}.");
            Console.WriteLine($"  Your total cost will be R{totalCostInZAR.ToString("F2")}.\n");

            // Prompt for confirmation
            Console.Write("\n  Confirm your trip (Yes/No): ");
            string confirmation = Console.ReadLine();

            if (confirmation.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("  Congratulations on traveling with Travelstart. Enjoy your holiday!!!");
                break;
            }
            else if (confirmation.Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("  That is a shame. Please try again.\n");
            }
            else
            {
                Console.WriteLine("  Invalid input. Please try again.\n");
            }

            // Close the program
            Environment.Exit(0);
        }
    }
}
