<template>
    <div>
        <md-card v-for="n in news">
            <md-card-header>
                <div class="md-title">{{ n.title }}</div>
                <div class="md-subhead">{{ n.date }}</div>
            </md-card-header>

            

            <md-card-content v-html="n.description"></md-card-content>
            <md-card-actions v-if="n.editable">
                <md-button @click="editNews(n)">Редактировать</md-button>
            </md-card-actions>
        </md-card>

        <md-dialog md-open-from="#custom" md-close-to="#custom" ref="news-edit-dialog">
            <md-dialog-title>редактировать</md-dialog-title>

            <md-dialog-content>

                <form novalidate @submit.stop.prevent="submit">
                    
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
                news: [
                    {title: "новость", date: "вчерась", description: "некое описание", editable: true}
                ]
            };
        },
        created() {
            this.$http.get('/api/news').then(response => {

            }, response => {
                // error callback 
            });
        },
        methods: {
            editNews(n) {
                this.$refs["news-edit-dialog"].open();
            }
        }
    }
</script>