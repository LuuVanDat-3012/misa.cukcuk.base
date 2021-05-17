import Vue from 'vue';
import moment from 'moment';

Vue.filter('formatDate', (val) => moment(String(val)).format('DD/MM/YYYY'));

Vue.filter('formatGender', (val) => {
  if (val === 0) return 'Nam';
  if (val === 1) return 'Nữ';
  return 'Khác';
});
Vue.filter('frontEndDateFormat', (date) => moment(date, 'YYYY-MM-DD').format('DD/MM/YYYY'));
