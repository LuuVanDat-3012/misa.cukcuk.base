<template>
  <div class="dropdown">
    <button class="dropbtn">{{ title.customerGroupName }}</button>
    <div class="drop-content">
      <div
        class="item"
        v-for="(item, index) in customerGroup"
        :key="index"
        @click="GetCustomerGroup(item)"
      >
        <div :class="{ contentIcon: isHover }" class="content-icon-null"></div>
        <div class="content-text">{{ item.customerGroupName }}</div>
      </div>
    </div>
  </div>
</template>
<script>
// optional css
import '@invisiburu/vue-picker/dist/vue-picker.min.css';

export default {
  components: {},
  data() {
    return {
      customerGroup: [],
      isHover: false,
      title: {
        customerGroupId: '11111111-1111-1111-1111-111111111111',
        customerGroupName: 'Tất cả các khách hàng',
      },
    };
  },
  methods: {
    GetCustomerGroup(val) {
      this.title = val;
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
  padding: 6px 16px 6px 16px;
  background-color: #ffffff;
  color: #000;
  width: 200px;
  border: 0;
  border-radius: 4px;
  height: 40px;
  border: 1px solid #bbbbbb;
  text-align: left;
}
.dropbtn:hover {
  border: 2px solid #019160;
}
.drop-content {
  display: none;
  position: absolute;
  z-index: 99999999999999;
  min-width: 200px;
  background-color: #ffffff;
  padding-top: 3px;
   animation: animationPopup 2s forwards;
}
.dropdown:hover .drop-content {
  display: block;
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
.content-icon-null {
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
        opacity:0;
    }
    to {
        opacity:1;
    }
}
@-moz-keyframes fadein { /* Firefox */
    from {
        opacity:0;
    }
    to {
        opacity:1;
    }
}
@-webkit-keyframes fadein { /* Safari and Chrome */
    from {
        opacity:0;
    }
    to {
        opacity:1;
    }
}
@-o-keyframes fadein { /* Opera */
    from {
        opacity:0;
    }
    to {
        opacity: 1;
    }
}
</style>
