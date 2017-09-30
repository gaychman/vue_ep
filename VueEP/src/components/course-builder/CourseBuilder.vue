<template>
    <div>
        <h1>редактор</h1>
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

            };
        },
        components: {
            cbResizable: Resizable
        }
    }
</script>