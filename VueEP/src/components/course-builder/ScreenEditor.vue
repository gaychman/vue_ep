<template>
    <div>
        <div style="background: green; position: relative; width: 800px; height: 600px;">
            <cb-resizable><div style="background: red; width: 100%; height: 100%;"></div></cb-resizable>
        </div>
    </div>
</template>

<script>
    import Resizable from './Resizable.vue';

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
        },
        components: {
            cbResizable: Resizable
        }
    }
</script>