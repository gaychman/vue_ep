<template>
    <md-list>
        <md-list-item>
            <router-link to="/news">Новости</router-link>
        </md-list-item>
        <md-list-item>
            <router-link to="/tests-admin">Конструктор тестов</router-link>               
        </md-list-item>
        <md-list-item v-if="isAuth()">
            <router-link to="/applications/course-builder">Конструктор курсов</router-link>                           
        </md-list-item>
        <md-list-item>
            <router-link to="/test-admin">Расписание занятий</router-link>               
        </md-list-item>
        <md-list-item v-if="isAuth()">
            <router-link to="/applications/ipr">ИПР</router-link>
        </md-list-item>
        <md-list-item v-if="isAuth()">
            <router-link to="/my-info">Личный кабинет</router-link>                           
        </md-list-item>
        <md-list-item v-if="!isAuth()">
            <router-link to="/login">Вход в систему</router-link>
        </md-list-item>
        <md-list-item v-if="isAuth()">
            <a href="#" @click.prevent="logout">Выход из системы</a>
        </md-list-item>
    </md-list>
</template>

<script>
    export default {
        data() {
            return {

            };
        },
        methods: {
            isAuth() {
                return this.$auth.isAuthenticated();
            },
            logout() {
                this.$store.dispatch('logout').then(() => {
                    this.$router.push({ path: '/news' });
                });
            }
        },
        computed: {
            isAuthenticated: function () {
                return this.$store.state.isAuthenticated;
            }             
        }

    }
</script>