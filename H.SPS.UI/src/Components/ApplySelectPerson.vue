<template>
    <div class="vLayout" style="" >
        <div class="v0 hLayout" style="height:60px;" >
            <el-input placeholder="请输入被访人手机号码或者姓名"  style="width:300px;" v-model="inputText" class="input-with-select">
                <el-button slot="append" icon="el-icon-search" @click="search"></el-button>
            </el-input>
        </div>
        <div class="v1" style="" >
            
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class ApplySelectPerson extends Vue {
    inputText:string="";
    search(){
        this.$emit('navigate','ApplyVistorInfo')
    }
    
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
