var nums = Enumerable.Range(0, 10);
var even = nums.Where(i => i % 2 == 0);
var result = Vat(new Address("tr"), new Order(new Product("ads", 45, false), 5));
Console.WriteLine(result.ToString());

static decimal RateByCountry(string country) => country switch
{
    "it" => 0.23m,
    "tr" => 0.99m,
    _ => throw new ArgumentNullException($"Missing rate for {country}")
};
static decimal RateByState(string state) => state switch
{
    "ca" => 0.23m,
    "ma" => 0.99m,
    "my"=> 0.0m,
    _ => throw new ArgumentNullException($"Missing rate for {state}")
};

//Value pattern
static decimal DeVat(Order order) => order.NetPrice * (order.Product.IsFood ? 0.08m : 0.3m);
static decimal Vat2(decimal rate, Order order) => order.NetPrice * rate;

static decimal Vat(Address address, Order order) => Vat2(RateByCountry(address.Country), order);

//Deconstructing pattern
static decimal VatDeconstruct(Address address, Order order) => address switch
{
    Address("tr") => DeVat(order), Address(var country) => Vat2(RateByCountry(country), order),
};

//Switch edit ile VatDeconstruct
static decimal VatDeconstruct2(Address address, Order order) => address switch
{
    ("tr") _ => DeVat(order), (var country) _ => Vat2(RateByCountry(country), order),
};

//Property Pattern
static decimal VatProp(Address address, Order order) => address switch
{
    { Country: "tr" } => DeVat(order),
    { Country: var c } => Vat2(RateByCountry(c), order),
};

//Add Us state 
static decimal Vat3(Address address, Order order) => address switch
{
    UsAddress(var state) => Vat2(RateByState(state), order),
    ("de") _ => DeVat(order),
    (var country) _ => Vat2(RateByCountry(country), order),
};

internal record Product(string Name, decimal Price, bool IsFood);

internal record Order(Product Product, int Quantity)
{
    public decimal NetPrice => Product.Price * Quantity;
}

internal record Address(string Country);

internal record UsAddress(string state) : Address("us");