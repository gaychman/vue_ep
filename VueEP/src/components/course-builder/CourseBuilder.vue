<template>
    <div>
        <md-toolbar>
            <md-menu md-align-trigger>
                <md-button md-menu-trigger class="md-icon-button"><md-icon>menu</md-icon></md-button>

                <md-menu-content>
                    <md-menu-item>Новый курс</md-menu-item>
                    <md-menu-item>Загрузить курс</md-menu-item>
                </md-menu-content>
            </md-menu>
            <h2 class="md-title" style="flex: 1">Конструктор курсов</h2>
            <md-button class="md-raised" @click="returnHome()">Вернуться к порталу</md-button>
        </md-toolbar>
        <router-view></router-view>
    </div>
</template>

<script>
    export default {
        data() {
            return {

            };
        },
        methods: {
            returnHome() {
                this.$router.push('/');
            }
        }
    }
</script>