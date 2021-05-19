<template>
  <div id="app">
    <left-side-bar />
    <Header />
    <Content @ShowDialog="ShowDialog" />
    <Dialog v-show="isShow" ref="dialog"  @CloseDialog='CloseDialog'></Dialog>
  </div>
</template>
<script>
import Content from './components/common/Content.vue';
import Header from './components/common/Header.vue';
import LeftSideBar from './components/common/LeftSideBar.vue';
import Dialog from './components/customer/dialog.vue';

export default {
  components: {
    LeftSideBar,
    Header,
    Content,
    Dialog,
  },
  name: 'App',
  data() {
    return {
      isShow: false,
    };
  },
  methods: {
    ShowDialog(val) {
      this.isShow = true;
      this.$refs.dialog.ShowCustomer(val);
    },
    CloseDialog() {
      this.isShow = false;
    },
  },
};
</script>
<style>
* {
  margin: 0;
  padding: 0;
}
#app {
  font-family: MISA-Regular, MISA-Bold, MISA-Italic;
  font-size: 13px;
}
@font-face {
  font-family: "MISA-Regular";
  src: url("./assets/font/GoogleSans-Regular.otf");
}
@font-face {
  font-family: "MISA-Bold";
  src: url("./assets/font/GoogleSans-Bold.otf");
}
@font-face {
  font-family: "MISA-Italic";
  src: url("./assets/font/GoogleSans-Italic.otf");
}
</style>
