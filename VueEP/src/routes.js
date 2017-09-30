import News from './components/shared/News.vue';
import Login from './components/shared/Login.vue';
import TestsAdmin from './components/test-editors/TestsAdmin.vue';
import CourseBuilder from './components/course-builder/CourseBuilder.vue';
import IPR from './components/ipr/IPR.vue';

export const routes = [
    { path: '/', component: News },
    { path: '/news', component: News },
    { path: '/tests-admin', component: TestsAdmin },
    { path: '/course-builder', component: CourseBuilder },
    { path: '/course-builder/:id', component: CourseBuilder },
    { path: '/ipr', component: IPR },
    { path: '/login', component: Login }
];