<template>
    <div>
        <h1>ИПР</h1>

        <md-tabs>
            <md-tab md-label="Персональные данные">
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Deserunt dolorum quas amet cum vitae, omnis! Illum quas voluptatem, expedita iste, dicta ipsum ea veniam dolore in, quod saepe reiciendis nihil.</p>
            </md-tab>

            <md-tab v-for="area in areas" :md-label="area.title">
                <md-card v-for="action in area.actions">
                    <md-toolbar class="md-dense">
                        <h2 class="md-title" style="flex: 1">{{ action.title }}</h2>
                    </md-toolbar>
                </md-card>
            </md-tab>
        </md-tabs>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                areas: [{ title: "Область 1", actions: [{ title: "Развитие на рабочем месте" }, { title: "Специальные задания (проекты)" }] } ]
            };
        }
    }
</script>