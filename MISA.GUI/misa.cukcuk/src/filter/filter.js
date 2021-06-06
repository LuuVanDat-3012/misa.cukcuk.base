import Vue from 'vue'
import moment from 'moment'

Vue.filter('formatDate', (val) => moment(val).format('DD/MM/YYYY'))

Vue.filter('formatGender', (val) => {
  if (val === 0) return 'Nam'
  if (val === 1) return 'Nữ'
  if (val === 2) return 'Khác'
  return ''
})
Vue.filter('frontEndDateFormat', (date) => moment(date, 'YYYY-MM-DD').format('DD/MM/YYYY'))

Vue.filter('validateData', (val) => {
  if (val == null || val === '') return false
  return true
})
