<template>

    <div  id="divMain"  class="vLayout">
        <!--标题-->
        <div class="v0">
            <span style="font-weight:bold">访客照片</span>
            <span style="font-size:12px">(点击预览打开原图)</span>
        </div>
        <!--视频-->
        <div  class="v1" style="width:100%;position: relative;">
            <video autoplay ref="video1" style="width:100%;height:100%;position:absolute;object-fit: fill"/>

            <canvas ref="canvas" style="width:100%;height:100%;border:2px solid red;visibility:hidden;" ></canvas>

            
        </div>
        

        <span class="v0 vLayout" style="font-size:10px;line-height:30px;">(请拍摄人脸正面照片,照片质量将直接影响访客通行)</span>
        <div class="v0">
            <el-button type="primary" style="width:80px" @click="capture">拍照</el-button>
        </div>
    </div>

</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class VideoCapture extends Vue {
    
    created(){
        navigator.getUserMedia({audio:false, video:true},stream=>(<any>this.$refs.video1).src = window.URL.createObjectURL(stream), function() {});
    }
    capture(){
        let video = <any>this.$refs.video1;
        let canvas = <any>this.$refs.canvas;
        canvas.style.visibility="visible";
        video.style.visibility="hidden";
        let context = canvas.getContext('2d');

        context.drawImage(video, 0, 0, video.clientWidth, video.clientHeight);      

    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#divMain
{
    padding:10px;
    width:340px;
    height:280px; 
}
</style>
