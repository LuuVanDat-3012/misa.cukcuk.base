<template>
  <div class="content">
    <!-- <div class="navigation"></div> -->
    <Customer />
  </div>
</template>
<script>

import Customer from '../customer/Customer'
// eslint-disable-next-line import/extensions

export default {
  components: {
    Customer
  }
}
</script>
<style>
.content {
    width: calc(100% - 227px);
    height: calc(100vh - 61px);
    position: absolute;
    top: 61px;
    left: 227px;
    display: flex;
    flex-direction: column;
    padding: 0px 24px 0px 24px;
    box-sizing: border-box;
  }
</style>
