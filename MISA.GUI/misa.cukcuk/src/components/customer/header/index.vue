<template>
  <div class="content-header">
    <div class="title">
      <p>DANH SÁCH KHÁCH HÀNG</p>
    </div>
    <div class="btn-insert" @click="ShowDialog">
      <div class="btn-insert-icon"></div>
      <div class="btn-insert-text">Thêm khách hàng</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CustomerHeader',
  components: {},
  methods: {
    ShowDialog () {
      this.$emit('ShowDialog')
    }
  }
}
</script>
<style>
@import url("./header.css");
</style>
