<template>
  <div class="grid">
    <div>
      {{listDelete}}
    </div>
    <table>
      <thead class="titleRow">
        <tr>
          <th>#</th>
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
          @dblclick="ShowCustomerDetail(customer.id)"
          class="contentRow"
        >
          <td>
            <input type="checkbox" :value="customer.id" :id="customer.id" class="checkboxRow" v-model="listDelete" />
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
     <div class="loading" v-if="isLoading">
      <PulseLoader class="loading-icon"></PulseLoader>
    </div>

  </div>
</template>
<script>
import PulseLoader from 'vue-spinner/src/PulseLoader.vue'
export default {
  name: 'Grid',
  components: {
    PulseLoader
  },
  data () {
    return {
      listCustomer: 1,
      isShow: false,
      isLoading: true,
      fullPage: true,
      listDelete: []
    }
  },
  methods: {
    ShowCustomerDetail (val) {
      this.$emit('ShowCustomerDetail', val)
    },
    ShowCustomers (val) {
      this.axios.get('Customers/search/' + val).then(response => {
        this.listCustomer = response.data.data
      })
    }
  },
  mounted () {
    this.axios.get('Customers').then(response => {
      this.listCustomer = response.data.data
      this.isLoading = false
    })
  }
}
</script>

<style>
@import url("./grid.css");
</style>
