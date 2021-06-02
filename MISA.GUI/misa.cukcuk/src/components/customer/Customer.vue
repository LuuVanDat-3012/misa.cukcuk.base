<template>
  <div>
    <Header @ShowDialog='ShowDialog' />
    <FilterCustomer @GetCustomerByName='GetCustomerByName'/>
    <Grid @ShowCustomerDetail='ShowCustomerDetail' ref='grid'/>
    <CustomerDetail v-show="isShowed" @CloseDialog='CloseDialog' ref="DetailCustomer"/>
    <PopupDetele v-if="false" />
  </div>
</template>
<script>
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
    PopupDetele
  },
  setup () {

  },
  data () {
    return {
      isShowed: false,
      tmp: {
        id: '',
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
        customerGroupId: ''
      }
    }
  },
  methods: {
    ShowDialog () {
      this.isShowed = true
    },
    ShowCustomerDetail (val) {
      this.isShowed = true
      this.$refs.DetailCustomer.ShowCustomerDetail(val)
    },
    CloseDialog () {
      this.isShowed = false
    },
    GetCustomerByName (val) {
      this.$refs.grid.ShowCustomers(val)
    }

  }
}

</script>
<style>
</style>
