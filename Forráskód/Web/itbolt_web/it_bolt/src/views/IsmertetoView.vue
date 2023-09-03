
<template>
    <div>
        <div class="text-center mx-auto py-3">

            <h3>Szolgltatásaink</h3>
            <p class="text-center mx-auto py-3">Cégünk kimagasló leltározási és logisztikai rendsrek kiépítésével, illetve
                modern IT
                készülékek forgalmazását tekinti fő profiljának </p>
        </div>


        <div class="container ">
            <!-- card 1-->
            <div class="section_our_solution">
                <div class="our_solution_category">
                    <div class="solution_cards_box">
                        <div class="solution_card">
                            <div class="solu_title">
                                <h3>Modern készülékek forgalmazása </h3>
                            </div>
                            <div class="solu_description bg-secondary bg-opacity-50 col-sm-12 text-white">
                                <img class="img-fluid fotok " src="../assets/ITT1.jpeg" alt="számos termék forgalmazása"
                                    title="számos termék forgalmazása">
                                <div class="whatDoWeDo">
                                    <li>
                                        számítógépek
                                    </li>
                                    <li>
                                        okostelefonok
                                    </li>
                                    <li>
                                        szervergépek
                                    </li>
                                    <li>
                                        nyomtatók
                                    </li>
                                    <li>
                                        fénymásolók
                                    </li>
                                    <li>
                                        okoseszközök
                                    </li>
                                    <li>
                                        és egyéb
                                    </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card 2-->
            <div class="section_our_solution">
                <div class="our_solution_category">
                    <div class="solution_cards_box">
                        <div class="solution_card">
                            <div class="solu_title">
                                <h3>Raktározások </h3>
                            </div>
                            <div class="solu_description bg-secondary bg-opacity-50 col-sm-12 text-white">
                                <img class="img-fluid fotok" src="../assets/storehouse.png" alt="Raktározás"
                                    title="Raktározás">
                                <div class="whatDoWeDo">
                                    <li>
                                        raktárak bérlése
                                    </li>
                                    <li>
                                        raktári nyilvántartások
                                    </li>
                                    <li>
                                        leltározás
                                    </li>
                                    <li>
                                        logisztika
                                    </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- card 3-->
            <div class="section_our_solution">

                <div class="our_solution_category">
                    <div class="solution_cards_box">
                        <div class="solution_card">
                            <div class="solu_title">
                                <h3>Egyéb szolgáltatások </h3>
                            </div>
                            <div class="solu_description bg-secondary col-sm-12 bg-opacity-50 text-white">
                                <img class="img-fluid fotok " src="../assets/inf.png" alt="Kérdések" title="Kérdések">
                                <div class="whatDoWeDo">
                                    <li>
                                        Tanácsadás
                                    </li>
                                    <li>
                                        Fejlesztési projektek
                                    </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style>
img {
    background: rgba(108, 246, 230, 0.4);
    box-shadow: 0 0 3px rgba(108, 246, 230, 0.6);
}

.section_our_solution .row {
    align-items: center;
}

.our_solution_category {
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
}

.our_solution_category .solution_cards_box {
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.solution_cards_box .solution_card {
    flex: 0 50%;
    background: #b3f6fe;
    box-shadow: 0 2px 4px 0 rgba(136, 144, 195, 0.2),
        0 5px 15px 0 rgba(37, 44, 97, 0.15);
    border-radius: 15px;
    margin: 8px;
    padding: 10px 15px;
    position: relative;
    z-index: 1;
    overflow: hidden;
    min-height: 265px;
    transition: 0.7s;
}

.solution_cards_box .solution_card:hover {
    background: #309df0;
    color: #fff;
    transform: scale(1.01);
    z-index: 9;
}

.solution_cards_box .solution_card:hover::before {
    background: rgb(85 108 214 / 10%);
}

.solution_cards_box .solution_card:hover .solu_title h3,
.solution_cards_box .solution_card:hover .solu_description p {
    color: #fff;
}

.solution_cards_box .solution_card:before {
    content: "";
    position: absolute;
    background: rgba(12, 19, 52, 0.109);
    width: 420px;
    height: 1000px;
    z-index: -1;
    transform: rotate(42deg);
    right: -56px;
    top: -23px;
    border-radius: 35px;
}

.solution_cards_box .solution_card:hover .solu_description button {
    background: #fff !important;
    color: #309df0;
}


.solution_card .solu_title h3 {
    color: #212121;
    font-size: 1.3rem;
    margin-top: 13px;
    margin-bottom: 13px;
}

.solution_card .solu_description p {
    font-size: 15px;
    margin-bottom: 15px;
    word-wrap: break-word;
}

.our_solution_content h1 {
    text-transform: capitalize;
    margin-bottom: 1rem;
    font-size: 2.5rem;
}

.solution_cards_box .solution_card:hover .hover_color_bubble {
    top: 0rem;
}

.solution_cards_box .solution_card .so_top_icon {
    width: 60px;
    height: 60px;
    border-radius: 50%;
    background: #fff;
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
}

.solution_cards_box .solution_card .so_top_icon img {
    width: 40px;
    height: 50px;
    object-fit: contain;
}

/*start media query*/
@media screen and (min-width: 470px) {
    .sol_card_top_3 {
        position: relative;
        top: 0;
    }

    .our_solution_category {
        width: 100%;
        margin: 0 auto;
    }

    .our_solution_category .solution_cards_box {
        flex: auto;
    }
}

@media only screen and (min-width: 768px) {
    .sol_card_top_3 {
        position: relative;
        top: -3rem;
    }

    .our_solution_category .solution_cards_box {
        flex: 1;
        width: 100%;

    }
}

@media only screen and (min-width: 970px) {
    .our_solution_category {
        width: 30%;
        margin: 0 auto;
    }
}

.fotok {
    mix-blend-mode: multiply;
    width: 60%;
    max-height: 30%;
    background-color: rgba(108, 246, 230, 0.4);
    padding-bottom: 6px;
    padding-right: 8px;
}

.whatDoWeDo {
    padding-top: 20px;
    text-align: left;
    padding-left: 30%;
    padding-bottom: 25px;
    word-wrap: break-word;
}

#shorts {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    max-width: 300px;
    max-height: 150px;
    word-wrap: break-word;
}

#shorts p {
    word-wrap: break-word;
}

.felkover {
    font-weight: bold;
}

.bg-black {
    background-color: #000 !important;
}

.sidebar h1 {
    font-size: 1.5rem;
}

.sidebar {
    background-color: #000 !important;
}

@media (min-width: 992px) {
    .sidebar {
        height: 100vh;
        width: 250px;
        min-height: 400px;
        overflow: auto;
        padding: 30px;
        position: fixed;
    }
    .main-content {
        float: right;
        width: calc(100% - 250px);
    }

    footer {
        float: right;
        width: calc(100% - 250px);
    }

}

.active>.nav-link {
    color: #ff2800 !important;
    font-weight: bold;
}


.bg-image {
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center;
}

.section-100 {
    min-height: 100vh;
    z-index: 2;
    position: relative;
}


#home h1 {
    padding-top: 30vh;
    font-size: 25px;
    text-shadow: 2px 2px #ff2800;
    font-size: 3rem;
}

h3 {
    font-size: 1.4rem;
    font-variant: small-caps;
}

.row>img {
    height: 100%;
}


footer a,
footer a:visited {
    color: rgb(15, 11, 11);
    text-decoration: underline;
}

p {
    line-height: 200%;
    padding-right: 20px;
}
</style>