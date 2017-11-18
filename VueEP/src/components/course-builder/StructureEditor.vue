<template>
    <div>
        <h1>структура курса</h1>
        <md-button class="md-icon-button md-raised md-primary" @click="showAddStructureDialog">
            <md-icon>add</md-icon>
        </md-button>
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
                <md-button class="md-icon-button">
                    <md-icon>settings</md-icon>
                    <md-tooltip>свойства раздела</md-tooltip>
                </md-button>
                <md-button class="md-icon-button">
                    <md-icon>trash</md-icon>
                    <md-tooltip>удалить</md-tooltip>
                </md-button>

            </md-toolbar>
            
            <a href="#" v-for="s in item.screens" @click.stop="openScreen(s)"><md-card :style="{width: '120px', height: '90px' }">{{ s.title }}</md-card></a>
            
        </div>
        
        <md-dialog md-open-from="#custom" md-close-to="#custom" ref="structure-edit-dialog">
            <md-dialog-title>{{ dlgData.dlgTitle }}</md-dialog-title>
            <md-dialog-content>
                <form novalidate @submit.stop.prevent="submit">
                    <md-input-container>
                        <label>Название</label>
                        <md-input required v-model="dlgData.name"></md-input>
                    </md-input-container>
                </form>
            </md-dialog-content>
            <md-dialog-actions>
                <md-button class="md-primary" @click="closeDialog()">Закрыть</md-button>
                <md-button class="md-primary" @click="saveData()">Ok</md-button>
            </md-dialog-actions>
        </md-dialog>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                items: [{ title: "test", screens: [{ title: "test", id: 45, objects: [{ type: "bar", x: 30, y: 50, w: 200, h: 150, id: 'o1', background: { color: '#aa00aa' } }] }] }],
                dlgData: {
                    dlgTitle: '', name: '', id: 0
                }
            };
        },
        methods: {
            openScreen(s) {
                this.$router.push({ name: 'screen-editor', params: { sid: s.id } });
            },
            showAddStructureDialog() {
                this.dlgData.dlgTitle = 'Добавить раздел';
                this.dlgData.name = '';
                this.dlgData.id = 0;
                this.$refs["structure-edit-dialog"].open();
            },
            closeDialog() {
                this.$refs['structure-edit-dialog'].close();
            },
            saveData() {
                this.$refs['structure-edit-dialog'].close();
                this.items.push({title: this.dlgData.name});
            },
        }
    }
</script>