using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService

    {
        IBaseRepository<Customer> _baseRepository;

        #region Constructor
        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public override ActionServiceResult AddEntity(Customer customer)
        {

            var fields = this.BaseValidate(customer);
            if (fields.Count != 0)
            {
                return new ActionServiceResult()
                {
                    Message = "Nhập sai định dạng !!!",
                    Success = false,
                    fieldNotValids = fields,
                    data = null,
                    MISAcode = Enumeration.MISAcode.Validate
                };
            }
            else
            {
                //validate thông tin
                var isvalid = true;
                //validate thông tin
                var customerDuplicate = GetCustomerByCode(customer.Fullname);
                if (customerDuplicate.data != null)
                {
                    isvalid = false;
                }
                if (isvalid == true)
                {
                    return base.AddEntity(customer);
                }
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = "Mã khách hàng đã tồn tại !!!",
                    MISAcode = Enumeration.MISAcode.Exception,
                    data = 0
                };
            }


        }

        public ActionServiceResult DeleteMultiple(String[] listId)
        {
            var affectedRows = 0;
            using (var transaction = new TransactionScope())
            {
                foreach (string id in listId)
                {
                    var result = this.DeleteEntity(Guid.Parse(id));
                    affectedRows += (int)result.data;
                }
                if (affectedRows == listId.Length)
                {
                    transaction.Complete();
                    return new ActionServiceResult()
                    {
                        Success = true,
                        Message = "Xoá thành công !!!",
                        MISAcode = Enumeration.MISAcode.Success,
                        data = affectedRows
                    };
                }
                else
                {
                    transaction.Dispose();
                    return new ActionServiceResult()
                    {
                        Success = true,
                        Message = "Không thành công !!!",
                        MISAcode = Enumeration.MISAcode.Success,
                        data = 0
                    };
                }

            }
        }

        public ActionServiceResult GetCustomerByCode(string customerCode)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Method
        public ActionServiceResult GetCustomerByCustomerGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerByName(string name)
        {
            var param = new DynamicParameters();
            param.Add("@Fullname", name);
            var customers = _baseRepository.Get($"Proc_GetCustomerByName", param, commandType: System.Data.CommandType.StoredProcedure);
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = customers
            };
        }

        public ActionServiceResult GetCustomerPaging(int limit, int offser)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
