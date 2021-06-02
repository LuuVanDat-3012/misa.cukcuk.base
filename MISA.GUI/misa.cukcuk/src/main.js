import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'
import './lib/axios'
import './filter/filter'
import VueToastify from 'vue-toastify'
Vue.use(VueToastify, {
  singular: true,
  position: 'top-right',
  theme: 'light'
})

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
