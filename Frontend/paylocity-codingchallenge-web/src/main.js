import Vue from 'vue'
import './plugins/vuetify'
import './plugins/axios'
import './plugins/vue2filters'
import App from './App.vue'

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
