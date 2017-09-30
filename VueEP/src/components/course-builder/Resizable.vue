<template>
    <div id="main_canvas" :style="{ left: x + 'px', top: y + 'px', width: width + 'px', height: height + 'px'}">
        <slot></slot>

        <div class="thumb" id="thumb_nw"></div>
        <div class="thumb" id="thumb_n"></div>
        <div class="thumb" id="thumb_ne"></div>
        <div class="thumb" id="thumb_w"></div>
        <div class="thumb" id="thumb_e" @mousedown.prevent="drag_e($event)"></div>
        <div class="thumb" id="thumb_sw"></div>
        <div class="thumb" id="thumb_s"></div>
        <div class="thumb" id="thumb_se"></div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                width: 100, height: 100, x: 0, y: 0
            };
        },
        methods: {
            drag_e(event) {
                console.log('mouse');
                var that = this;
                var start = event.pageX;
                document.onmousemove = function (e) {
                    that.width += e.pageX - start;
                    start = e.pageX;
                };
                document.onmouseup = function (e) {
                    document.onmousemove = null;    
                };
            }
        }
    }
</script>

<style scoped>
    .thumb{
        width: 8px;
        height: 8px;
        position: absolute;
        border: 1px solid black;
        background: white;
    }

    #thumb_nw {
        left: -8px; top: -8px;
        cursor: nw-resize;
    }

    #thumb_n {
        top: -8px;
        left: calc(50% - 5px);
        cursor: n-resize;
    }

    #thumb_ne {
        right: -8px;
        top: -8px;
        cursor: ne-resize;
    }

    #thumb_w {
        top: calc(50% - 5px);
        left: -8px;
        cursor: w-resize;
    }

    #thumb_e {
        top: calc(50% - 5px);
        right: -8px;
        cursor: e-resize;
    }

    #thumb_sw {
        bottom: -8px;
        left: -8px;
        cursor: sw-resize;
    }

    #thumb_s {
        bottom: -8px;
        left: calc(50% - 5px);
        cursor: s-resize;
    }

    #thumb_se {
        bottom: -8px;
        right: -8px;
        cursor: se-resize;
    }

    #main_canvas
    {
        position: absolute;
        border: 8px solid rgba(0, 0, 0, 0.3);
    }
</style>