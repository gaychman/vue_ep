<template>
    <div id="main_canvas" :style="{ left: x + 'px', top: y + 'px', width: width + 'px', height: height + 'px'}">
        <slot></slot>

        <div class="thumb" id="thumb_nw" @mousedown.prevent="drag_nw($event)"></div>
        <div class="thumb" id="thumb_n" @mousedown.prevent="drag_n($event)"></div>
        <div class="thumb" id="thumb_ne" @mousedown.prevent="drag_ne($event)"></div>
        <div class="thumb" id="thumb_w" @mousedown.prevent="drag_w($event)"></div>
        <div class="thumb" id="thumb_e" @mousedown.prevent="drag_e($event)"></div>
        <div class="thumb" id="thumb_sw" @mousedown.prevent="drag_sw($event)"></div>
        <div class="thumb" id="thumb_s" @mousedown.prevent="drag_s($event)"></div>
        <div class="thumb" id="thumb_se" @mousedown.prevent="drag_se($event)"></div>
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
                this.exec_drag(event, (dx, dy) => { this.width += dx; });
            },
            drag_w(event) {
                this.exec_drag(event, (dx, dy) => { this.x += dx; this.width -= dx; });
            },
            drag_n(event) {
                this.exec_drag(event, (dx, dy) => { this.y += dy; this.height -= dx; });
            },
            drag_s(event) {
                this.exec_drag(event, (dx, dy) => { this.height += dy; });
            },
            drag_se(event) {
                this.exec_drag(event, (dx, dy) => { this.height += dy; this.width += dx; });
            },
            exec_drag(event, fn) {
                var old_handler = document.onmousemove;
                var start_x = event.pageX;
                var start_y = event.pageY;
                document.onmousemove = function (e) {
                    fn(e.pageX - start_x, e.pageY - start_y);
                    start_x = e.pageX;
                    start_y = e.pageY;
                };
                document.onmouseup = function (e) {
                    document.onmousemove = old_handler;
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