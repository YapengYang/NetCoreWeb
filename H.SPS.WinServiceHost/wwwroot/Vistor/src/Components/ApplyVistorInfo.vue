<template>
    <div class="vLayout" style="align-items:stretch">
        <div  class="v0  hLayout" style="height:280">
            <IdentityInput  class="h0" :model="vistorModel" style="align-self:start;" />

            <VideoCapture class="h1 " style="align-self:stretch;margin: 0 10px;"/>

            <div  class="h0" style="width:340px">
                <div id="divOtherInfo">

                </div>
            </div>
        </div>
        <div class="hLine"/>
        <div style="padding:10px 10px 20px 10px">
            <span style="font-weight:bold">访客其他信息</span>
        </div>
        <div id="divOtherInfo"  class="v0" style="height:280">
            <!--第1行-->
            <span class="spanTextAlign"><span style="color:red">*</span>来访人手机号码：</span>
            <el-input class="inputWidth" v-model="vistorModel.mobile"></el-input>
            <span  class="spanTextAlign">随行人数：</span>
            <el-input-number class="inputWidth" v-model="vistorModel.entourageCount" :min="0" :max="100"></el-input-number>
            <span  class="spanTextAlign">车牌号码：</span>
            <el-input class="inputWidth" v-model="vistorModel.carNO"></el-input>
            <!--第2行-->
            <span  class="spanTextAlign"><span style="color:red">*</span>来访日期：</span>
            <el-date-picker class="inputWidth" v-model="startDate" type="daterange" unlink-panels :picker-options="pickerOptions1" range-separator="至" start-placeholder="开始日期" end-placeholder="结束日期"> </el-date-picker>
            <span  class="spanTextAlign"><span style="color:red">*</span>来访时段：</span>
            <TimePicker class="inputWidth" start="08:00" end="20:00" step="30" />
            <span  class="spanTextAlign">来访事由：</span>
            <ComboBox class="inputWidth" :items="['面试','亲朋好友']" v-model="vistorModel.vistorReason"/>

        </div>
        
        <div style="padding:10px 10px 20px 10px;">
            <span style="font-weight:bold">被访人信息</span>
        </div>
        <div id="divOtherInfo2"  class="v0" style="height:280">
            <!--第1行-->
            <span class="spanTextAlign">被访人姓名：</span>
            <span>{{vistorModel.vistorPersonName}}</span>
            <span  class="spanTextAlign">被访人手机：</span>
            <span>{{vistorModel.vistorPersonMobile}}</span>
            <span  class="spanTextAlign">被访人部门：</span>
            <span>{{vistorModel.vistorDeptName}}</span>

        </div>
        <div  class="v1 hLayout">
            <el-button type="primary" style="width:120px;margin:0px 40px;"  @click="apply">提交登记</el-button>
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
export default class ApplyVistorInfo extends Vue {
    vistorModel:API.VistorInfo={vistorReason:"sssss"};
    startDate:Date=new Date();
    pickerOptions1:any= {
        disabledDate(time):boolean {
            let now=new Date();
            let end=new Date();
            now.setDate(now.getDate()-1);
            end.setDate(end.getDate()+7);
            return time.getTime() <now || time.getTime()>end;
        },
        shortcuts:[{
            text: '今天',
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              picker.$emit('pick', [start, end]);
            }
          }, {
            text: '明天',
            onClick(picker) {
              const end = new Date();
              end.setTime(end.getTime() + 3600 * 1000 * 24 * 1);
              picker.$emit('pick', [end, end]);
            }
          }, {
            text: '最近2天',
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              end.setTime(end.getTime() + 3600 * 1000 * 24 * 1);
              picker.$emit('pick', [start, end]);
            }
        }, {
            text: '最近3天',
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              end.setTime(end.getTime() + 3600 * 1000 * 24 * 2);
              picker.$emit('pick', [start, end]);
            }
        }, {
            text: '最近1周',
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              end.setTime(end.getTime() + 3600 * 1000 * 24 * 6);
              picker.$emit('pick', [start, end]);
            }
        }]
        
    };
    pickerOptions2:any= {
        selectableRange: '18:30:00 - 20:30:00'
    }
    goHome(){
        this.$emit('navigate','Home')
    }
    apply(){
        //alert(JSON.stringify(this.vistorModel));
        Env.BizVistor.postVistorInfo({vistorInfo:this.vistorModel}).then(r=>{
            if(r.returnCode==0){
                this.$notify.success({title:"",message:"提交成功"});
            }else{
                this.$notify.error({title:"",message:"提交失败"});
            }
        }).catch(e=>{
            this.$notify.error({title:"",message:"服务不在线"});
        });
        
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
