<template>
    <div>
        <md-tabs class="md-transparent">
            <md-tab md-label="Мои документы">
                <md-list>
                    <md-list-item v-for="d in documents">
                        <router-link :to="{ name: 'course-edit', params: { id: d.id } }">{{ d.name }}</router-link>                        
                    </md-list-item>
                </md-list>
            </md-tab>

            <md-tab md-label="Выбрать из ДБЗ">
                <p></p>
            </md-tab>
        </md-tabs>
    </div>
</template>

<script>
    import * as links from '../../api-links';

    export default {
        data() {
            return {
                state: 0,
                documents: []
            };
        },
        props: ['initial-catalog', 'type'],
        created() {
            this.loadMyList();
        },
        methods: {
            loadMyList() {
                this.$http.get(links.DKB_MYLIST_PATH, { params: { type: this.type } }).then(response => {
                    this.documents = response.body.list;

                }, response => {

                });
            }
        }
    }
</script>