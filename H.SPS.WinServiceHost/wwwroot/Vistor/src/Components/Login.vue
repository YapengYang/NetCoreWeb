<template>
  <div style="display:flex; align-items:center;justify-content:center;width:100%;height:100%;background-size:100%;" v-bind:style="{backgroundImage:'url(' + backgroundImage + ')'}">

        <el-card class="box-card" style="width:400px;height:250px; ">
            <div slot="header" class="clearfix">
                <span>访客系统</span>
            </div>
            <div>
                <el-form   label-width="100px">
                    <el-form-item label="用户名" prop="name">
                        <el-input v-model="loginModel.no" style="width:180px" ></el-input>
                    </el-form-item>
                    <el-form-item label="密码" prop="pass">
                        <el-input type="password"  v-model="loginModel.pwd"  auto-complete="off" style="width:180px"></el-input>
                    </el-form-item>
                    <el-form-item>
                        <el-checkbox v-model="rememberPwd">记住密码</el-checkbox>
                        <el-button type="primary" @click="login" style="margin-left:35px;">登录</el-button>
                    </el-form-item>
                </el-form>    
            </div>
        </el-card>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
@Component
export default class Login extends Vue {
    backgroundImage:string=require("Assets/login_bgd.png")
    loginModel:API.QueryVistorOperatorReq={};
    rememberPwd:boolean=false;
    created(){
        this.loadCookie();
    }
    login(){
        Env.BizVistor.queryVistorOperator(this.loginModel).then(r=>{
            if(r.returnCode==0){
                if(this.rememberPwd){
                    this.setCookie(this.loginModel.no,this.loginModel.pwd,"1");
                }else{
                    this.clearCookie();
                }
                this.$emit("navigate","Main");
            }else{
                this.$notify.error({title:"",message:"用户名或密码错误"});
            }
        }).catch(e=>{
            this.$notify.error({title:"",message:"服务不在线"});
        });
        //if ok
        
    }
    setCookie(c_name, c_pwd,remember) {
        window.document.cookie = "sst_userName=" + c_name + ";path=/;expires=2030-12-31";
        window.document.cookie = "sst_userPwd=" + c_pwd + ";path=/;expires=2030-12-31";
        window.document.cookie = "sst_rememberPwd=" + remember + ";path=/;expires=2030-12-31";
    }

    loadCookie() {
        if (document.cookie.length > 0) {
            var arr = document.cookie.split('; ');
            for (var i = 0; i < arr.length; i++) {
                var arr2 = arr[i].split('='); 
                if (arr2[0] == 'sst_userName') {
                    this.loginModel.no = arr2[1]; 
                } else if (arr2[0] == 'sst_userPwd') {
                    this.loginModel.pwd = arr2[1];
                }
                else if (arr2[0] == 'sst_rememberPwd') {
                    this.rememberPwd = arr2[1]=="1";
                }
            }
        }
        if(!this.rememberPwd){
            this.loginModel.no="";
            this.loginModel.pwd="";
        }
    }
    clearCookie():void  {
      this.setCookie("", "",""); //修改2值都为空，天数为负1天就好了
    }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
