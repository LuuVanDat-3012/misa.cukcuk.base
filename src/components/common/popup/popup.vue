<template>
  <div class="container-popup">
    <div class="popup-model"></div>
    <div class="popup"></div>
  </div>
</template>
<script>
export default {};
</script>
<style>
.popup-model {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  z-index: 99999;
  opacity: 0.6;
}
.popup {
  width: 400px;
  height: 204px;
  background-color: red;
  z-index: 999999999;
  position: absolute;
  top: calc(50% - 102px);
  left: calc(50% - 200px);
  /* animation: animationDialog 0.5s forwards; */
  border: 1px solid #bbbbbb;
  border-radius: 2px;
}
</style>
