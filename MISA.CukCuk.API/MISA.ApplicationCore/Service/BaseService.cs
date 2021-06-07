using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;
        protected string _tableName;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _tableName = typeof(TEntity).Name;
        }
        #endregion
        public virtual ActionServiceResult AddEntity(TEntity entity)
        {
            ActionServiceResult actionServiceResult = new ActionServiceResult();
            var isValidate = this.BaseValidate(entity);
            var param = this.MappingDataType(entity);

            if (isValidate.Count == 0)
            {
                return new ActionServiceResult()
                {
                    Message = "Thêm thành công",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Success,
                    data = _baseRepository.ExecuteNonQuery($"Proc_Add{_tableName}", param, commandType: CommandType.StoredProcedure)
                };
            }
            return new ActionServiceResult()
            {
                Message = "Không được để trống",
                Success = true,
                MISAcode = Enumeration.MISAcode.Validate,
                fieldNotValids = isValidate,
                data = null
            };
        }

        public ActionServiceResult DeleteEntity(Guid entityId)
        {
            var param = new DynamicParameters();
            param.Add("@customerId", entityId.ToString());

            return new ActionServiceResult()
            {
                Message = "Xoá thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.ExecuteNonQuery($"Proc_Delete{_tableName}", param, commandType: CommandType.StoredProcedure)
            };
        }



        public virtual ActionServiceResult GetEntities(int page, string propertySearch)
        {
           
            var param = new DynamicParameters();
            param.Add("@page", page*30);
            param.Add("@propertySearch", propertySearch);
            return new ActionServiceResult()
            {
                Message = "Thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.Get($"Proc_Get{_tableName}", param, commandType: CommandType.StoredProcedure)
            };
        }

        public ActionServiceResult GetEntityById(Guid entityId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", entityId.ToString());
            var entity = _baseRepository.Get($"Proc_Get{_tableName}ById", param, commandType: CommandType.StoredProcedure);
            if (entity != null)
            {
                return new ActionServiceResult()
                {
                    Message = "Thành công",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Success,
                    data = entity
                };
            }
            else
            {
                return new ActionServiceResult()
                {
                    Message = "Không tìm thấy",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Howllow,
                    data = null
                };
            }
        }

        public ActionServiceResult PagingEntity(string entityInfo)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult UpdateEntity(TEntity entity)
        {
            var param = this.MappingDataType(entity);
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.ExecuteNonQuery($"Proc_Update{_tableName}", param, CommandType.StoredProcedure)
            };

        }
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng validate</param>
        /// <returns>! danh sách các property không chính xác</returns>
        protected List<FieldNotValid> BaseValidate(TEntity entity)
        {
            List<string> msg = new List<string>();
            List<FieldNotValid> fieldNotValids = new List<FieldNotValid>();
            //Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Validate property bắt buộc nhập
                var propertyRequired = property.GetCustomAttributes(typeof(Required), true);
                if (propertyRequired.Length > 0)
                {
                    var message = (propertyRequired[0] as Required).Msg;
                    var value = property.GetValue(entity);
                    var propertyTypeName = property.PropertyType.Name;
                    var propertyName = property.Name;
                    if (propertyTypeName.Equals("String"))
                        if (value.ToString() == string.Empty || value == null)
                        {
                            fieldNotValids.Add(new FieldNotValid()
                            {
                                fieldName = propertyName,
                                msg = message
                            });
                        }

                    if (propertyTypeName.Equals("DateTime"))
                    {
                        DateTime dateTime = default(DateTime);
                        if (value.ToString() == dateTime.ToString())
                        {
                            fieldNotValids.Add(new FieldNotValid()
                            {
                                fieldName = propertyName,
                                msg = message
                            });

                        }
                    }
                }

                // Validate property theo độ dài
                var propertieLength = property.GetCustomAttributes(typeof(Length), true);
                if (propertieLength.Length > 0)
                {
                    var message = (propertieLength[0] as Length).Msg;
                    var maxLength = (propertieLength[0] as Length).MaxLength;
                    var value = property.GetValue(entity);
                    var propertyTypeName = property.PropertyType.Name;
                    var propertyName = property.Name;
                    if (propertyTypeName.Equals("String"))
                        if (value.ToString().Length > maxLength)
                        {
                            fieldNotValids.Add(new FieldNotValid()
                            {
                                fieldName = propertyName,
                                msg = message + " không vượt quá " + maxLength + " ký tự !!!"
                            });
                        }
                }
                // Validate các property không âm
                var propertyNegative = property.GetCustomAttributes(typeof(NotNegative), true);
                if (propertyNegative.Length > 0)
                {
                    var propertyType = property.PropertyType;
                    var value = property.GetValue(entity);
                    var message = (propertyNegative[0] as NotNegative).Msg;
                    var propertyName = property.Name;
                    if ((int)value < 0 || (int)value > 2)
                        fieldNotValids.Add(new FieldNotValid()
                        {
                            fieldName = propertyName,
                            msg = message 
                        });
                }
                //Validate ngày tháng năm
                var propertyTime = property.GetCustomAttributes(typeof(ValidateTime), true);
                if (propertyTime.Length > 0)
                {
                    var value = property.GetValue(entity);
                    var message = (propertyTime[0] as ValidateTime).Msg;
                    var propertyName = property.Name;
                    var startDate = new DateTime(2001, 01, 01, 0, 0, 0);
                    var endDate = new DateTime(2021, 01, 01, 0, 0, 0);
                    if ((DateTime)value < startDate || (DateTime)value > endDate)
                        fieldNotValids.Add(new FieldNotValid()
                        {
                            fieldName = propertyName,
                            msg = message
                        });
                }
            }
            return fieldNotValids;
        }

        public DynamicParameters MappingDataType<Tentity>(Tentity entity)
        {
            var properties = entity.GetType().GetProperties();
            var param = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyname = property.Name;
                var propertyvalue = property.GetValue(entity);
                var propertytype = property.PropertyType;
                if (propertytype == typeof(Guid) || propertytype == typeof(Guid?))
                {
                    param.Add($"@{propertyname}", propertyvalue, DbType.String);
                }
                else
                {
                    param.Add($"@{propertyname}", propertyvalue);
                }
            }
            return param;
        }

        public ActionServiceResult DeeteMultiple(Guid[] guids)
        {
            throw new NotImplementedException();
        }
    }
}

























// LVDat