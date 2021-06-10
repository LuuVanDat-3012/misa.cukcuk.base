<template>
  <div class="MISAnavigate">
    <div class="total-employee">Hiển thị nhân viên trên một trang</div>
    <div class="list-page-number">
      <div class="page">
        <div class="btn-firstpage navigate-page"></div>
        <div class="btn-prev-page navigate-page"></div>
        <div class="page-number" v-for="index in 4" :key="index"  :class="{isSelected: Selected(index)}">
          {{ index }}
        </div>
        <div class="btn-next-page navigate-page"></div>
        <div class="btn-lastpage navigate-page"></div>
      </div>
    </div>
    <div class="employees-in-page">Tổng: {{quality}}</div>
  </div>
</template>
<script>
export default {
  name: 'MISANavigate',
  data () {
    return {
      totalPage: 1, // Tong so trang
      currentPage: 0, // Trang hiện tại
      quality: 0, // Tổng số khách hàng,
      maxPage: 1,
      startPage: 1,
      endPage: 1
    }
  },
  methods: {

    Selected (val) {
      if (val - 1 === this.page) { return true }
    }
  },
  computed: {
    from () {
      if (this.totalPage === 1) {
        return this.maxPage
      }
      return 1
    }
  }

}
</script>
<style>
@import url("./navigate.css");
</style>
