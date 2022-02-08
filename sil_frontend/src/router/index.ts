import { createRouter, createWebHistory } from "vue-router";

import { IsAuthenticated } from "@/auth/authentication";
import { RouteRecordRaw } from "vue-router";
import { publicPages } from "@/auth/authentication";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: () => import("@/views/HomeView.vue")
  },
  {
    path: "/Test",
    name: "Test",
    component: () => import("@/views/HelloWorldView.vue")
  },
  {
    path: "/Login",
    name: "Login",
    component: () => import("@/views/LoginView.vue")
  },
  {
    path: "/Logout",
    name: "Logout",
    component: () => import("@/views/LogoutView.vue")
  },
  {
    path: "/Register",
    name: "Register",
    component: () => import("@/views/RegisterView.vue")
  },
  {
    path: "/Profile",
    name: "Profile",
    component: () => import("@/views/UserProfileView.vue")
  },
  {
    path: "/ResetPassword",
    name: "ResetPassword",
    component: () => import("@/views/ResetPasswordView.vue")
  },
  {
    path: "/ForgotPassword",
    name: "ForgotPassword",
    component: () => import("@/views/ForgotPasswordView.vue")
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  const authRequired = !publicPages.includes(to.path);
  const authenticated = IsAuthenticated();

  if(authRequired && !authenticated) {
    return next('/login');
  }

  next();
})

export default router;