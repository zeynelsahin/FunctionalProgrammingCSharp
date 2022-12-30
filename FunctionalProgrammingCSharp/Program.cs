using System.Collections;
using  FunctionalProgrammingCSharp;

var nums = Enumerable.Range(0, 10);
var even = Enumerable.Where(nums, i => i % 2 == 0);

var result = Vat(new Address("tr"), new Order(new Product("ads", 45, false), 5));
Console.WriteLine(result.ToString());

var result1 = VatDeconstruct(new Address("tr"), new Order(new Product("ads", 55, false), 15));
Console.WriteLine(result1.ToString());

// State
var resul2 = Vat3(new UsAddress("ca"),new Order(new Product("asda",65,false),4));
Console.WriteLine(resul2.ToString());

var resul3 = Vat3(new Address("tr"),new Order(new Product("asda",65,false),4));
Console.WriteLine(resul3.ToString());
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

var list = Enumerable.Range(0, 10).Select(i => i * 3).ToList();

int Alphabetically(int l, int r) => l.ToString().CompareTo(r.ToString());
list.Sort(Alphabetically);

var days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
IEnumerable<DayOfWeek> daysStrantingWith(string s) => Enumerable.Where(days, d=>d.ToString().StartsWith(s));

Comparison<int> alphabetically= (l, r) => l.ToString().CompareTo(r.ToString());

var frenchFor = new Dictionary<bool, string>//dictionary mapping
{
    [true]="Vrai",
    [false]="Faux"
};
var french=frenchFor[true]; 

var divide=(double x,int y)=>x / y;
 var dasda=divide(10, 3);
var divideBy = divide.SwapArgs();
divideBy(2,3);

Func<int, bool> isMod(int n) => i => i % n == 0;

// HOF Higher Order Functions 
//ExtensionMethods da bulunan where ile çakışıyor
var range = Enumerable.Range(1, 20);
// var deneme = System.Linq.Enumerable.Range(1,20).Where(
//     isMod(2));



Console.ReadKey();
internal record Product(string Name, decimal Price, bool IsFood);

internal record Order(Product Product, int Quantity)
{
    public decimal NetPrice => Product.Price * Quantity;
}

internal record Address(string Country);

internal record UsAddress(string state) : Address("us");