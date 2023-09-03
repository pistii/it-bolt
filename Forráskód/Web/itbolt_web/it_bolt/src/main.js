import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
//import "https://cdn.jsdelivr.net/npm/vue/dist/vue.js"
//import "https://unpkg.com/axios/dist/axios.min.js"
import './assets/main.css'
import 'bootstrap';
import { createPinia } from "pinia";


const pinia = createPinia();


const app = createApp(App).use(pinia).use(router)


app.mount('#app')
