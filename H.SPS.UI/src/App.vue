<template>
    <div id="mainBody" style="width:100%;height:100%;">
        <component v-bind:is="currentView" @navigate="navigate" style="width:100%;height:100%;"  />
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class App extends Vue {
    currentView:string='PrintDemo';
    navigate(view:string){
        this.currentView=view;
    }
}
</script>

<style>

</style>
