<template>
  <div class="container-dialog">
    <div class="dialog-model"></div>
    <div class="dialog">
      <div class="dialog-title">
        <div class="dialog-title-text">THÔNG TIN KHÁCH HÀNG</div>
        <div class="btn-close-dialog" @click="CloseDialog"></div>
      </div>
      <div class="dialog-content">
        <div class="content-up">
          <div class="input-image">
            <div class="image-icon">
              <div></div>
            </div>
            <div class="image-text">
              <div>Vui lòng chọn ảnh có định dạng <b>.jpg, .png, .gif</b></div>
            </div>
          </div>
          <div class="input-info-up">
            <div class="box-input-up">
              <div class="input-code input-common">
                <div class="input-title">
                  Mã nhân viên <b style="color: red">(*)</b>
                </div>
                <div class="input-box">
                  <input
                    type="text"
                    ref="search"
                    class="imposition"
                    v-model="infoCustomer.customerCode"
                    :class="{ warning: isWarningCode }"
                    @keyup="isWarningCode = false"
                    placeholder="Mã nhân viên"
                  />
                </div>
              </div>
              <div class="input-code input-common">
                <div class="input-title">
                  Họ và tên <b style="color: red">(*)</b>
                </div>
                <div class="input-box">
                  <input
                    type="text"
                    name="CFullname"
                    class="imposition"
                    v-model="infoCustomer.fullname"
                    placeholder="Họ và tên"
                    :class="{ warning: isWarningName }"
                    @keyup="isWarningName = false"
                  />
                </div>
              </div>
            </div>

            <div class="box-input-up">
              <div class="input-code-card input-common">
                <div class="input-title">Mã thẻ thành viên</div>
                <div class="input-box">
                  <input
                    type="text"
                    name="memberCardCode"
                    v-model="infoCustomer.memberCardCode"
                    placeholder="Mã thẻ thành viên"
                  />
                </div>
              </div>
              <div class="input-code-card input-common">
                <div class="input-title">Nhóm khách hàng</div>
                <div class="input-box">
                  <Combobox
                    @GetCustomerGroup="GetCustomerGroup"
                    :title="this.title"
                    ref="combobox"
                  />
                </div>
              </div>
            </div>
            <div class="box-input-up">
              <div class="input-birthday input-common">
                <div class="input-title">Ngày sinh</div>
                <div class="input-box ">
                  <!-- <input
                    type="date"
                    name="CBirthday"
                    v-model="infoCustomer.birthday"
                    placeholder="dd/MM/yyyy"
                  /> -->
                  <DatePicker
                    class="datepicker "
                    v-model="infoCustomer.birthday"
                    format="dd/MM/yyyy"
                  />
                </div>
              </div>
              <div class="input-birthday input-common">
                <div class="input-title">Giới tính</div>
                <div class="input-box radioGender">
                  <div class="male">
                    <input
                      type="radio"
                      name="customerGender"
                      value="0"
                      id="nam"
                      v-model="infoCustomer.gender"
                    />
                    <label for="nam">Nam</label>
                  </div>
                  <div class="female">
                    <input
                      type="radio"
                      name="customerGender"
                      value="1"
                      id="nu"
                      v-model="infoCustomer.gender"
                    />
                    <label for="nu">Nữ</label>
                  </div>
                  <div class="other">
                    <input
                      type="radio"
                      name="customerGender"
                      value="2"
                      id="khac"
                      v-model="infoCustomer.gender"
                    />
                    <label for="khac">Khác</label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- NỬA DƯỚI -->
        <div class="input-center">
          <div class="input-center-row">
            <div class="input-center-left">
              <div class="input-title">Email</div>
              <div class="box-center-left">
                <input
                  type="email"
                  name="customerEmail"
                  placeholder="example@gmail.com"
                  v-model="infoCustomer.email"
                />
              </div>
            </div>
            <div class="input-center-right">
              <div class="input-code-card input-common">
                <div class="input-title">
                  Số điện thoại <b style="color: red">(*)</b>
                </div>

                <div class="input-box">
                  <input
                    type="text"
                    class="imposition"
                    v-model="infoCustomer.phone"
                    placeholder="Sô điện thoại"
                    :class="{ warning: isWarningPhone }"
                    @keyup="isWarningPhone = false"
                  />
                </div>
              </div>
            </div>
          </div>

          <div class="input-center-row">
            <div class="input-center-left">
              <div class="input-title">Tên công ty</div>
              <div class="box-center-left">
                <input
                  type="text"
                  name="CCompany"
                  v-model="infoCustomer.company"
                  placeholder="Tên công ty"
                />
              </div>
            </div>
            <div class="input-center-right">
              <div class="input-code-card input-common">
                <div class="input-title">Mã số thuế</div>
                <div class="input-box">
                  <input
                    type="text"
                    name="CTaxCode"
                    placeholder="Mã số thuế"
                    v-model="infoCustomer.taxCode"
                  />
                </div>
              </div>
            </div>
          </div>

          <div class="input-center-row">
            <div class="input-center-address">
              <div class="input-title">Địa chỉ</div>
              <div class="box-center-address">
                <input
                  type="text"
                  name="CAddress"
                  v-model="infoCustomer.address"
                />
              </div>
            </div>
          </div>
        </div>
        <!-- FOOTER -->
        <div class="dialog-footer">
          <div class="btn-cancel">
            <button @click="CloseDialog">HUỶ</button>
          </div>
          <div class="btn-save">
            <button @click="AddCustomer">LƯU</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import DatePicker from 'vuejs-datepicker'
