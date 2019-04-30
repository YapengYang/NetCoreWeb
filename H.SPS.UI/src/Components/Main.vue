<template>
    <div style="display:flex;flex-direction:column;width:100%;height:100%;">
        <div style="flex:0 0 auto;height:100px;background-size:100%;" v-bind:style="{backgroundImage:'url(' + bannerImage + ')'}">
        </div>
        <div style="flex:1 1 auto;height:1px;background-size:100%;"  v-bind:style="{backgroundImage:'url(' + contentImage + ')'}">
            <component v-bind:is="currentView" @navigate="navigate" style="width:100%;height:100%;"  />
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class Main extends Vue {
    bannerImage:string=require("Assets/home_banner.jpg");
    contentImage:string=require("Assets/bg3.jpg");
    currentView:string='Home';
    navigate(view:string){
        this.currentView=view;
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
