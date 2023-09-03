<template>
  <div v-if="isLoggedIn()">
    <nav class="navbar navbar-nav navbar-expand-sm navbar-dark bg-primary ">
      <ul class="nav justify-content-center ">
        <li class="nav-item me-3 ">
          <button type="button" class="btn btn-outline-primary btn-secondary">
            <RouterLink class=" text-light nav-link" to="/" @click="logoutUser()">Kilépés</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary btn-secondary">
            <RouterLink class="nav-link" to="/eszkoz">eszköz</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary btn-secondary">
            <RouterLink class="nav-link" to="/raktar">Raktár</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3 ">
          <button type="button" class="btn btn-outline-primary btn-secondary">
            <RouterLink class="nav-link" to="/boltok">Boltok</RouterLink>
          </button>
        </li>

        <!-- <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-success">
            {{ getTokenExpirationDate(getAuthToken)}}
          </button>
        </li> -->
      </ul>
    </nav>
  </div>

  <div id="visitor" v-if="!isLoggedIn()">
    <nav class="navbar navbar-nav navbar-expand-sm navbar-dark bg-primary ">
      <ul class="nav justify-content-center ">
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary btn-secondary">
            <RouterLink class="nav-link " to="/">Kezdőlap</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary  btn-secondary">
            <RouterLink class="nav-link" to="/ismerteto">Ismertető</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary  btn-secondary">
            <RouterLink class="nav-link" to="/belepes">Munkatársaknak</RouterLink>
          </button>
        </li>
        <li class="nav-item me-3">
          <button type="button" class="btn btn-outline-primary  btn-secondary">
            <RouterLink class="nav-link" to="/contact">Kapcsolat</RouterLink>
          </button>

        </li>

        
      </ul>
    </nav>
  </div>

</template>

<script setup>
import { isLoggedIn, logoutUser } from '@/store/auth';
</script>

<style>
@media screen and (min-width: 10px) {
  .btn {
    margin-bottom: 20px;
  }
}

</style>
