﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicStore.Library
{
    public class CustomerRepository
    {
        private readonly ICollection<Customer> _data;

        public CustomerRepository(ICollection<Customer> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }


        //search Customer

        public IEnumerable<Customer> GetCustomer(string search = null)
        {
            if (search == null)
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _data.Where(r => r.Name.Contains(search)))
                {
                    yield return item;
                }
            }
        }

        //add customer 


        public void AddCustomer(Customer customer)
        {
            if (_data.Any(c => c.Name == customer.Name))
            {
                throw new InvalidOperationException("A Comic Store with that name already exists. ");
            }
            _data.Add(customer);
        }



        //delete comic 

        public void DeleteCustomer(Customer customer)
        {
            _data.Remove(_data.First(x => x.Name == customer.Name));
        }


        //update comic 
        public void UpdateCustomer(Customer old, Customer ne)
        {
            DeleteCustomer(old);
            AddCustomer(ne);
        }





    }
}
