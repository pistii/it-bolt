<template>
    <div class="vertical">
    <p style="white-space:pre-wrap;" class="contactBox">
        <MDBCarousel v-model="carousel" :items="items" />
    </p>
</div>
</template>

<script>
import { ref } from "vue";
import { MDBCarousel } from "mdb-vue-ui-kit";

export default {
    components: {
        MDBCarousel
    },
    setup() {
        const items = [
            {
                src: require("@/assets/contact1.jpg"),
                alt: "...",
                label: "Üzletek:",
                caption: `Szeged József Atilla sugárút 51\nMakó Atilla utca 11.`
            },
            {
                src: require("@/assets/contact3.jpg"),
                alt: "...",
                label: "Vezetők:",
                caption: `Benkő Ferenc\nPilisi István`
            },
            {
                src: require("@/assets/contact4.jpg"),
                alt: "...",
                label: "Email:",
                caption: `sze1benfer@vasvari.org\nsze1pilist@vasvari.org`
            },
            {
                src: require("@/assets/contact3.jpg"),
                alt: "...",
                label: "Telefon",
                caption: `+36304293576\n+36302195432`
            }
        ];
        const carousel = ref(0);
        return {
            items,
            carousel
        };
    }
};
</script>

<style scoped>
p {
    visibility: visible;
    color: red;
  }

.slide {
    box-shadow: 0 6px 15px -3px rgb(0 0 0/0.3);
    padding: 25px;
    border-radius: 5px;
}


.d-none .d-md-block {
    display:none;
} 

</style>

<style>
.contactBox {
    background-image: linear-gradient(to top, #051f37, #072f54, #0c477e, #1279da, #168cfb);

}

.carousel-caption,.d-none, .d-md-block {
    display: block !important;
    visibility: visible !important; 
}


  
@media screen and (min-width: 800px) {
    .vertical {
    margin-top: 10%;
    margin-inline: 30%;
  }
}

@media screen and (min-width: 1200px) {
    .vertical {
    margin-top: 10%;
  }
}

</style>