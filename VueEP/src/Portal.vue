<template>
    <div>
        <div class="container">
            <div class="page-content">
                <md-toolbar>
                    <h1 class="md-title">Портал</h1>
                    
                </md-toolbar>
                <div class="main-content">
                    <router-view></router-view>
                </div>
            </div>
        </div>
        <div class="main-menu">
            <main-menu></main-menu>
        </div>
    </div>
</template>

<script>
    import MainMenu from './components/shared/MainMenu.vue';
    export default {
        data() {
            return {

            };
        },
        components: {
            mainMenu: MainMenu
        }
    }
</script>