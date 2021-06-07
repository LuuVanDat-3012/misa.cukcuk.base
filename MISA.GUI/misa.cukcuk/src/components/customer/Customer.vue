<template>
  <div>
    <Header @ShowDialog="ShowDialog" />
    <FilterCustomer
      @GetCustomerByName="GetCustomerByName"
      @DeleteCustomers="DeleteCustomers"
      @ReloadData='ReloadData'
      ref=""
    />
    <Grid @ShowCustomerDetail="ShowCustomerDetail" ref="grid" @GetTotalPage="GetTotalPage"/>
    <CustomerDetail
      v-show="isShowed"
      @CloseDialog="CloseDialog"
      ref="DetailCustomer"
      :statusMethod='this.statusMethod'
       @ReloadData="ReloadData"
    />
    <PopupDetele
      v-show="isShowPopup"
      @ClosePopup="isShowPopup = false"
      :listIdDeleted="this.listIdDeleted"
      @ReloadData="ReloadData"
    />
    <MISANavigate ref="MISANavigate" />
  </div>
</template>
<script>
import MISANavigate from './navigate/index.vue'
import Header from './header/index.vue'
import FilterCustomer from './filter/index.vue'
import Grid from './grid/index.vue'
import CustomerDetail from './customer_detail/index.vue'
import PopupDetele from './popup/PopupDetele.vue'
export default {
  name: 'Customer',
  components: {
    Header,
    FilterCustomer,
    Grid,
    CustomerDetail,
    PopupDetele,
    MISANavigate
  },
  setup () {},
  data () {
    return {
      // Hiện thị customerdetai
      isShowed: false,
      // Biến hiện thị popup delete
      isShowPopup: false,
      // Khởi tạo 1 khách hàng rỗng
      // Danh sách id cần xoá
      listIdDeleted: [],
      statusMethod: ''
    }
  },
  methods: {
    // Hiển thị customer detail - thêm mới
    ShowDialog () {
      this.isShowed = true
      this.statusMethod = 'POST'
    },
    // Hiện thị customer detail - sửa
    ShowCustomerDetail (val) {
      this.statusMethod = 'PUT'
      this.isShowed = true
      this.$refs.DetailCustomer.ShowCustomerDetail(val)
    },
    // Đóng customer detail
    CloseDialog () {
      this.isShowed = false
    },
    // Gọi hàm hiển thị customer và truyền tên cần tìm
    GetCustomerByName (val) {
      this.$refs.grid.ShowCustomers(val)
      // Truyền số trangcho navigate
    },
    DeleteCustomers () {
      this.listIdDeleted = this.$refs.grid.listIdDeleted
      if (this.listIdDeleted.length === 0) {
        this.$vToastify.warning('Vui lòng chọn các khách hàng muốn xoá !!!')
      } else {
        this.isShowPopup = true
      }
    },
    // Tải lại dữ liệu
    ReloadData () {
      this.listIdDeleted = []
      this.$refs.grid.listIdDeleted = []
      this.$refs.grid.LoadData()
    },
    GetTotalPage (totalPage, currentPage) {
      this.$refs.MISANavigate.totalPage = totalPage
      this.$refs.MISANavigate.currentPage = currentPage
    }
  }
}
</script>
<style></style>
