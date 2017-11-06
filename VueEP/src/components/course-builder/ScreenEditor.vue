<template>
    <div>
        <md-toolbar class="md-transparent">
            <md-button class="md-icon-button">
                <md-icon>undo</md-icon>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>redo</md-icon>
            </md-button>

            <md-menu md-size="4" md-direction="top right" ref="menu">
                <md-button class="md-icon-button" md-menu-trigger>
                    <md-icon>add</md-icon>
                </md-button>

                <md-menu-content>
                    <md-menu-item>Прямоугольник</md-menu-item>
                    <md-menu-item>Рисунок</md-menu-item>
                    <md-menu-item>Текст</md-menu-item>                         
                </md-menu-content>
            </md-menu>
            <md-button class="md-icon-button">
                <md-icon>cut</md-icon>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>copy</md-icon>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>paste</md-icon>
            </md-button>
        </md-toolbar>

        <div style="background: green; position: relative; width: 800px; height: 600px;">
            <cb-resizable><div style="background: red; width: 100%; height: 100%;"></div></cb-resizable>
            <cb-resizable><div style="background: white; width: 100%; height: 100%;"></div></cb-resizable>
            <cb-resizable><div style="background: yellow; width: 100%; height: 100%;"></div></cb-resizable>
        </div>
    </div>
</template>

<script>
    import Resizable from './Resizable.vue';

    export default {
        data() {
            return {
                id: this.$route.params.id
            };
        },
        watch: {
            "$route"(to) {
                id = to.params.id;
            }
        },
        components: {
            cbResizable: Resizable
        }
    }
</script>