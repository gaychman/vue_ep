<template>
    <md-card>
        <md-card-header>Вход в систему</md-card-header>
        <md-card-content>
            <form novalidate @submit.stop.prevent="submit">
                <md-input-container>
                    <label>Регистрационное имя</label>
                    <md-input v-model="login"></md-input>
                </md-input-container>

                <md-input-container>
                    <label>Пароль</label>
                    <md-input type="password" v-model="password"></md-input>
                </md-input-container>

                <md-button @click="executeLogin()" class="md-button md-raised md-primary md-theme-default">Войти</md-button>
            </form>
        </md-card-content>
    </md-card>
</template>

<script>
    import Vue from 'vue';
    import VueAuthenticate from 'vue-authenticate';
   
    export default {
        data() {
            return {
                login: '', password: ''
            };
        },
        components: {
        },
        methods: {
            executeLogin() {
                this.$auth.login({ Login: this.login, Password: this.password }).then((response) => {
                });
            }
        }
    }
</script>