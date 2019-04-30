<template>
    <el-popover v-model="popoverVisible" placement="bottom-start" trigger="click">
        <div class="vLayout" style="align-items:stretch">
            <span v-for="item in items" :key="item" @click="onSelected" style="line-height:28px">{{item}}</span>
        </div>
        <el-input  slot="reference" placeholder="" v-model="data" @change="onChanged" ></el-input>
    </el-popover>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component({props:['items','value']})
export default class ComboBox extends Vue {
    popoverVisible:boolean=false;
    data:string="";
    created(){
        this.data=this.$props.value;
    }
    onSelected(e){
        this.data=e.currentTarget.innerHTML;
        this.popoverVisible=false;
        this.$emit('input', this.data);
    }
    onChanged(){
        this.$emit('input', this.data);
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
