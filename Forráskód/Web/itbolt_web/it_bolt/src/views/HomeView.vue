<template>
  <div>
    <img class="containerBg img-responsive d-block text-center ">
    <div class="homeContainer">

      <h1 class="text-center title user-select-none">IT raktár</h1>
      <p class="text-center title user-select-none"> Minden ami IT</p>
    </div>
  </div>

  <div style="padding-top: 470px">
    <h1>
      Rólunk
    </h1>
    <div class="row" >
      <span class="card col-lg-5 col-sm-12 myCardBox"  >
        <div class="card-header">Projektmanager</div>
        <span class="card-body">
          
          Benkő Ference: <br>
          Dokumentációk készítése, <br>
          Segítségnyújtás frontend és backend oldalon, <br>
          Tesztelések dokumentálása. <br>
          Adatbázis és frontend tervezés <br>
        </span>
      </span>
      <span class="card  col-lg-5 col-sm-12 myCardBox">
        
          <div class="card-header">Cégvezető</div>
          <span class="card-body">
          
          Pilisi István <br>
          Backend és frontend programozás.<br>
          Tesztelések, hibajavítások
        </span>
      </span>
    </div>
    <div class="row counter" style="margin-top: 40px">
      <h1>A következő felvételig hátralévő idő: </h1>
      <span class=" card myCardBox col-sm-2 user-select-none">
        <span class="card-body cardbox">
          {{ days }} nap
        </span>
      </span>

      <span class="card myCardBox col-sm-2 user-select-none ">
        <span class="card-body cardbox">
          {{ hours }} óra
        </span>
      </span>

      <span class="card myCardBox col-sm-2 user-select-none">
        <span class="card-body cardbox">
          {{ mins }} perc
        </span>
      </span>

      <span class="card myCardBox col-sm-2 user-select-none">
        <span class="card-body cardbox">
          {{ secs }} mp
        </span>
      </span>
    </div>

    <div>
      <h1>Miért éri meg nálunk dolgozni?</h1>
      Tisztelet, megbecsülés, kedvező bér, ez a három jellemző ami a raktárainkat jellemzi.
      <div  class="bottom-text">
      Cégünk kimagasló teljesítmény nyújtása az ország egész területén kiterjed.
      Kezdetben Szegeden, később Budapesten és Budapesten nyitottak meg raktáraink.
      Mára már 12 térségben és több mint 30 városban vagyunk elérhetőek. 
      Főbb jövőbeli terveink a későbbiekben a teljes országos lefedettség és a külföldi piac meghódítása is.
    </div>
    </div>


  </div>
</template>

<script setup>
import { ref } from 'vue';

var end = new Date('02/31/2024 12:6 PM');
var _second = 1000;
var _minute = _second * 60;
var _hour = _minute * 60;
var _day = _hour * 24;
var timer;

var days = ref(0)
var hours = ref(0)
var mins = ref(0)
var secs = ref(0)

function showRemaining() {
  var now = new Date();
  var distance = end - now;
  if (distance < 0) {
    clearInterval(timer);
    document.getElementById('counter').innerHTML = 'MÁR MINDENKIT FELVETTÜNK!';
    return;
  }

  days.value = Math.floor(distance / _day);
  hours.value = Math.floor((distance % _day) / _hour);
  mins.value = Math.floor((distance % _hour) / _minute);
  secs.value = Math.floor((distance % _minute) / _second);
}
timer = setInterval(showRemaining);

</script>

<style>
.containerBg {
  background-image: url("../assets/mainPageBg.jpeg");
  height: 800px;
  width: 100%;
  margin-top: -300px;
  align-items: center;
  z-index: -100;
  min-height: 500px;
  /* scrolling effect */
  background-attachment: fixed;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

.title {
  color: black;
  font-family: Courier;
  font-weight: 900;
  text-shadow: 2px 2px rgba(5, 31, 55, 0.6);
  text-shadow: 3px 3px rgba(218, 214, 214, 0.8);
}

.myCardBox {
  background-image: linear-gradient(to right top, #051f37, #072f54, #0c477e, #1279da, #168cfb);
  margin-inline: 4vw;
  text-align: center;
  align-items: center;
  font-family: Verdana;
  font-size: larger;
}


@media only screen and (min-width: 1024px) {
  .homeContainer {
    z-index: 10;
    margin-top: -400px;
    font-size: 120px;
  }

}

@media only screen and (min-width: 440px) {
  .homeContainer {
    margin-top: -400px;
    font-size: 50px;
  }

  .myCardBox {
    margin-bottom: 15px;
  }
}

@media only screen and (min-width: 10px) {
  .homeContainer {
    margin-top: -400px;
    font-size: 40px;
  }
}

.row {
  margin: 40px;
}

.cardbox {
  width: fit-content;
  background-color: rgba(34, 47, 34, 0.213);
  margin-block: 30px;
}

.bottom-text {
  margin-bottom: 55px;
  border-bottom: 1px solid black;
  padding-inline: 3vw;
  text-align: justify;

}
.card-header:first-child {
  border-radius: 5%;
  background-color: rgba(128, 128, 128, 0.547);
  margin: 25px;
}

</style>