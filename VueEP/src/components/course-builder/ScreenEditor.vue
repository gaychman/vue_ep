<template>
    <div>
        <md-toolbar class="md-transparent">
            <md-button class="md-icon-button">
                <md-icon>undo</md-icon>
                <md-tooltip>Отменить</md-tooltip>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>redo</md-icon>
                <md-tooltip>Вернуть</md-tooltip>
            </md-button>

            <md-menu md-size="4" md-direction="top right" ref="menu">
                <md-button class="md-icon-button" md-menu-trigger>
                    <md-icon>add</md-icon>
                    <md-tooltip>Создать объект</md-tooltip>
                </md-button>

                <md-menu-content>
                    <md-menu-item>Прямоугольник</md-menu-item>
                    <md-menu-item>Рисунок</md-menu-item>
                    <md-menu-item>Текст</md-menu-item>                         
                </md-menu-content>
            </md-menu>
            <md-button class="md-icon-button">
                <md-icon>content_cut</md-icon>
                <md-tooltip>Вырезать</md-tooltip>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>content_copy</md-icon>
                <md-tooltip>Копировать</md-tooltip>
            </md-button>
            <md-button class="md-icon-button">
                <md-icon>content_paste</md-icon>
                <md-tooltip>Вставить</md-tooltip>
            </md-button>
        </md-toolbar>

        <div style="background: white; position: relative; width: 800px; height: 600px; border: 1px solid black;">
            <cb-resizable v-for="object in objects">
                <component :info="object"></component>
            </cb-resizable>
        </div>
    </div>
</template>

<script>
    import Resizable from './Resizable.vue';
    import Bar from './objects/Bar.vue';

    export default {
        data() {
            return {
                id: this.$route.params.id,
                objects: [{ type: "bar", x: 10, y: 50, width: 400, height: 300, color: "red" }, { type: "bar", x: 150, y: 50, width: 200, height: 130, color: "green" }]
            };
        },
        watch: {
            "$route"(to) {
                id = to.params.id;
            }
        },
        components: {
            cbResizable: Resizable,
            objBar: Bar
        }
    }
</script>