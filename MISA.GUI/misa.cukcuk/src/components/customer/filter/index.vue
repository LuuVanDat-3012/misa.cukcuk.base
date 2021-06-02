<template>
<div class="filter">
    <div class="content-filter">
      <div class="box-search">
        <div class="box-search-icon"></div>
        <div class="box-search-input">
          <input type="text" placeholder="Tìm kiếm theo mã, tên..." @keyup.enter="GetCustomerByName" v-model="customerName" />
        </div>
      </div>
      <div class="filter-customer-group">
      </div>
      <div class="btn-delete" >
        <p>Xoá</p>
      </div>
      <div class="btn-refresh">
        <div class="btn-refresh-icon"></div>
      </div>
    </div>

</div>
</template>

<script>

export default {
  name: 'FilterCustomer',
  components: {

  },
  data () {
    return {
      customerName: ''
    }
  },
  methods: {
    GetCustomerByName (val) {
      val = this.customerName
      this.$emit('GetCustomerByName', val)
    }

  }

}
</script>
<style>
@import url("./filter.css");
</style>
