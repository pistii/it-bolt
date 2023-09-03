
import decode from 'jwt-decode'
import axios from 'axios'

const BASE_URL = 'http://localhost:5000/';
const AUTH_TOKEN_KEY = 'authToken';


export async function loginUser(username, password) {
    
        try {
            await axios({
            url: BASE_URL + 'api/felhasznalo/authenticate',
            method: 'POST',
            data: {
                nev : username,
                jelszo : password
            }
            }).then(response => {setAuthToken(response.data.token)});
             
        }
        catch (err) {
            alert("Hibás felhasználónév vagy jelszó");
        }
}

export function logoutUser() {
    clearAuthToken()
    location.reload()
}

export function setAuthToken(token) {
    axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    localStorage.setItem(AUTH_TOKEN_KEY, token)
    location.reload()

}

export function getAuthToken() {
    return localStorage.getItem(AUTH_TOKEN_KEY)    
}

export function clearAuthToken() {
    axios.defaults.headers.common['Authorization'] = ''
    localStorage.removeItem(AUTH_TOKEN_KEY)
}

export function isLoggedIn() {
    let authToken = getAuthToken()
    return !!authToken && !isTokenExpired(authToken)
}

export function getUserInfo() {
    if (isLoggedIn()) {
        return decode(getAuthToken())
    }
}

export function getTokenExpirationDate(encodedToken) {
    let token = decode(encodedToken)
    if (!token.exp) {
        return null
    }
  
    let date = new Date(0)
    date.setUTCSeconds(token.exp)
  
    return date
}
  
function isTokenExpired(token) {
    let expirationDate = getTokenExpirationDate(token)
    return expirationDate < new Date()
}