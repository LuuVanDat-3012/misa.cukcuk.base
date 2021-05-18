using Dapper;
using MISA.Infrastructure.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerContext
    {
        #region Method
        //Lấy toàn bộ danh sách khách hàng
        //public IEnumerable<Customer> GetCustomers(){
        //    //Kết nói tới CSDL
        //    string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
        //    IDbConnection dbConnection = new MySqlConnection(connectionString);
        //    var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.Text);
        //    //Khỏi tạo các commandText

        //    //Trả về dữ kiệu
        //    return customers;
        //}

        //Lấy thông tin theo mã

        //Thêm mới khách hàng

        //Sửa thông tin

        //Xóa khách hàng theo khóa chính
        #endregion
    }
}
