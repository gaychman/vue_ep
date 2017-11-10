<template>
    <div>        
        <doc-opener type="10" @selected="selectDocument($event)"></doc-opener>
    </div>
</template>

<script>
    import DocumentOpener from '../dkb/DocumentOpener.vue';

    export default {
        data() {
            return {

            };
        },
        methods: {
            selectDocument(doc) {

            }
        },
        components: {
            docOpener: DocumentOpener
        }
    }
</script>