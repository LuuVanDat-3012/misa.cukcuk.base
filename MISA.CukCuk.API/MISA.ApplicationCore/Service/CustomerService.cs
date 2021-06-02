using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService

    {
        ICustomerRepository _customerRepository;

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public override ActionServiceResult AddEntity(Customer customer)
        {

            var fields = this.BaseValidate(customer);
            if (fields.Count != 0)
            {
                return new ActionServiceResult()
                {
                    Message = "Nhập đúng định dạng !!!",
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
                var customerduplicate = _customerRepository.GetCustomerByCode(customer.CustomerCode);
                if (customerduplicate != null)
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
                    Message = "trùng mã khách hàng",
                    MISAcode = Enumeration.MISAcode.Exception,
                    data = 0
                };
            }


        }

        public ActionServiceResult DeleteMultiple(Guid[] guids)
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công !!!",
                MISAcode = Enumeration.MISAcode.Success,
                data = _customerRepository.DeleteMultipleCustomer(guids)
            };
        }
        #endregion
        #region Method
        public ActionServiceResult GetCustomerByCustomerGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerByName(string name)
        {

            List<Customer> customers = _customerRepository.GetCustomerByName(name);
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
        //private List<FieldNotValid> ValidateCustomer(Customer customer)
        //{
        //    List<FieldNotValid> fieldNotValids = this.BaseValidate(customer);
        //    if(fieldNotValids.Count != 0)
        //    return fieldNotValids;

        //}
        //protected override List<FieldNotValid> BaseValidate(Customer customer)
        //{
        //    List<FieldNotValid> fieldNotValids = base.BaseValidate(customer);
        //    if (fieldNotValids.Count == 0)
        //    {
        //        var properties = customer.GetType().GetProperties();
        //        foreach (var property in properties)
        //        {
        //            // Lấy ra property có gán attribute độ dài nhỏ hơn 20
        //            var propertieRequired = property.GetCustomAttributes(typeof(Length), true);
        //            if (propertieRequired.Length > 0)
        //            {
        //                var value = property.GetValue(customer);
        //                var propertyTypeName = property.PropertyType.Name;
        //                var propertyName = property.Name;
        //                if (propertyTypeName.Equals("String"))
        //                    if (value.ToString().Length > 20)
        //                    {
        //                        fieldNotValids.Add(new FieldNotValid()
        //                        {
        //                            fieldName = propertyName,
        //                            msg =  "Nhập quá 20 ký tự !!!"
        //                        });
        //                    }
        //            }
        //            //  // Lấy ra property có gán attribute không âm
        //            var propertyNegative = property.GetCustomAttributes(typeof(NotNegative), true);
        //            if (propertyNegative.Length > 0)
        //            {
        //                var value = property.GetValue(customer);
        //                var propertyTypeName = property.PropertyType.Name;
        //                var propertyName = property.Name;
        //                if((int)value < 0)
        //                    fieldNotValids.Add(new FieldNotValid()
        //                    {
        //                        fieldName = propertyName,
        //                        msg = "Giá trị không được âm !!! : "
        //                    });
        //            }
        //            //  Lấy ra property có gán attribute không âm
        //            var propertyTime = property.GetCustomAttributes(typeof(ValidateTime), true);
        //            if (propertyTime.Length > 0)
        //            {
        //                var value = property.GetValue(customer);
        //                var propertyName = property.Name;
        //                var startDate = new DateTime(2001, 01, 01, 0, 0, 0);
        //                var endDate = new DateTime(2021, 01, 01, 0, 0, 0);
        //                if((DateTime)value < startDate || (DateTime)value > endDate)
        //                    fieldNotValids.Add(new FieldNotValid()
        //                    {
        //                        fieldName = propertyName,
        //                        msg = "Giá trị ngày tháng không nằm trong khoảng giới hạn !!! : "
        //                    });
        //            }
        //        }
        //    }
        //    return fieldNotValids;

        //}

        #endregion
    }
}
