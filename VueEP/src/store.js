import Vue from 'vue';
import Vuex from 'vuex';
import VueAuthenticate from 'vue-authenticate';

Vue.use(Vuex);

var vueAuth = VueAuthenticate.factory(Vue.http, {
    baseUrl: ''
});

export default new Vuex.Store({
    state: {
        isAuthenticated: false
    },
    getters: {
        isAuthenticated() {
            return vueAuth.isAuthenticated();
        }
    },
    mutations: {
        isAuthenticated(state, payload) {
            state.isAuthenticated = payload.isAuthenticated;
        }
    },
    actions: {
        login(context, payload) {
            vueAuth.login(payload.user, payload.requestOptions).then((response) => {
                context.commit('isAuthenticated', {
                    isAuthenticated: vueAuth.isAuthenticated()
                });
                return vueAuth.isAuthenticated() ? Promise.resolve() : Promise.reject();
            });
        },
        logout(context) {
            vueAuth.logout().then((response) => {
                context.commit('isAuthenticated', {
                    isAuthenticated: vueAuth.isAuthenticated()
                });
                return Promise.resolve();
            });
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