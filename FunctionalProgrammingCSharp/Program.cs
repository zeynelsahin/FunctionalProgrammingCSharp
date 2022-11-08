
var nums = Enumerable.Range(0, 10);
var even = nums.Where(i => i % 2 == 0);
var result=Vat(new Address("tr", "Istanbul"), new Order(new Product("ads",45,false),5));
Console.WriteLine(result.ToString());

static decimal RateByCountry(string country) => country switch
{
    "it" => 0.23m,
    "tr" => 0.99m,
    _ => throw new ArgumentNullException($"Missing rate for {country}")
};

static decimal Vat2(decimal rate, Order order) => order.NetPrice * rate;
static decimal Vat(Address address, Order order) => Vat2(RateByCountry(address.Country), order);

internal record Product(string Name, decimal Price, bool IsFood);

internal record Order(Product Product, int Quantity)
{
    public decimal NetPrice => Product.Price * Quantity;
}

internal record Address(string Country, string City);