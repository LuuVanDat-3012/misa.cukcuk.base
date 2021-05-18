<template>
  <div class="content">
    <!-- <div class="navigation"></div> -->
    <customer/>
    <popup />
  </div>
</template>
<script>
import Customer from '../customer/customer.vue';
import Popup from './popup/popup.vue';
// eslint-disable-next-line import/extensions

export default {
  components: {
    Customer,
    Popup,
  },
};
</script>
<style>

</style>
