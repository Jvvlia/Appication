using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppCode
{
    public class Customer : ICloneable
    {
        string? name;
        string? address;
        string? vATID;
        DateTime creationDate;

        public string? Name { get => name; set => name = value; }
        public string? Address { get => address; set => address = value; }
        public string? VATID { get => vATID; set 
            {
                if(VATIDCheck(vATID))
                {
                    throw new WrongNumberException();
                }
                vATID = value;
            }
        }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }

        public Customer() { 
            VATID = new string('0', 11);
        }

        public Customer(string name, string address, string vat)
        {
            Name = name;
            Address = address;
            VATID = vat;
            CreationDate= DateTime.Now;
        }

        public Customer(string name, string address, string vat, string creation)
        {
            Name = name;
            Address = address;
            VATID = vat;

            if (DateTime.TryParseExact(creation, new String[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd" }, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                CreationDate = date;
            }
        }
        public bool VATIDCheck(string vat)
        {
            if (vat == null) { return false; }
            if(Regex.IsMatch(vat, @"^{2}\p{Lu}{10}$"))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name} from {Address}, joined {CreationDate:dd-MM-yyyy}, VATID {VATID}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        
    }

    [Serializable]
    internal class WrongNumberException : Exception
    {
        public WrongNumberException()
        {
        }

        public WrongNumberException(string? message) : base(message)
        {
        }

        public WrongNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
