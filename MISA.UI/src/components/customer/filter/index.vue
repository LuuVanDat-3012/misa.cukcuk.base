<template>
<div class="filter">
    <div class="content-header">
      <div class="title">
        <p>DANH SÁCH KHÁCH HÀNG</p>
      </div>
      <div class="btn-insert" @click="ShowDialog('11111111-1111-1111-1111-111111111111')">
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
</div>
</template>

<script>
export default {
  setup() {

  },
};
</script>
<style>
@import url("./filter.css");
</style>