import Combobox from '../combobox/index'
import moment from 'moment'
export default {
  name: 'Dialog',
  components: {
    DatePicker,
    Combobox
  },
  data () {
    return {
      infoCustomer: {
        id: '2924c34d-68f1-1d0a-c9c7-6c0aeb6ec302',
        customerCode: '',
        fullname: '',
        gender: 1,
        birthday: '2000-12-30T00:00:00',
        phone: '',
        email: '',
        memberCardCode: '',
        taxCode: '',
        address: '',
        company: '',
        customerGroupName: 'Thường',
        customerGroupId: '2924c34d-68f1-1d0a-c9c7-6c0aeb6ec302',
        status: '1'
      },
      isDisabled: false,
      isWarningName: false,
      isWarningCode: false,
      isWarningPhone: false,
      tmp: {
        id: '2924c34d-68f1-1d0a-c9c7-6c0aeb6ec302',
        customerCode: '',
        fullname: '',
        gender: 1,
        birthday: '2000-12-30T00:00:00',
        phone: '',
        email: '',
        memberCardCode: '',
        taxCode: '',
        address: '',
        company: '',
        customerGroupName: 'Thường',
        customerGroupId: '2924c34d-68f1-1d0a-c9c7-6c0aeb6ec302',
        status: '1'
      },
      title: {
        customerGroupId: '',
        customerGroupName: ''
      }
    }
  },

  methods: {
    customFormatter (date) {
      return moment(date).format('yyyy-MM-DD')
    },
    ShowCustomerDetail (val) {
      if (val !== '') {
        this.axios('Customers/' + val).then(response => {
          if (response.data.data != null) {
            this.infoCustomer = response.data.data
            this.title.customerGroupId = response.data.data.customerGroupId
            this.title.customerGroupName = response.data.data.customerGroupName
          }
        })
      }
    },
    CloseDialog () {
      this.infoCustomer = this.tmp
      this.$refs.combobox.isClick = false
      this.$emit('CloseDialog')
    },
    FocusInput () {
      setTimeout(() => {
        this.$refs.search.focus()
      }, 10)
    },

    ValidateData (val) {
      if (typeof (val) === 'undefined' || val === null || val === '') { return false }
      return true
    },
    ValidateCustomer () {
      if (this.ValidateData(this.infoCustomer.customerCode) === false) {
        this.isWarningCode = true
        return false
      }
      if (this.ValidateData(this.infoCustomer.fullname) === false) {
        this.isWarningName = true
        return false
      }
      if (this.ValidateData(this.infoCustomer.phone) === false) {
        this.isWarningPhone = true
        return false
      }
      return true
    },
    AddCustomer () {
      if (this.ValidateCustomer()) {
        this.infoCustomer.birthday = this.customFormatter(
          this.infoCustomer.birthday
        )
        this.axios
          .post('Customers', this.infoCustomer)
          .then(response => {
            this.$vToastify.success(response.data.message)
          })
          .catch(exp => {
            this.$vToastify.error('Đã xảy ra lỗi !!!')
          })
      }
    },
    GetCustomerGroup (val) {
      this.infoCustomer.customerGroupId = val
    }
  },
  mounted () {
    this.FocusInput()
    this.axios('CustomerGroups').then(response => {
      this.infoCustomer = response.data.data
    })
  }
}
</script>
<style>
@import url("./customer_detail.css");
</style>
