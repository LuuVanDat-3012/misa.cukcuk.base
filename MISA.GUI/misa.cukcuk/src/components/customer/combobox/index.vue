<template>
  <div class="dropdown">
    <div class="dropbtn">
      <div class="dropbtn-text">{{ title.customerGroupName }}</div>
      <div class="dropbtn-icon" @click="isClick = !isClick"></div>
    </div>
    <div class="drop-content" v-show="isClick">
      <div
        class="item"
        v-for="(item, index) in customerGroup"
        :key="index"
        @click="GetCustomerGroup(item.id, item.customerGroupName)"
      >
        <div class="content-icon-default"></div>
        <div class="cbb-content-text">{{ item.customerGroupName }}</div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  components: {},
  data () {
    return {
      customerGroup: null,
      isHover: false,
      isClick: false
      // title: {
      //   customerGroupId: '',
      //   customerGroupName: ''
      // }
    }
  },
  methods: {
    GetCustomerGroup (id, name) {
      this.title.customerGroupName = name
      this.$emit('GetCustomerGroup', this.title.customerGroupId)
      this.isClick = false
    }
  },
  mounted () {
    this.axios('CustomerGroups').then(response => {
      this.customerGroup = response.data.data
      this.title.customerGroupId = response.data.data[0].id
      this.title.customerGroupName = response.data.data[0].customerGroupName
    })
  },
  props: {
    title: {
      typeof: Object
    }
  }
}
</script>
<style>
@import url("./combobox.css");
</style>
