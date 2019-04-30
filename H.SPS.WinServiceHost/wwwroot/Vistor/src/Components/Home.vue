<template>
    <div style="width:100%;height:100%;display:grid;grid-template-columns:50% 50%;grid-template-rows:100%;justify-items:center;align-items:center;">
        <div style="width:300px;height:50px;text-align:center;">
            <el-button type="primary"  @click="navigate('ApplyReadIdentity')">访客申请</el-button>
        </div>
        <div style="width:300px;height:50px;text-align:center;">
            <el-button type="primary"   @click="navigate('PrintChoose')">打印凭证</el-button>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class Home extends Vue {

    navigate(view:string){
        this.$emit("navigate",view);
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
