using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion
        public virtual ActionServiceResult AddEntity(TEntity entity)
        {
            ActionServiceResult actionServiceResult = new ActionServiceResult();
            var isValidate = BaseValidate(entity);
            if (isValidate.Count == 0)
            {
                return new ActionServiceResult()
                {
                    Message = "Thêm thành công",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Success,
                    data = _baseRepository.AddEntity(entity)
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
            return new ActionServiceResult()
            {
                Message = "Xoá thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.DeleteEntity(entityId)
            };
        }

        public ActionServiceResult GetEntities()
        {
            return new ActionServiceResult()
            {
                Message = "Thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.GetEntities()
            };
        }

        public ActionServiceResult GetEntityById(Guid entityId)
        {
            var entity = _baseRepository.GetEntityById(entityId);
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

        public ActionServiceResult UpdateEntity(TEntity entity)
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.UpdateEntity(entity)
            };

        }
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng validate</param>
        /// <returns>! danh sách các property không chính xác</returns>
        protected virtual List<FieldNotValid> BaseValidate(TEntity entity)
        {
            List<string> msg = new List<string>();
            List<FieldNotValid> fieldNotValids = new List<FieldNotValid>();
            //Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Validate property bắt buộc nhập
                var propertieRequired = property.GetCustomAttributes(typeof(Required), true);
                if (propertieRequired.Length > 0)
                {
                    var value = property.GetValue(entity);
                    var propertyTypeName = property.PropertyType.Name;
                    var propertyName = property.Name;
                    if (propertyTypeName.Equals("String"))
                        if (value.ToString() == string.Empty || value == null)
                        {
                            fieldNotValids.Add(new FieldNotValid()
                            {
                                fieldName = propertyName,
                                msg = "Không được để trống"
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
                                msg = "Không được để trống"
                            });

                        }
                    }
                }

                // Validate property theo độ dài
                var propertieLength= property.GetCustomAttributes(typeof(Length), true);
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
                                msg = message + " không vượt quá "+ maxLength + " ký tự !!!"
                            });
                        }
                }
                // Validate các property không âm
                var propertyNegative = property.GetCustomAttributes(typeof(NotNegative), true);
                if (propertyNegative.Length > 0)
                {
                    var value = property.GetValue(entity);
                    var message = (propertyNegative[0] as NotNegative).Msg;
                    var propertyName = property.Name;
                    if ((int)value < 0)
                        fieldNotValids.Add(new FieldNotValid()
                        {
                            fieldName = propertyName,
                            msg = message
                        });
                }
            }
            return fieldNotValids;
        }

    }
}
