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
      <div class="btn-delete" @click="DeleteCustomers">
        <p>Xoá</p>
      </div>
      <div class="btn-refresh" @click="ReloadData">
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
    GetCustomerByName (val, page) {
      page = 1
      val = this.customerName
      this.$emit('GetCustomerByName', val, page)
    },
    DeleteCustomers () {
      this.$emit('DeleteCustomers')
    },
    ReloadData () {
      this.$emit('ReloadData')
    },
    removeAccents (str) {
      var AccentsMap = [
        'aàảãáạăằẳẵắặâầẩẫấậ',
        'AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ',
        'dđ',
        'DĐ',
        'eèẻẽéẹêềểễếệ',
        'EÈẺẼÉẸÊỀỂỄẾỆ',
        'iìỉĩíị',
        'IÌỈĨÍỊ',
        'oòỏõóọôồổỗốộơờởỡớợ',
        'OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ',
        'uùủũúụưừửữứự',
        'UÙỦŨÚỤƯỪỬỮỨỰ',
        'yỳỷỹýỵ',
        'YỲỶỸÝỴ'
      ]
      for (var i = 0; i < AccentsMap.length; i++) {
        var re = new RegExp('[' + AccentsMap[i].substr(1) + ']', 'g')
        var char = AccentsMap[i][0]
        str = str.replace(re, char)
      }
      return str
    }
  }

}
</script>
<style>
@import url("./filter.css");
</style>
