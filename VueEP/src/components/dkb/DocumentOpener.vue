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
    export default {
        data() {
            return {
                state: 0,
                documents: [{name: 'test', id: 1}]
            };
        },
        props: ['initial-catalog', 'types']
    }
</script>