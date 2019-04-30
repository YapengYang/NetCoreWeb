<template>
    <div class="vLayout" style="align-items:stretch">
        <div  class="v0  hLayout" style="height:280">
            <IdentityShow class="h0" style="align-self:start;"/>

            <VideoCapture class="h1 " style="align-self:stretch;margin: 0 10px;"/>

            <div  class="h0" style="width:340px">
                <div id="divOtherInfo">

                </div>
            </div>
        </div>
        <div class="hLine"/>
        <VistorDetail v-if="recordList.length==1" :record="recordList[0]" />
        <el-table v-else :data="recordList" border style="width: 100%"> 
            <el-table-column fixed prop="date" label="日期" width="150"> </el-table-column>
            <el-table-column prop="userName" label="姓名" width="120"></el-table-column>
            <el-table-column fixed="right" label="操作" width="100">
                <template slot-scope="scope">
                    <el-button @click="viewDetail(scope.row)" type="text" size="small">查看</el-button>
                </template>
            </el-table-column>
        </el-table>
        <div  class="v1 hLayout">
            <el-button type="primary" style="width:120px;margin:0px 40px;"  @click="apply">打印凭证</el-button>
            <el-button type="primary" style="width:120px;margin:0px 40px;" @click="goHome">返回主页</el-button>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
@Component
export default class PrintVistorInfo extends Vue {
    recordList:API.VistorInfo[]=[{userName:"钟峰" }];
    
    goHome(){
        this.$emit('navigate','Home')
    }
    apply(){
        this.$notify.success({title:"",message:"打印成功，请取二维码"});
    }
    viewDetail(index:number){

    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.hLine
{
    width:100%;height:1px;border-top:1px solid rgb(228,228,228)
}
#divOtherInfo,#divOtherInfo2
{
    display:grid;
    grid:auto/150px 1fr 100px 1fr 100px 1fr;
    grid-row-gap: 15px;
}
.inputWidth
{
    width: 200px;
}
.spanTextAlign
{
    justify-self:end
}
</style>
