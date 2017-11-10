<template>
    <div>
        <h1>структура курса</h1>
        <div v-for="item in items">
            <md-toolbar class="md-dense" md-theme="green">
                <md-button class="md-icon-button">
                    <md-icon>menu</md-icon>
                </md-button>

                <h2 class="md-title" style="flex: 1">{{ item.title }}</h2>

                <md-button class="md-icon-button">
                    <md-icon>list</md-icon>
                    <md-tooltip>Добавить экран</md-tooltip>
                </md-button>
                <md-button class="md-icon-button">
                    <md-icon>list</md-icon>
                    <md-tooltip>Добавить подраздел</md-tooltip>
                </md-button>
                <md-button class="md-icon-button">
                    <md-icon>list</md-icon>
                    <md-tooltip>Добавить тест</md-tooltip>
                </md-button>
                
            </md-toolbar>
            
            <a href="#" v-for="s in item.screens" @click.stop="openScreen(s)"><md-card :style="{width: '120px', height: '90px' }">{{ s.title }}</md-card></a>
            
        </div> 
    </div>
</template>

<script>
    export default {
        data() {
            return {
                items: [{ title: "test", screens: [{ title: "test", id: 45, objects: [{ type: "bar", x: 30, y: 50, w: 200, h: 150, id: 'o1', background: {color: '#aa00aa'} }]}]}]
            };
        },
        methods: {
            openScreen(s) {
                this.$router.push({ name: 'screen-editor', params: { sid: s.id } });
            }
        }
    }
</script>