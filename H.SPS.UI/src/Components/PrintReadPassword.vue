<template>
    <div style="display:grid;grid:1fr 1fr 1fr/auto;">
        <div class="hLayout">
            <el-input  type="password"  v-model="password" placeholder="请输入八位数字取证码" style="width:200px"></el-input>
        </div>
        <div class="hLayout"  style="align-items:start">
            <el-button class="pwdKey" size="large" @click="input('1')">1</el-button>
            <el-button class="pwdKey" size="large" @click="input('2')">2</el-button>
            <el-button class="pwdKey" size="large" @click="input('3')">3</el-button>
            <el-button class="pwdKey" size="large" @click="input('4')">4</el-button>
            <el-button class="pwdKey" size="large" @click="input('5')">5</el-button>
            <el-button class="pwdKey" size="large" @click="input('6')">6</el-button>
            <el-button class="pwdKey" size="large" @click="input('7')">7</el-button>
            <el-button class="pwdKey" size="large" @click="input('8')">8</el-button>
            <el-button class="pwdKey" size="large" @click="input('9')">9</el-button>
            <el-button class="pwdKey" size="large" @click="input('0')">0</el-button>
            <el-button class="pwdKey" size="large"  @click="clear">清除</el-button>
        </div>
        <div class="hLayout" style="align-items:start" >
            <el-button type="primary"  @click="cancel">取消</el-button>
            <el-button type="primary"   @click="ok">确认</el-button>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
@Component
export default class PrintReadPassword extends Vue {
    imageUrl:string=require("Assets/read_identity.gif")
    password:string="";
 
    cancel():void{
        this.$emit("navigate","Home");
    }
    ok():void{
        Env.BizVistor.queryVistorApproveResult({code:this.password,requestType:1}).then(r=>{
            
            if(r.returnCode==0){
                this.$notify.success({title:"",message:"查询成功"});
                this.$emit("navigate","PrintReadIdentity");
            }else{
                this.$notify.error({title:"",message:"无申请记录"});
            }
        }).catch(e=>{
            this.$notify.error({title:"",message:"服务不在线"});
        });
        
    }
    input(key:string){
        this.password=this.password+key;
    }
    clear():void{
        this.password="";
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.pwdKey
{
    margin:10px;
    font-weight:bold;
}
</style>
