<template>
  <div style="display:flex; align-items:center;justify-content:center;width:100%;height:100%;background-size:100%;" 
  v-bind:style="{backgroundImage:'url(' + backgroundImage + ')'}">
        <el-card class="box-card" style="width:400px;height:250px; ">
             <div slot="header" class="clearfix">
                <span>打印Demo</span>
            </div>
            <div>
                <el-form   label-width="100px">
                    <!-- <el-form-item label="" prop="name">
                        <el-button type="primary" @click="login" style="margin-left:35px;">登录</el-button>
                    </el-form-item> -->
                    <el-form-item label="打印">
                        <el-button type="primary" @click="WindowPrint" style="margin-left:35px;">打印</el-button>
                    </el-form-item>                   
                </el-form>    
            </div>
        </el-card>
  </div>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
//import {Print} from '.../.../utils/print'
@Component
export default class PrintDemo extends Vue {
    backgroundImage = require("Assets/login_bg.jpg")

    // PrintJS(){
    //   Print('#wrap', {
    //     onStart: function () {
    //       console.log('onStart', new Date())
    //     },
    //     onEnd: function () {
    //       console.log('onEnd', new Date())
    //     }
    //   })
    // }

    WindowPrint(){
        Window.Print();
    }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
