using AppCode;
class Program
{
    static void CustomersTest()
    {
        Customers customers = new Customers();
        Customer c1 = new Customer("Ania", "ul.Zapolskiej 32, Kraków", "PL2345678901", "2012-03-07");
        Customer c2 = new Customer("Marek", "ul.Wiosenna 3, Opole", "PL3456789023", "2022-12-09");
        Customer c3 = new Customer("Kasia", "ul. Sosonowa 5, Rzeszów", "PL9876543567", "2020-09-25");
        customers.AddCustomer(c1);
        customers.AddCustomer(c2);
        customers.AddCustomer(c3);
        string fname = "customers.xml";
        customers.SerializeXml(fname);
        Console.WriteLine(customers.ToString());
        Customers customers2 = Customers.DeserializeXml(fname);
        Console.WriteLine(customers2.ToString());
    }

    static void Main()
    {
        CustomersTest();
    }
}