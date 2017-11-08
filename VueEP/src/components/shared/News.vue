<template>
    <div>
        <md-card class="md-accent" v-if="errorMessage != null">
            <md-card-content>{{ errorMessage }}</md-card-content>            
        </md-card>
        <md-spinner md-indeterminate v-if="isLoading"></md-spinner>
        <md-button class="md-icon-button md-raised md-primary" @click="showAddNewsDialog" v-if="isEditable">
            <md-icon>add</md-icon>
        </md-button>
        <md-card v-for="n in news" v-if="errorMessage == null && !isLoading">
            <md-card-header>
                <div class="md-title">{{ n.title }}</div>
                <div class="md-subhead">{{ n.date }}</div>
            </md-card-header>
            <md-card-content v-html="n.description"></md-card-content>
            <md-card-actions v-if="isEditable">
                <md-button @click="deleteNews(n.id)">Удалить</md-button>
                <md-button @click="editNews(n)">Редактировать</md-button>
            </md-card-actions>
        </md-card>
        <md-dialog md-open-from="#custom" md-close-to="#custom" ref="news-edit-dialog">
            <md-dialog-title>{{ dlgData.dlgTitle }}</md-dialog-title>
            <md-dialog-content>
                <form novalidate @submit.stop.prevent="submit">
                    <md-input-container>
                        <label>Заголовок</label>
                        <md-input required v-model="dlgData.title"></md-input>
                    </md-input-container>

                    <md-input-container>
                        <label>Текст новости</label>
                        <md-textarea required v-model="dlgData.description"></md-textarea>
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
                news: [],
                isLoading: false,
                errorMessage: null,
                dlgData: {
                    dlgTitle: '', title: '', date: '', description: '', id: 0
                }
            };
        },
        computed: {
            isEditable() {
                return this.$store.getters.roles.indexOf('news_admin') >= 0;
            }
        },
        created() {
            this.loadList();
        },
        methods: {
            closeDialog() {
                this.$refs['news-edit-dialog'].close();    
            },                
            saveData() {
                this.$refs['news-edit-dialog'].close();
                this.errorMessage = null;
                if (0 == this.dlgData.id) {
                    this.$http.post(links.NEWS_PATH, this.dlgData).then(response => {
                        this.loadList();
                    }, response => {
                        this.errorMessage = response.statusText;                        
                    });
                }
                else {                    
                    this.$http.patch(links.NEWS_PATH, this.dlgData).then(response => {
                        this.loadList();
                    }, response => {
                        this.errorMessage = response.statusText;
                    });
                }
            },
            deleteNews(id) {
                this.$http.delete(links.NEWS_PATH, { params: { id } }).then(response => {
                    this.loadList();
                });
            },
            editNews(n) {
                this.dlgData.dlgTitle = 'Изменить новость';
                this.dlgData.title = n.title;
                this.dlgData.date = n.date;
                this.dlgData.description = n.description;
                this.dlgData.id = n.id;
                this.$refs["news-edit-dialog"].open();
            },
            loadList() {
                this.isLoading = true;
                this.errorMessage = null;
                this.$http.get(links.NEWS_PATH).then(response => {
                    this.news = response.body.list;
                    this.isEditable = response.body.isEditable;
                    this.isLoading = false;
                }, response => {
                    this.errorMessage = response.statusText;                   
                    this.isLoading = false;
                });
            },
            showAddNewsDialog() {
                this.dlgData.dlgTitle = 'Добавить новость';
                this.dlgData.title = '';
                this.dlgData.date = new Date();
                this.dlgData.description = '';
                this.dlgData.id;
                this.$refs["news-edit-dialog"].open();
            }
        }
    }
</script>