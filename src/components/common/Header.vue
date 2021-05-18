<template>
  <div class="header">
    <div class="res">
      <select name="" id="">
        <option value="" v-for="(item, index) in listRes" :key="index">
          {{ item.customerGroupName }}
        </option>
      </select>
    </div>
    <div class="user">
      <div class="image-user"></div>
      <div class="username">Lưu Văn Đạt</div>
      <div class="more-info"></div>
    </div>
  </div>
</template>
<script>

export default {
  name: 'Header',
  components: {
  },
  mounted() {
    this.axios('/api/CustomerGroups').then((response) => {
      console.log(response.data);
      this.listRes = response.data;
    });
  },
  data() {
    return {
      listRes: null,
    };
  },
};
</script>
<style>
.header {
  display: flex;
  position: absolute;
  width: calc(100% - 227px);
  right: 0;
  height: 60px;
  top: 0;
  border-bottom: 1px solid #d2d2d2;
  display: flex;
  align-items: center;
}
.res select {
  border: 0;
  width: 200px;
  font-family: MISA-Regular;
  font-size: 15px;
  padding-left: 24px;
  font-weight: bolder;
}
.res select:focus {
  outline: 0;
}
.user {
  display: flex;
  position: absolute;
  right: 24px;
}
.image-user {
  width: 30px;
  height: 30px;
  background-image: url("../../assets/icon/avatar-default.png");
  background-position: center;
  background-size: contain;
  background-repeat: no-repeat;
  border-radius: 50%;
}
.username {
  padding: 0px 16px 0px 16px;
  line-height: 30px;
}
.more-info {
  width: 30px;
  height: 30px;
  background-image: url("../../assets/icon/option.png");
  background-position: center;
  background-size: contain;
  background-repeat: no-repeat;
}
</style>
