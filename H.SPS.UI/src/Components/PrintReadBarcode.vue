<template>
    <div style="display:grid;grid:auto 100px 200px/auto;">
        <div class="hLayout">
            <img :src="imageUrl" style="width:250px;height:200px"/>
        </div>
        <div class="hLayout" style="align-items:start">
            <span>请扫二维码</span>
        </div>
        <div class="hLayout" >
            <el-button type="primary"  @click="cancel">取消</el-button>
            <el-button type="primary"   @click="test">模拟刷卡</el-button>
            
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class PrintReadPassword extends Vue {
    imageUrl:string=require("Assets/read_qrcode.gif")
    cancel():void{
        this.$emit("navigate","Home");
    }
    test():void{
        this.$emit("navigate","PrintReadIdentity");
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
