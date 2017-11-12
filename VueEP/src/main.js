import Vue from 'vue';
import VueMaterial from 'vue-material';
import VueResource from 'vue-resource';
import VueRouter from 'vue-router';
import Vuex from 'vuex';
import * as links from './api-links';
import jwtDecode from 'jwt-decode';

Vue.use(VueMaterial);
Vue.use(VueResource);
Vue.use(VueRouter);
Vue.use(Vuex);

const ROLE_KEY = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

Vue.http.interceptors.push(function (request, next) {
    if (localStorage.accessToken) {
        request.headers.set('Authorization', 'Bearer ' + localStorage.accessToken);
    }
    next();
});

function safeJwtDecode(s) {
    try {
        return jwtDecode(s);
    }
    catch (ex) {
        console.log(ex.message);
    }
}

var store = new Vuex.Store({
    state: {
        isAuthenticated: !!localStorage.accessToken,
        user: localStorage.accessToken ? safeJwtDecode(localStorage.accessToken) : null,
        // курс
        courseData: {},
        isCourseDirty: false,
        courseCommands: []
    },
    getters: {
        isAuthenticated: state => state.isAuthenticated,
        user: state => state.user,
        roles: state => {
            if (!state.isAuthenticated) {
                return [];
            }
            else {
                if (!state.user) {
                    return [];
                }
                return state.user[ROLE_KEY];
            }
        }
    },
    mutations: {
        isAuthenticated(state, payload) {
            state.isAuthenticated = payload.isAuthenticated
        },
        user(state, payload) {
            state.user = payload.user
        },
        courseData(date, payload) {
            state.courseData = payload;
            state.isDirty = false;
            state.courseCommands = [];
        }
    },
    actions: {
        login(context, payload) {
            Vue.http.post(links.USER_LOGIN_PATH, payload).then(response => {
                localStorage.accessToken = response.body.token;
                context.commit('user', { user: safeJwtDecode(response.body.token) });
                console.log(context.state.user);
                context.commit('isAuthenticated', {
                    isAuthenticated: !!localStorage.accessToken
                });
            });
        },
        logout(context) {
            localStorage.accessToken = null;
            context.commit('isAuthenticated', {
                isAuthenticated: false
            });
        },
        loadCourse(context, id) {
            context.commit('courseData', {});
        },
        newCourse(context, data) {
            context.commit('courseData', data || {});
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
