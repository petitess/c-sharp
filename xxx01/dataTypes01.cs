//String
string[] name = { "Ann", "Bob", "Carl", "David" };
//Object initalizer. No need for constractor.
Car toyota = new Car() {Make = "Toyota", Model = "Land Cruiser", VIN = "ASD456"};
Car dodge = new Car() { Make = "Dodge", Model = "Charger", VIN = "POI098" };
//Collection initializer
List<Car> list = new List<Car>() {
    new Car {Make = "Toyota", Model = "Land Cruiser", VIN = "ASD456"},
    new Car {Make = "Dodge", Model = "Charger", VIN = "POI098" },
};
