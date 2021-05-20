using Dapper;
using MISA.Entity.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerContext
    {

        string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
        IDbConnection dbConnection;
        public CustomerContext()
        {
            dbConnection = new MySqlConnection(connectionString);
        }
        #region Method
        /// <summary>
        /// Lấy toàn bộ danh sách kahchs hàng
        /// </summary>
        /// <returns>List danh sách khách hàng</returns>
        /// CreatedBy: LVDat(19/5/2021)


        public List<Customer> GetCustomers()
        {
            {
                //    //Kết nói tới CSDL
                //    //Khỏi tạo các commandText
                var customers = dbConnection.Query<Customer>($"Proc_GetCustomers", commandType: CommandType.StoredProcedure).ToList();
                //    //Trả về dữ kiệu
                return customers;
            }
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo mã
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>! khách hàng</returns>
        /// CreatedBy : LVDat (19/05/2021)

        public Customer GetCustomerById(Guid customerId)
        {
            //Kết nối tới CSDL

            //Khoir taoj cacs commandText
            var customer = dbConnection.Query<Customer>($"Proc_GetCustomerById", new { customerId = customerId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //Trả về dữ liệu
            return customer;
        }

        public List<Customer> GetCustomerByCodeAndName(string code, string name)
        {
            //Khoir taoj cacs commandText
            var customer = dbConnection.Query<Customer>($"Proc_GetCustomersByCodeAndName", new { customerCode = code, customerName = name }, commandType: CommandType.StoredProcedure).ToList();
            //Trả về dữ liệu
            return customer;
        }

        /// <summary>
        /// Thêm mới 1 khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần thêm mới</param>
        /// CreatedBy: LVDat (20/05/2021)
        public void InsertCustomer(Customer customer)
        {
            //Validate trường CustomerGroupId
            customer.GroupId = customer.CustomerGroupId.ToString();
            //Khởi tạo các commandText
            var affectRow = dbConnection.Execute($"Proc_InsertCustomer", customer, commandType: CommandType.StoredProcedure);

        }

        //Sửa thông tin

        //Xóa khách hàng theo khóa chính
        #endregion
    }
}
