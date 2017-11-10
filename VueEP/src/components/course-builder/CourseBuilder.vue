<template>
    <div>
        <md-toolbar>
            <md-menu md-align-trigger>
                <md-button md-menu-trigger class="md-icon-button"><md-icon>menu</md-icon></md-button>

                <md-menu-content>
                    <md-menu-item @click="newCourse">Новый курс</md-menu-item>
                    <md-menu-item>Загрузить курс</md-menu-item>
                </md-menu-content>
            </md-menu>
            <h2 class="md-title" style="flex: 1">Конструктор курсов</h2>
            <md-button class="md-raised" @click="returnHome()">Вернуться к порталу</md-button>
        </md-toolbar>
        <router-view></router-view>
        <md-dialog md-open-from="#custom" md-close-to="#custom" ref="course-properties-dialog">
            <md-dialog-title>{{ dlgData.dlgTitle }}</md-dialog-title>
            <md-dialog-content>
                <form novalidate @submit.stop.prevent="submit">
                    <md-input-container>
                        <label>Название курса</label>
                        <md-input required v-model="dlgData.name"></md-input>
                    </md-input-container>

                    <md-input-container>
                        <md-icon class="md-warn">
                            Ширина
                            <md-tooltip>Ширина основного окна курса</md-tooltip>
                        </md-icon>
                        <label>Ширина</label>
                        <md-input type="number" v-model="dlgData.width"></md-input>
                    </md-input-container>

                    <md-input-container>
                        <md-icon class="md-warn">
                            Высота
                            <md-tooltip>Высота основного окна курса</md-tooltip>
                        </md-icon>
                        <label>Высота</label>
                        <md-input type="number" v-model="dlgData.height"></md-input>
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
    import * as links from '../../api-links';

    export default {
        data() {
            return {
                dlgData: {dlgTitle: '', width: 600, height: 600, name: '', id: 0}
            };
        },
        methods: {
            returnHome() {
                this.$router.push('/');
            },
            saveData() {
                this.errorMessage = null;
                if (0 == this.dlgData.id) {
                    this.$http.post(links.COURSEBUILDER_PATH, this.dlgData).then(response => {

                    }, response => {
                        this.errorMessage = response.statusText;
                    });
                }
                else {
                    this.$http.patch(links.COURSEBUILDER_PATH, this.dlgData).then(response => {
                        this.loadList();
                    }, response => {
                        this.errorMessage = response.statusText;
                    });
                }
            },
            closeDialog() {
                this.$refs['course-properties-dialog'].close();
            },
            newCourse() {
                this.dlgData.dlgTitle = 'Создать курс';
                this.dlgData.name = '';
                this.dlgData.width = 800;
                this.dlgData.height = 600;
                this.dlgData.id = 0;
                this.$refs["course-properties-dialog"].open();

                //this.$store.actions.newCourse();
            }
        }
    }
</script>