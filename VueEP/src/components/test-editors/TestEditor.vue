<template>
    <md-layout>
        <md-card md-flex="50" md-gutter="16">
            <md-card-header>Вопросы теста</md-card-header>
            <md-card-content>


                <div v-if="noSections">список пуст</div>
                <md-list v-else>
                    <md-list-item v-for="section in test.sections">
                        <h4>{{ section.name }}</h4>
                            <md-button class="md-icon-button" @click="showEditSectionDialog(section)">
                                <md-icon>edit</md-icon>
                            </md-button>
                        <md-list>
                            <md-list-item v-for="question in section.questions">{{ question.name }}</md-list-item>
                        </md-list>
                    </md-list-item>
                </md-list>
                <md-button class="md-icon-button md-raised md-primary" @click="showAddSectionDialog">
                    <md-icon>add</md-icon>
                </md-button>
            </md-card-content>
        </md-card>

        <md-card md-gutter="16">
            <md-card-header>Настройки теста</md-card-header>
        </md-card>

        <test-section-editor ref="addSectionDialog" @save="onAddSection($event)" dialog-title="Создать раздел"></test-section-editor>
        <test-section-editor ref="editSectionDialog" @save="onAddSection($event)" dialog-title="Свойства раздела"></test-section-editor>
    </md-layout>
</template>

<script>
    import TestSectionEditor from './TestSectionEditor.vue';

    export default {
        data() {
            return {
                test: {
                    sections: []
                }
            };
        },
        computed: {
            noSections() {
                return this.test.sections.length == 0;
            }
        },
        methods: {
            showEditSectionDialog(section) {
                this.$refs.editSectionDialog.open();
            },
            showAddSectionDialog() {
                this.$refs.addSectionDialog.open();
            },
            onAddSection(section) {
                section.questions = section.questions || [];
                this.test.sections.push(section);
                this.$emit('changed', test);
            }
        },
        components: {
            testSectionEditor: TestSectionEditor
        }
    }
</script>