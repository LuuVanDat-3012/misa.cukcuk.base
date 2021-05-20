<template>
  <div class="content">
    <div class="content-header">
      <div class="title">
        <p>DANH SÁCH KHÁCH HÀNG</p>
      </div>
      <div
        class="btn-insert"
        @click="ShowDialog('11111111-1111-1111-1111-111111111111')"
        accesskey="g"
      >
        <div class="btn-insert-icon"></div>
        <div class="btn-insert-text">Thêm khách hàng</div>
      </div>
    </div>
    <div class="content-filter">
      <div class="box-search">
        <div class="box-search-icon"></div>
        <div class="box-search-input">
          <input type="text" placeholder="Tìm kiếm theo mã, tên..." />
        </div>
      </div>
      <div class="filter-customer-group">
        <DropDown />
      </div>
      <div class="btn-refresh" @click="RefreshCustomers">
        <div class="btn-refresh-icon"></div>
      </div>
    </div>
    <div class="grid">
      <table>
        <thead>
          <tr :class="{loaded : tr}" >
            <th></th>
            <th>Mã khách hàng</th>
            <th>Họ và tên</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Số diện thoại</th>
            <th>Email</th>
            <th>Nhóm khách hàng</th>
            <th>Mã thẻ thành viên</th>
            <th>Mã số thuế</th>
            <th>Địa chỉ</th>
            <th>Công ty</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(customer, index) in listCustomer"
            :key="index"
            @dblclick="ShowDialog(customer.customerId)"
          >
            <td>
              <input type="checkbox" value="" class="checkboxRow" />
            </td>
            <td>{{ customer.customerCode }}</td>
            <td>{{ customer.fullname }}</td>
            <td>
              {{ customer.gender | formatGender }}
            </td>
            <td>
              {{ customer.birthday | formatDate }}
            </td>
            <td>{{ customer.phone }}</td>
            <td>{{ customer.email }}</td>
            <td>{{ customer.customerGroupName }}</td>
            <td>
              {{ customer.memberCardCode }}
            </td>
            <td>{{ customer.taxCode }}</td>
            <td>{{ customer.address }}</td>
            <td>{{ customer.company }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <!-- <div class="navigation"></div> -->
    <div class="loading" v-if="isLoaded">
      <PulseLoader class="loading-icon"></PulseLoader>
    </div>
  </div>
</template>
<script>
// eslint-disable-next-line import/extensions
import PulseLoader from 'vue-spinner/src/PulseLoader.vue';
import DropDown from '../dropdown/index.vue';

export default {
  components: {
    DropDown, PulseLoader,
  },
  data() {
    return {
      listCustomer: null,
      isShow: false,
      isLoaded: true,
      tr: false,
    };
  },
  mounted() {
    this.axios.get('Customers').then((response) => {
      this.listCustomer = response.data;
      this.isLoaded = false;
    });
    // this.axios.post('Customers', ).then((response) => {
    //   this.listCustomer = response.data;
    // });
  },
  methods: {
    /**
     * Hàm hiện thị dialog
     */
    ShowDialog(val) {
      this.isShow = true;
      this.$parent.$emit('ShowDialog', val);
    },
    /**
     * Hàm refresh dữ liệu
     */
    RefreshCustomers() {
      this.isLoaded = true;
      this.tr = false;
      this.axios.get('Customers').then((response) => {
        this.listCustomer = response.data;
        this.isLoaded = false;
        this.tr = true;
      });
    },
  },

};
</script>
<style>
@import url("../../style/customer/Customer.css");
</style>
