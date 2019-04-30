<template>
    <el-popover v-model="popoverVisible" placement="bottom" trigger="click">
        <div style="display:grid;grid:auto/60px 60px 60px 60px 60px 60px 60px 60px">
            <span class="timePoint" :index="time.index" :selected1="time.selected" :preSelected1="time.preSelected" v-for="time in times" :key="time.name" @click="onSelected" @mouseover="onHover">{{time.name}}</span>
        </div>
        <div class="hLayout">
            <span>{{msg()}}</span>
            <div class="h1"/>
            <el-button type="primary" :disabled="isNotCompleted" @click="onOK">确认</el-button>
        </div>
        <el-input  slot="reference" placeholder="" v-model="timeRegion"></el-input>
    </el-popover>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import { ElStep } from 'element-ui/types/step';
@Component({props:['start','end','step']})
export default class TimePicker extends Vue {
    times:any[]=[];
    selectStep:number=0;
    isNotCompleted:number=1;
    popoverVisible:boolean=false;
    timeRegion:string="";
    created(){
        
        let start=new Date("2000-01-01 "+<string>this.$props.start);
        
        let end=new Date("2000-01-01 "+<string>this.$props.end);
        let step=parseInt(this.$props.step.toString());

        let current=new Date("2000-01-01 "+<string>this.$props.start);
        let index=0;
        while(true){
            let strHour='';
            let strMinitue=''
            if(current.getHours()<10)
                strHour='0'+current.getHours();
            else
                strHour=''+current.getHours();
            if(current.getMinutes()<10)
                strMinitue='0'+current.getMinutes();
            else
                strMinitue=''+current.getMinutes();

            this.times.push({name:strHour+":"+strMinitue,selected:0,preSelected:0,index:index++});

            current.setMinutes(current.getMinutes()+step);
            
            if(current>end)
                break;
        }
    }
    onSelected(e){
        if(this.selectStep==0 || this.selectStep==2){
            //选择开始时间
            for(let i=0;i<this.times.length;++i){
                this.times[i].selected=0;
            }
            let index=e.currentTarget.attributes["index"].nodeValue;
            this.times[index].selected=1;
            this.selectStep=1;
        }else if(this.selectStep==1){
            let startIndex=0;
            let endIndex=e.currentTarget.attributes["index"].nodeValue;
            for(let i=0;i<this.times.length;++i){
                this.times[i].preSelected=0;
                if(this.times[i].selected){
                    startIndex=i;
                }
            }
            if(endIndex<startIndex){
                let temp=startIndex;
                startIndex=endIndex;
                endIndex=temp;
            }
            for(let i=startIndex;i<=endIndex;++i){
                this.times[i].selected=1;
            }
            this.selectStep=2;
            this.isNotCompleted=0;
        }
        
    }
    onHover(e){
        if(this.selectStep==1){
            let startIndex=0;
            let endIndex=e.currentTarget.attributes["index"].nodeValue;
            for(let i=0;i<this.times.length;++i){
                this.times[i].preSelected=0;
                if(this.times[i].selected){
                    startIndex=i;
                }
            }
            if(endIndex<startIndex){
                let temp=startIndex;
                startIndex=endIndex;
                endIndex=temp;
            }
            for(let i=startIndex;i<=endIndex;++i){
                this.times[i].preSelected=1;
            }
        }
    }
    msg():string{
        if(this.selectStep==0){
            return "请点击选择开始时间";
        }else if(this.selectStep==1) {
            return "请选择结束时间";
        }else{
            return "点击确认关闭";
        }
    }
    onOK(){
        let start="";
        let end="";
        for(let i=0;i<this.times.length;++i){
            if(this.times[i].selected){
                start=this.times[i].name;
                break;
            }
        }
        for(let i=this.times.length-1;i>=0;--i){
            if(this.times[i].selected){
                end=this.times[i].name;
                break;
            }
        }
        this.timeRegion=start+"-"+end;
        this.popoverVisible=false;
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.timePoint
{
    line-height: 38px;
}
.timePoint:hover
{
    color: darkblue;
    
}
.timePoint[selected1="1"]{
    color:rgb(64, 158, 255);
}
.timePoint[selected1="1"]:hover
{
    color: darkblue;
    
}
.timePoint[preSelected1="1"]{
    background-color: rgb(242, 246, 252)
}
</style>
