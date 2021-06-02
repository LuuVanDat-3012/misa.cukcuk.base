<template>
    <div class="popup-container">
        <div class="popup-model"></div>
        <div class="popup">
            <div class="popup-title">
                <div class="content-title">Xoá bản ghi</div>
                <div class="btn-close"></div>
            </div>
            <div class="popop-content">
                <div class="content-icon"></div>
                <div class="content-text">Bạn có chắc muốn xoá các bản ghi đã chọn ?</div>
            </div>
            <div class="popup-button">
                <div class="btn-cancel">
                   Huỷ bỏ
                </div>
                <div class="btn-confirm">
                    Xoá
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  name: 'PopupDelete'
}
</script>
<style >
@import url("./PopupDetele.css");
</style>
