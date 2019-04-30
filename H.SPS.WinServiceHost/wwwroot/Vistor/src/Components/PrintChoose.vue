<template>
    <div class="hLayout">
        <div class="h1 vLayout">
            <img :src="imageUrl1" style="width:250px;height:200px"/>
            <div class="hLayout" style="height:100px;">
                <el-button type="primary" @click="choose('PrintReadIdentity')">身份证取证</el-button>
            </div>
        </div>
        <div class="h1 vLayout">
            <img :src="imageUrl2" style="width:250px;height:200px"/>
            <div class="hLayout" style="height:100px;">
                <el-button type="primary" @click="choose('PrintReadBarcode')">二维码取证</el-button>
            </div>
        </div>
        <div class="h1 vLayout">
            <img :src="imageUrl3" style="width:250px;height:200px"/>
            <div class="hLayout" style="height:100px;">
                <el-button type="primary" @click="choose('PrintReadPassword')">密码取证</el-button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class PrintChoose extends Vue {
    imageUrl1:string=require("Assets/choose_id.png")
    imageUrl2:string=require("Assets/choose_qrcode.png")
    imageUrl3:string=require("Assets/choose_pwd.png")
    choose(view:string){
        this.$emit('navigate',view);
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
