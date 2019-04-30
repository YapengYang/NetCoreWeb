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
//import Apply from 'Components/Apply.vue'
import ApplyReadIdentity from 'Components/ApplyReadIdentity.vue'
import ApplySelectPerson from 'Components/ApplySelectPerson.vue'
import ApplyVistorInfo from 'Components/ApplyVistorInfo.vue'
import IdentityInput from 'Components/Controls/IdentityInput.vue'
import VideoCapture from 'Components/Controls/VideoCapture.vue'
import TimePicker from 'Components/BaseControls/TimePicker.vue'
import ComboBox from 'Components/BaseControls/ComboBox.vue'
//import Print from 'Components/Print.vue'
import PrintChoose from 'Components/PrintChoose.vue'
import PrintReadIdentity from 'Components/PrintReadIdentity.vue'
import PrintReadBarcode from 'Components/PrintReadBarcode.vue'
import PrintReadPassword from 'Components/PrintReadPassword.vue'
import PrintVistorInfo from 'Components/PrintVistorInfo.vue'
import VistorDetail from 'Components/Controls/VistorDetail.vue'
import IdentityShow from 'Components/Controls/IdentityShow.vue'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
import * as PortableFetch from "portable-fetch"

//import Axios from 'axios'
Vue.config.productionTip = false
//Vue.use(ElementUI, { size: 'large' })
Vue.use(ElementUI, { size: 'mini' })
Vue.component('App',App);
Vue.component('Login',Login);
Vue.component('Main',Main);
Vue.component('Home',Home);
//Vue.component('Apply',Apply);
Vue.component('ApplyReadIdentity',ApplyReadIdentity);
Vue.component('ApplySelectPerson',ApplySelectPerson);
Vue.component('ApplyVistorInfo',ApplyVistorInfo);
Vue.component('IdentityInput',IdentityInput);
Vue.component('VideoCapture',VideoCapture);
Vue.component('TimePicker',TimePicker);
Vue.component('ComboBox',ComboBox);
//Vue.component('Print',Print);
Vue.component('PrintChoose',PrintChoose);
Vue.component('PrintReadBarcode',PrintReadBarcode);
Vue.component('PrintReadIdentity',PrintReadIdentity);
Vue.component('PrintReadPassword',PrintReadPassword);
Vue.component('PrintVistorInfo',PrintVistorInfo);
Vue.component('VistorDetail',VistorDetail);
Vue.component('IdentityShow',IdentityShow);
//console.log("xxxxx"+process.env.NODE_ENV);
Env.BizSystem=new API.SystemApi(new API.Configuration(),"http://localhost:8081",PortableFetch)
Env.BizVistor=new API.VistorApi(new API.Configuration(),"http://localhost:8081",PortableFetch)

new Vue({
  el: '#app',
  components: { App },
  template: '<App/>'
})
