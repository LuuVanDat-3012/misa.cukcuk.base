<template>
  <div class="content">
    <div class="content-header">
      <div class="title">
        <p>DANH SÁCH KHÁCH HÀNG</p>
      </div>
      <div class="btn-insert">
        <div class="btn-insert-icon"></div>
        <div class="btn-insert-text">Thêm khách hàng</div>
      </div>
    </div>
    <div class="content-filter">
      <div class="box-search">
        <div class="box-search-icon"></div>
        <div class="box-search-input">
          <input type="text" />
        </div>
      </div>
      <div class="filter-customer-group">
        <dropdown />
      </div>
      <div class="btn-refresh">
        <div class="btn-refresh-icon"></div>
      </div>
    </div>
    <div class="gird">
      <table>
        <thead>
          <tr>
            <th></th>
            <th>Mã khách hàng</th>
            <th>Họ và tên</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Số diện thoại</th>
            <th>Email</th>
            <th>Mã thẻ thành viên</th>
            <th>Mã số thuế</th>
            <th>Địa chỉ</th>
            <th>Công ty</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(customer, index) in listCustomer"
            :key="index"
            @dblclick="showDialog(customer)"
            :infoCustomer="customer.customerCode"
            :name="customer.fullname"
          >
            <td>
              <input type="checkbox" value="" class="checkboxRow" />
            </td>
            <td>{{ customer.customerCode }}</td>
            <td>{{ customer.fullname }}</td>
            <td>
              {{ customer.gender | formatGender }}
            </td>
            <td>
              {{ customer.birthday | formatDate }}
            </td>
            <td>{{ customer.phone }}</td>
            <td>{{ customer.email }}</td>
            <td>
              {{ customer.memberCardCode }}
            </td>
            <td>{{ customer.taxCode }}</td>
            <td>{{ customer.address }}</td>
            <td>{{ customer.company }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
// eslint-disable-next-line import/extensions
import dropdown from '../dropdown/index';

export default {
  components: {
    dropdown,
  },
};
</script>
<style>
/**
css content
 */
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

/*
*CSS content-header
*/
.content-header {
  width: 100%;
  height: 60px;
  display: flex;
  align-items: center;
}
.content-header .title {
  font-family: MISA-Bold;
  font-size: 20px;
  color: #000000;
}
/**
CSS button thêm khách hàng
 */
.btn-insert {
  height: 40px;
  display: flex;
  background-color: #019160;
  border-radius: 3px;
  align-items: center;
  box-sizing: border-box;
  color: #fff;
  position: absolute;
  right: 24px;
}
.btn-insert-icon {
  background-image: url("../../assets/icon/add.png");
  background-position: 16px 2px;
  width: 20px;
  height: 24px;
  padding: 0px 6px 0px 16px;
  background-repeat: no-repeat;
}
.btn-insert-text {
  padding-right: 16px;
}
.btn-insert:hover {
  background-color: #2fbe8e;
  cursor: pointer;
}
/**
CSS button refresh
 */
.btn-refresh {
  height: 40px;
  width: 40px;
  align-items: center;
  border: 1px solid #bbbbbb;
  border-radius: 3px;
  position: absolute;
  right: 24px;
  box-sizing: border-box;
}
.btn-refresh-icon {
  width: 30px;
  height: 30px;
  background-image: url("../../assets/icon/refresh.png");
  background-repeat: no-repeat;
  background-position: center;
  margin: 5px 0px 0px 5px;
}
.btn-refresh:hover {
  background-color: #e9bebe;
  cursor: pointer;
}

/**
CSS phần filter
*/
.content-filter {
  height: 50px;
  width: 100%;
  display: flex;
}
/**
CSS phần nhập thông tin tìm kiếm
 */
.box-search {
  height: 40px;
  width: 250px;
  display: flex;
  border: 1px solid #bbbbbb;
  box-sizing: border-box;
  border-radius: 3px;
}
.box-search-icon {
  width: 40px;
  height: 100%;
  background-image: url("../../assets/icon/search.png");
  background-repeat: no-repeat;
  background-position: 12px 11px;
}
.box-search-input {
  flex: 1;
  box-sizing: border-box;
}
.box-search-input input {
  width: 100%;
  height: 100%;
  border: none;
  outline: 0;
}
.box-search:hover {
  border: 1px solid #019160;
}
.box-search-input input:focus .box-search {
  border: 1px solid #019160;
}

/**
CSS bảng khách hàng
*/
</style>
