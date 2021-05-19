import Vue from 'vue';

// axios
import axios from 'axios';
import VueAxios from 'vue-axios';

// const user = JSON.parse(localStorage.getItem('user'))

const axiosIns = axios.create({
  // You can add your headers here
  // ================================
  baseURL: 'https://localhost:44333/api/',
  // timeout: 1000,
  // headers: {'X-Custom-Header': 'foobar'}
//   headers: user && user.token ? { Authorization: 'Bearer ' + user.token } : {}
});

Vue.prototype.$http = axiosIns;

Vue.use(VueAxios, axiosIns);

export default axiosIns;
