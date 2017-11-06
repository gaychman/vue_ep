<template>
    <div>
        <h1>Информация о пользователе</h1>
        <md-input-container>
            <label>Только рисунки</label>
            <md-file accept="image/*" v-model="picture"></md-file>
        </md-input-container>
        <md-button @click="uploadImage">загрузить</md-button>
    </div>
    
</template>

<script>
    export default {
        data() {
            return {
                picture: null
            };
        },
        methods: {
            uploadImage() {
                console.log(this.picture);
            }
        }
    }
</script>