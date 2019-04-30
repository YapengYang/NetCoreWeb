"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
const vue_1 = require("vue");
const element_ui_1 = require("element-ui");
require("../theme/index.css");
require("Assets/global.css");
const App_vue_1 = require("./App.vue");
const Login_vue_1 = require("Components/Login.vue");
const Main_vue_1 = require("Components/Main.vue");
const Home_vue_1 = require("Components/Home.vue");
//import Apply from 'Components/Apply.vue'
const ApplyReadIdentity_vue_1 = require("Components/ApplyReadIdentity.vue");
const ApplySelectPerson_vue_1 = require("Components/ApplySelectPerson.vue");
const ApplyVistorInfo_vue_1 = require("Components/ApplyVistorInfo.vue");
const IdentityInput_vue_1 = require("Components/Controls/IdentityInput.vue");
const VideoCapture_vue_1 = require("Components/Controls/VideoCapture.vue");
const TimePicker_vue_1 = require("Components/BaseControls/TimePicker.vue");
const ComboBox_vue_1 = require("Components/BaseControls/ComboBox.vue");
//import Print from 'Components/Print.vue'
const PrintChoose_vue_1 = require("Components/PrintChoose.vue");
const PrintReadIdentity_vue_1 = require("Components/PrintReadIdentity.vue");
const PrintReadBarcode_vue_1 = require("Components/PrintReadBarcode.vue");
const PrintReadPassword_vue_1 = require("Components/PrintReadPassword.vue");
const PrintVistorInfo_vue_1 = require("Components/PrintVistorInfo.vue");
const VistorDetail_vue_1 = require("Components/Controls/VistorDetail.vue");
const IdentityShow_vue_1 = require("Components/Controls/IdentityShow.vue");
const API = require("Biz/ApiProxy/index");
const Env_1 = require("Biz/Env");
const PortableFetch = require("portable-fetch");
//import Axios from 'axios'
vue_1.default.config.productionTip = false;
//Vue.use(ElementUI, { size: 'large' })
vue_1.default.use(element_ui_1.default, { size: 'mini' });
vue_1.default.component('App', App_vue_1.default);
vue_1.default.component('Login', Login_vue_1.default);
vue_1.default.component('Main', Main_vue_1.default);
vue_1.default.component('Home', Home_vue_1.default);
//Vue.component('Apply',Apply);
vue_1.default.component('ApplyReadIdentity', ApplyReadIdentity_vue_1.default);
vue_1.default.component('ApplySelectPerson', ApplySelectPerson_vue_1.default);
vue_1.default.component('ApplyVistorInfo', ApplyVistorInfo_vue_1.default);
vue_1.default.component('IdentityInput', IdentityInput_vue_1.default);
vue_1.default.component('VideoCapture', VideoCapture_vue_1.default);
vue_1.default.component('TimePicker', TimePicker_vue_1.default);
vue_1.default.component('ComboBox', ComboBox_vue_1.default);
//Vue.component('Print',Print);
vue_1.default.component('PrintChoose', PrintChoose_vue_1.default);
vue_1.default.component('PrintReadBarcode', PrintReadBarcode_vue_1.default);
vue_1.default.component('PrintReadIdentity', PrintReadIdentity_vue_1.default);
vue_1.default.component('PrintReadPassword', PrintReadPassword_vue_1.default);
vue_1.default.component('PrintVistorInfo', PrintVistorInfo_vue_1.default);
vue_1.default.component('VistorDetail', VistorDetail_vue_1.default);
vue_1.default.component('IdentityShow', IdentityShow_vue_1.default);
//console.log("xxxxx"+process.env.NODE_ENV);
Env_1.Env.BizSystem = new API.SystemApi(new API.Configuration(), "http://localhost:8081", PortableFetch);
Env_1.Env.BizVistor = new API.VistorApi(new API.Configuration(), "http://localhost:8081", PortableFetch);
new vue_1.default({
    el: '#app',
    components: { App: App_vue_1.default },
    template: '<App/>'
});
//# sourceMappingURL=Main.js.map