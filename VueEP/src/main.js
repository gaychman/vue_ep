import Vue from 'vue';
import VueMaterial from 'vue-material';
import VueResource from 'vue-resource';
import VueAuthenticate from 'vue-authenticate';
import VueRouter from 'vue-router';

Vue.use(VueMaterial);
Vue.use(VueResource);
Vue.use(VueAuthenticate, {
    baseUrl: ''
});
Vue.use(VueRouter);

import App from './App.vue';

require('vue-material/dist/vue-material.css')

import { routes } from './routes';
const router = new VueRouter({ routes, mode: "history" });

Vue.material.registerTheme('default', {
    primary: 'blue',
    accent: 'red',
    warn: 'yellow',
    background: 'white'
});

new Vue({
    el: '#app',
    router: router,
    render: h => h(App)
})
