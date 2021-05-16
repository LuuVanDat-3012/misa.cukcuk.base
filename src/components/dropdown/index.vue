<template>
  <div class="dropdown">
    <div>
      <div class="btnDrop">Thêm khách hàng</div>
      <div class="dropdown-content">
        <div>Vip</div>
        <div>Thường</div>
      </div>
    </div>
  </div>
</template>
<script>
export default {};
</script>
<style>
.btnDrop {
  border: 1px solid #bbbbbb;
  padding: 6px ;
  font-size: 13px;
  cursor: pointer;
  border-radius: 3px;
  height: 40px;
  box-sizing: border-box;
  margin: 0;
}
.dropdown {
  position: relative;
  display: inline-block;
}
.dropdown-content{
    display: none;
    position: absolute;
    z-index: 1;
}
.dropdown-content div{
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  width:100%;
  border-left: 1px solid #bbbbbb;
  border-right: 1px solid #bbbbbb;
}
.dropdown-content div:hover{
    background-color: #E9BEBE;
}
.dropdown:hover .dropdown-content {
  display: block;
}
</style>
