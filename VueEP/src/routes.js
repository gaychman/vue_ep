import News from './components/shared/News.vue';
import Login from './components/shared/Login.vue';
import UserInfo from './components/shared/UserInfo.vue';
import TestsAdmin from './components/test-editors/TestsAdmin.vue';
import CourseBuilder from './components/course-builder/CourseBuilder.vue';
import OpenCourse from './components/course-builder/OpenCourse.vue';
import CourseEditor from './components/course-builder/CourseEditor.vue';
import StructureEditor from './components/course-builder/StructureEditor.vue';
import ScreenEditor from './components/course-builder/ScreenEditor.vue';
import IPR from './components/ipr/IPR.vue';
import Portal from './Portal.vue';
import Applications from './Applications.vue';
import NotFound from './NotFound.vue';

export const routes = [
    {
        path: "/", component: Portal, children: [
            { path: '', component: News },
            { path: 'login', component: Login },
            { path: 'news', component: News },
            { path: 'my-info', component: UserInfo } 
        ]
    },
    {
        path: "/applications", component: Applications, children: [
            {
                path: "course-builder", component: CourseBuilder, children: [
                    {
                        path: "", component: OpenCourse
                    },
                    {
                        path: "open-course", component: OpenCourse, name: 'open-course'
                    },
                    {
                        path: "course-editor/:id", component: CourseEditor, name: 'course-edit', children: [
                            { path: "", component: StructureEditor },
                            { path: "screen-editor/:sid", component: ScreenEditor, name: 'screen-edit' }                            
                        ]
                    },
                ]
            },           
            { path: "ipr", component: IPR }
        ]
    },
    {
        path: "*", component: NotFound
    }

    /*{ path: '/', component: News },
    { path: '/news', component: News },
    { path: '/tests-admin', component: TestsAdmin },
    { path: '/course-builder', component: CourseBuilder },
    { path: '/course-builder/:id', component: CourseBuilder },
    */
];