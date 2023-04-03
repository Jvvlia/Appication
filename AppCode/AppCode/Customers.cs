using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppCode
{
    public class Customers
    {
        List<Customer> customers;

        public List<Customer> CustomersList { get => customers; set => customers = value; }

        public Customers()
        {
            CustomersList = new List<Customer>();
        }

        public void AddCustomer(Customer c)
        {
            if (!CustomersList.Contains(c))
            {
                CustomersList.Add(c);
            }
        }

        public void RemoveCustomer(Customer c)
        {
            if (CustomersList.Contains(c))
            {
                CustomersList.Remove(c);
            }
        }

        public List<Customer> GetCustomers()
        {
            if (CustomersList != null)
            {
                return CustomersList;
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            CustomersList.ForEach(c => sb.AppendLine(c.ToString()));
            return sb.ToString();
        }

        public void SerializeXml(string fname)
        {
            using StreamWriter sw = new(fname);
            XmlSerializer xs = new XmlSerializer(typeof(Customers));
            xs.Serialize(sw, this);
        }

        public static Customers DeserializeXml(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using StreamReader sr = new StreamReader(fname);
            XmlSerializer xs = new(typeof(Customers));
            return xs.Deserialize(sr) as Customers;
        }
    }
}
