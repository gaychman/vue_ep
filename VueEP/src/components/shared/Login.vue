<template>
    <div>        
        <md-card v-show="mode=='login'">
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

            <md-bottom-bar>
                <md-bottom-bar-item md-icon="lock-reset" @click="showLostPassword">Забыли пароль?</md-bottom-bar-item>
                <md-bottom-bar-item md-icon="account-plus" @click="showRegister">Зарегестрироваться</md-bottom-bar-item>
            </md-bottom-bar>
        </md-card>
        <md-card v-show="mode=='register'">
            <md-card-header>Зарегестрироваться</md-card-header>

            <md-card-content>

                <md-input-container>
                    <label>Регистрационное имя</label>
                    <md-input type="text" v-model="login"></md-input>
                    <md-icon>email</md-icon>
                </md-input-container>

                <md-input-container>
                    <label>e-mail</label>
                    <md-input type="text" v-model="email"></md-input>
                    <md-icon>email</md-icon>
                </md-input-container>

                <md-input-container md-has-password>
                    <label>Пароль</label>
                    <md-input type="password" v-model="password"></md-input>
                </md-input-container>

                <md-button @click="executeRegister()" class="md-button md-raised md-primary md-theme-default">Зарегестрироваться</md-button>

            </md-card-content>

            <md-bottom-bar>
                <md-bottom-bar-item md-icon="login" @click="showLogin">Войти в систему</md-bottom-bar-item>
            </md-bottom-bar>
        </md-card>
        <md-card v-show="mode=='lost-pass'">
            <md-card-header>Зарегестрироваться</md-card-header>

            <md-bottom-bar>
                <md-bottom-bar-item md-icon="login" @click="showLogin">Войти в систему</md-bottom-bar-item>
            </md-bottom-bar>
        </md-card>
    </div>
</template>

<script>
    import Vue from 'vue';
    import VueAuthenticate from 'vue-authenticate';
   
    export default {
        data() {
            return {
                login: '',
                password: '',
                email: '',
                mode: 'login'
            };
        },
        components: {
        },
        methods: {
            executeLogin() {
                this.$store.dispatch('login', { user: { Login: this.login, Password: this.password } }).then(() => {
                    this.$router.push({ path: '/news' });
                });
            },
            executeRegister() {
                this.$http.post('/auth/register', { Login: this.login, Password: this.password, EMail: this.email }).then(response => {
                    
                }, response => {
                    
                });
            },
            showRegister() {
                this.mode = "register";
                this.login = this.password = this.email = '';
            },
            showLogin() {
                this.mode = "login";
            },
            showLostPassword() {
                this.mode = "lost-pass";
            }
        }
    }
</script>


