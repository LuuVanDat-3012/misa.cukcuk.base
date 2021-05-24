<template>
  <div class="dropdown">
    <div class="dropbtn">
      <div class="dropbtn-text">{{ title.customerGroupName }}</div>
      <div class="dropbtn-icon" @click="isClick = !isClick"></div>
    </div>
    <div class="drop-content" v-show="isClick">
      <div
        class="item"
        @click="
          GetCustomerGroup(
            '11111111-1111-1111-1111-111111111111',
            'Tất cả các khách hàng'
          )
        "
      >
        <div :class="{ contentIcon: isHover }" class="content-icon-default"></div>
        <div class="content-text">Tất cả khách hàng</div>
      </div>
      <div
        class="item"
        v-for="(item, index) in customerGroup"
        :key="index"
        @click="GetCustomerGroup(item.customerGroupId, item.customerGroupName)"
      >
        <div class="content-icon-default"></div>
        <div class="content-text">{{ item.customerGroupName }}</div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  components: {},
  data() {
    return {
      customerGroup: null,
      isHover: false,
      isClick: false,
      title: {
        customerGroupId: '11111111-1111-1111-1111-111111111111',
        customerGroupName: 'Tất cả các khách hàng',
      },
    };
  },
  methods: {
    GetCustomerGroup(id, name) {
      this.title.customerGroupId = id;
      this.title.customerGroupName = name;
      this.isClick = false;
    },
  },
  mounted() {
    this.axios('CustomerGroups').then((response) => {
      this.customerGroup = response.data;
    });
  },
};
</script>
<style scoped>
.dropdown {
  position: relative;
  display: inline-block;
  width: 200px;
}
.dropbtn {
  display: flex;
  background-color: #ffffff;
  color: #000;
  width: 200px;
  border: 0;
  border-radius: 4px;
  height: 40px;
  border: 1px solid #bbbbbb;
  font-size: 14px;
  font-weight: bolder;
  box-sizing: border-box;
  align-items: center;
}
.dropbtn-text {
  width: 160px;
  height: 100%;
  line-height: 40px;
  padding-left: 10px;
}
.dropbtn-icon {
  width: 40px;
  height: 40px;
  background-image: url("../../assets/icon/down-arrow.png");
  background-repeat: no-repeat;
  background-size: 16px;
  background-position: center;
  border-left: 1px solid #bbbbbb;
}
.dropbtn:hover {
  border: 1px solid #019160;
}
.drop-content {
  display: block;
  position: absolute;
  z-index: 99999999999999;
  width: 198px;
  background-color: #ffffff;
  padding-top: 3px;
  animation: animationPopup 2s forwards;
  border-left: 1px solid #bbbbbb ;
  border-right: 1px solid #bbbbbb;
}
.item {
  width: 100%;
  display: flex;
  height: 100%;
  border-bottom: 1px solid #bbbbbb;
  align-items: center;
  border-left: 1px;
  color: #000;
  animation: fadein 2s;
  -moz-animation: fadein 2s; /* Firefox */
  -webkit-animation: fadein 2s; /* Safari and Chrome */
  -o-animation: fadein 2s; /* Opera */
}
.content-icon-default {
  width: 46px;
  height: 16px;
}
.contentIcon {
  background-image: url("../../assets/icon/right-hand.png");
  background-repeat: no-repeat;
  background-size: 16px;
  background-position: center;
}
.content-text {
  flex: 1;
  align-items: center;
  line-height: 40px;
}
.item:hover {
  background-color: #bbbbbb;
  cursor: pointer;
}
.item:hover .dropbtn {
  border: 2px solid #019169 !important;
}
@keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
@-moz-keyframes fadein {
  /* Firefox */
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
@-webkit-keyframes fadein {
  /* Safari and Chrome */
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
@-o-keyframes fadein {
  /* Opera */
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
</style>
