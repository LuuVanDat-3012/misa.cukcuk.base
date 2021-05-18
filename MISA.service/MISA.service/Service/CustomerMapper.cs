using AutoMapper;
using MISA.service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service.Service
{
    public class CustomerMapper
    {
        public static CustomerDTO convertCustomer(Customer customer)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>());
            var mapper = new Mapper(config);
            var customerDTO = mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }
        public static List<CustomerDTO> convertListCustomer(List<Customer> customers)
        {
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            for(int i = 0; i < customers.Count; i++)
            {
                customerDTOs.Add(convertCustomer(customers[i]));
            }
            return customerDTOs;
        }

        internal static object convertListCustomer(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }
    }
}
