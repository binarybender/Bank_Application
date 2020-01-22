using System;
using System.Text.RegularExpressions;

namespace BankAccount
{
    public class Contact
    {
        public string _phone_number;
        public string _address;
        public string _city;
        public string _state;
        public string _pin;
        public string _country;

        public void SetContact(bool edit=false)
        {
            this._phone_number = ValidateAndAssignInput(edit, this._phone_number, "Phone number", (phn) => { return Regex.Match(phn, @"^[0-9]{10}$").Success; });
           
           this._address = ValidateAndAssignInput(edit, this._address, "Address", (a) => { return !string.IsNullOrEmpty(a); });
           
           this._city = ValidateAndAssignInput(edit, this._city, "City", (a) => { return !string.IsNullOrEmpty(a); });
           
           this._state = ValidateAndAssignInput(edit, this._state, "State", (a) => { return !string.IsNullOrEmpty(a); });
           
           this._pin = ValidateAndAssignInput(edit, this._pin, "PIN", (pin) => { return Regex.Match(pin, @"^[0-9]{6}$").Success; });
           
           this._country = ValidateAndAssignInput(edit, this._country, "Country", (a) => { return !string.IsNullOrEmpty(a); });

        }

        private string ValidateAndAssignInput(bool edit, string prevVal, string field, Predicate<string> validate)
        {
            var end = false;
            var result = "";
            while (!end)
            {
                try
                {
                    Console.Write($"Enter {field,-20} : ");
                    result = Console.ReadLine();
                    if (edit && (result == "q" || result == "Q"))
                    {
                        return prevVal;
                    }
                    if (!validate(result))
                    {
                        throw new Exception($"Invalid/Empty {field} !!");
                    }
                    end = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\t\t\t\t{e.Message}");
                }
            }
            return result;
        }
    }
}
