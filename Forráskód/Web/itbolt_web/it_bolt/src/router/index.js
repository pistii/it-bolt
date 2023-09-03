import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { isLoggedIn } from '../store/auth.js'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: '/ismerteto',
    name: 'ismerteto',
    component: () => import('../views/IsmertetoView.vue'),
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: '/belepes',
    name: 'belepes',
    component: () => import('../views/BelepesView.vue'),
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: '/contact',
    name: 'contact',
    component: () => import('../views/ContactView.vue'),
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: '/raktar',
    name: 'raktar',
    component: () => import('../views/RaktarView.vue')
  },
  {
    path: '/eszkoz',
    name: 'EszkozView',
    component: () => import('../views/EszkozView.vue')
  },
  {
    path: '/boltok',
    name: 'boltok',
    component: () => import('../views/BoltokView.vue')
  },
  {
    path: '/:pathMatch(.*)',
    name:'notFound',
    component: () => import('../views/NotFoundView.vue')
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from, next) => {
  if (to.name == 'belepes' && isLoggedIn()) {
    next({ path: '/' })
}
else if (!to.meta.allowAnonymous && !isLoggedIn()) {
    next({
        path: '/belepes',
        query: { redirect: to.fullPath }
    })
}
else {
    next()
}
})

export default router
