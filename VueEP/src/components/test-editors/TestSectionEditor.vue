<template>  
    <md-dialog md-open-from="#custom" md-close-to="#custom" ref="section-dialog">
        <md-dialog-title>{{ dialogTitle }}</md-dialog-title>

        <md-dialog-content>

            <form novalidate @submit.stop.prevent="submit">
                <md-input-container>
                    <label>Название</label>
                    <md-input v-model="sectionName"></md-input>
                </md-input-container>

                <md-input-container>
                    <label>Число задаваемых вопросов</label>
                    <md-input type="number" v-model="questionsCount"></md-input>
                </md-input-container>
            </form>


        </md-dialog-content>

        <md-dialog-actions>
            <md-button class="md-primary" @click="closeDialog()">Закрыть</md-button>
            <md-button class="md-primary" @click="saveData()">Ok</md-button>
        </md-dialog-actions>
    </md-dialog>    
</template>

<script>
	const DLGREF = "section-dialog";
    export default {
        data() {
            return {
                questionsCount: 0, sectionName: ''
            };
        },
        props: {
            dialogTitle: {
                type: String,
                default: 'Свойства раздела'
            }
        },
        methods: {
            open() {
                this.$refs[DLGREF].open();
            },
            closeDialog() {
                this.$refs[DLGREF].close();
            },
			saveData() {
                this.$refs[DLGREF].close();
                this.$emit('save', { name: this.sectionName, questionsCount: +this.questionsCount });
			}
        }
    }
</script>