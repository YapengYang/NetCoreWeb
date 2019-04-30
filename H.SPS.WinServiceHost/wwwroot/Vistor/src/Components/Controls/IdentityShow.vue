<template>
    <div class="hLayout">
        <div id="divMain" class="">
            <!--标题-->
            <div style="grid-column-end: span 3">
                <span style="font-weight:bold">访客基本信息</span>
                <span style="font-size:12px">(刷身份证自动读取或者选择类型后点扫描)</span>
            </div>
            <!--第1行-->
            <span style="justify-self:end">证件类型：</span>
            <el-select v-model="idType"><el-option label="第二代身份证" value="第二代身份证"></el-option></el-select>
            <el-button  type="primary" style="width:80px">扫描</el-button>
            <!--第2行-->
            <span style="justify-self:end">证件号码：</span>
            <el-input></el-input>
            <img :src="personImageUrl" style="height:100%;widht:100%;grid-row-end: span 3"/>
            <!--第3行-->
            <span style="justify-self:end">姓名：</span>
            <el-input clearable> </el-input>        
            <!--第4行-->
            <span style="justify-self:end">性别：</span>
            <el-select v-model="sexType"><el-option label="男" :value="0"></el-option><el-option label="女" :value="1"></el-option></el-select>        
            <!--第5行-->
            <span style="justify-self:end">地址：</span>
            <el-input clearable style="grid-column-end: span 2"> </el-input>

        </div>
    </div>
    
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class IdentityShow extends Vue {
    personImageUrl:string=require("Assets/personImg.jpg")
    idType:string="第二代身份证";
    sexType:number=0;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#divMain
{
    padding:10px;
    width:340px;
    height:220px; 
    display:grid;
    grid:auto/80px 1fr 80px;
    grid-gap:10px;
    align-items:center;
    align-content:start;
}
</style>
