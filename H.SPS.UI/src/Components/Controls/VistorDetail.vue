<template>
    <div class="vLayout" style="align-items:stretch">
        <div style="padding:10px 10px 10px 10px">
            <span style="font-weight:bold">预约信息</span>
        </div>
        <div id="divOtherInfo2"  class="v0" style="height:280">
            <span class="spanTextAlign">预约类型：</span>
            <span>线上预约</span>
            <span  class="spanTextAlign">预约来源：</span>
            <span>访客机</span>
            <span  class="spanTextAlign">姓名：</span>
            <span>{{record==null?"":record.userName}}</span>
        </div>
        <div style="padding:10px 10px 10px 10px">
            <span style="font-weight:bold">访客其他信息</span>
        </div>
        <div id="divOtherInfo"  class="v0" style="height:280">
            <!--第1行-->
            <span class="spanTextAlign fieldLabel">来访人手机号码：</span>
            <span class="fieldInfo">13684905530</span>
            <span class="spanTextAlign fieldLabel">车牌号：</span>
            <span class="fieldInfo">粤-A11111</span>
            <span class="spanTextAlign fieldLabel">随行人数：</span>
            <span class="fieldInfo">1</span>
            <!--第2行-->
            <span class="spanTextAlign fieldLabel">来访时间：</span>
            <span class="fieldInfo">2018年05月25日 08:30</span>
            <span class="spanTextAlign fieldLabel">预计离开时间：</span>
            <span class="fieldInfo">2018年05月25日 12:30</span>
            <span class="spanTextAlign fieldLabel">来访事由：</span>
            <span class="fieldInfo">维修空调</span>
        </div>
        
        <div style="padding:10px 10px 10px 10px;">
            <span style="font-weight:bold">被放人信息</span>
        </div>
        <div id="divOtherInfo2"  class="v0" style="height:280">
            <span class="spanTextAlign">被访人姓名：</span>
            <span>张三丰</span>
            <span  class="spanTextAlign">被访人手机：</span>
            <span>13684905530</span>
            <span  class="spanTextAlign">被访人部门：</span>
            <span>产品研发五部</span>
        </div>
        <div  class="v1 hLayout">
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import * as API from 'Biz/ApiProxy/index'
import {Env} from 'Biz/Env'
@Component({props:['record']})
export default class VistorDetail extends Vue {
    record:API.VistorInfo;
    goHome(){
        this.$emit('navigate','Home')
    }
    apply(){
        this.$notify.success({title:"",message:"提交成功"});
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
    grid:auto/150px 1fr 120px 1fr 100px 1fr;
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
