using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Customer : Balance
    {
        private static uint _previous_id = 0;
        private string _cust_name;
        private readonly uint _cust_id;
        private Contact _contact;

        public string Name
        {
            get 
            {
                return _cust_name;
            } 
            set
            {
                _cust_name = value;
            }
        }
        public uint Id
        {
            get
            {
                return _cust_id;
            }
        }

        public Customer(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            _cust_id = _previous_id + 1;
            _previous_id += 1;

            _contact = new Contact();
        }

        public void SetContactDetails()
        {
            _contact.SetContact();
        }

        public Contact GetContactDetails()
        {
            return this._contact;
        }
        public void EditContactDetails()
        {
            Console.WriteLine("Press 'q' to skip :");
            _contact.SetContact(true);
        }
    }
}
