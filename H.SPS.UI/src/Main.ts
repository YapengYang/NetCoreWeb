// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import ElementUI from 'element-ui'
import '../theme/index.css'
import 'Assets/global.css'
import App from './App.vue'
import Login from 'Components/Login.vue'
import Main from 'Components/Main.vue'
import Home from 'Components/Home.vue'

import PrintDemo from 'Components/PrintDemo.vue'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
import * as PortableFetch from "portable-fetch"
import Print from 'utils/Print'

//import Axios from 'axios'
Vue.config.productionTip = false
//Vue.use(ElementUI, { size: 'large' })
Vue.use(ElementUI, { size: 'mini' })
Vue.use(Print);
Vue.component('App',App);
Vue.component('Login',Login);
Vue.component('Main',Main);
Vue.component('Home',Home);

Vue.component('PrintDemo',PrintDemo);
//console.log("xxxxx"+process.env.NODE_ENV);
Env.BizSystem=new API.SystemApi(new API.Configuration(),"http://localhost:8081",PortableFetch)
Env.BizVistor=new API.VistorApi(new API.Configuration(),"http://localhost:8081",PortableFetch)

new Vue({
  el: '#app',
  components: { App },
  template: '<App/>'
})
