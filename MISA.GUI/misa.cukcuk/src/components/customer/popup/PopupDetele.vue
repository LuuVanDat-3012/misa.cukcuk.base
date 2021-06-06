<template>
    <div class="popup-container">
        <div class="popup-model"></div>
        <div class="popup">
            <div class="popup-title">
                <div class="content-title">Xoá bản ghi</div>
                <div class="btn-close" @click="ClosePopup"></div>
            </div>
            <div class="popop-content">
                <div class="content-icon"></div>
                <div class="content-text">Bạn có chắc muốn xoá các bản ghi đã chọn ?</div>
            </div>
            <div class="popup-button">
                <div class="btn-cancel" @click="ClosePopup">
                   Huỷ bỏ
                </div>
                <div class="btn-confirm" @click="DeleteCustomers">
                    Xoá
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  name: 'PopupDelete',
  data () {
    return {
      recordData: {
        listId: []
      }
    }
  },
  methods: {
    ClosePopup () {
      this.recordData.listId = []
      this.$emit('ClosePopup')
    },
    ReloadData () {
      this.$emit('ReloadData')
    },
    DeleteCustomers () {
      this.axios.post('Customers/multiple', this.listIdDeleted).then(response => {
        this.$vToastify.success(response.data.message)
        this.ClosePopup()
        this.ReloadData()
      }).catch(Exp => {
        this.$vToastify.error('Đã xảy ra lỗi !!!')
        this.ClosePopup()
      })
    }
  },
  props: {
    listIdDeleted: {
      typeof: Array
    }
  }
}
</script>
<style >
@import url("./PopupDetele.css");
</style>
