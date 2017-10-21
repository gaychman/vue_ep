﻿import Vue from 'vue';
import VueMaterial from 'vue-material';
import VueResource from 'vue-resource';
import VueRouter from 'vue-router';
import Vuex from 'vuex';
import VueAuthenticate from 'vue-authenticate';

Vue.use(VueMaterial);
Vue.use(VueResource);
Vue.use(VueRouter);
Vue.use(Vuex);

var vueAuth = VueAuthenticate.factory(Vue.http, {
    baseUrl: ''
})
var store = new Vuex.Store({
    state: {
        isAuthenticated: false
    },
    getters: {
        isAuthenticated() {
            return vueAuth.isAuthenticated()
        }
    },
    mutations: {
        isAuthenticated(state, payload) {
            state.isAuthenticated = payload.isAuthenticated
        }
    },
    actions: {
        login(context, payload) {
            vueAuth.login(payload.user, payload.requestOptions).then((response) => {
                context.commit('isAuthenticated', {
                    isAuthenticated: vueAuth.isAuthenticated()
                });
                return vueAuth.isAuthenticated() ? Promise.resolve() : Promise.reject();
            })
        },
        logout(context) {
            vueAuth.logout().then((response) => {
                context.commit('isAuthenticated', {
                    isAuthenticated: vueAuth.isAuthenticated()
                });
                return Promise.resolve();
            })
        },
        haveRole(context, role) {
            if (!vueAuth.isAuthenticated()) {
                return Promise.resolve(false);
            }
            // проверка на роли не сделана
            return Promise.resolve(true);
        }
    }
});
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
    store,
    router,
    render: h => h(App)
})