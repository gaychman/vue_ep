<template>
    <md-list>
        <md-list-item>
            <router-link to="/news">Новости</router-link>
        </md-list-item>
        <md-list-item>
            <router-link to="/tests-admin">Конструктор тестов</router-link>               
        </md-list-item>
        <md-list-item>
            <router-link to="/course-builder">Конструктор курсов</router-link>                           
        </md-list-item>
        <md-list-item>
            <router-link to="/test-admin">Расписание занятий</router-link>               
        </md-list-item>
        <md-list-item>
            <router-link to="/ipr">ИПР</router-link>
        </md-list-item>
        <md-list-item>
            <router-link to="/test-admin">Личный кабинет</router-link>                           
        </md-list-item>
        <md-list-item>
            <router-link to="/login">Вход в систему</router-link>
        </md-list-item>
    </md-list>
</template>

<script>
    export default {
        data() {
            return {

            };
        }
    }
</script>