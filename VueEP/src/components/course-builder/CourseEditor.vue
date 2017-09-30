<template>
    <div></div>
</template>

<script>
    import Vue from 'vue';
    import VueAuthenticate from 'vue-authenticate';

    export default {
        data() {
            return {
                id: this.$route.params.id       
            };
        },
        watch: {
            "$route"(to) {
                id = to.params.id;
            }
        }
    }
</script>