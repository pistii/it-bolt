// import router from '../router'
// import NavBar from '@/components/NavBar.vue';
// import NavBar2 from '@/components/NavBar2.vue';

// const login = function login() {
//     var user = document.getElementById("username").value;
//     var pass = document.getElementById("password").value;
  
//     let url = 'http://localhost:5000/api/felhasznalo/?nev=' + user + '&jelszo=' + pass;
//     const value = fetch(url)
//       .then((response) => {
//         checkLogin(response.status)
        
//       });
  
//     console.log(value);
//     const checkLogin = function (val) {
//       if (val === 200) {
//         router.push({ path: '/boltok' })
//         NavBar.document.getElementById("visitor").visibility = false;
  
//         return false;
//       } else {
//         console.log(val);
//         alert("Hibás felhasználónév vagy jelszó");
//         return false;
//       }
//     }
//   }