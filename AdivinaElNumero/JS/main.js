
let numero = Math.floor(Math.random() * 30) + 1;
let intentos = 10;
let puntajeMax = 0;
let puntajeActual = 10;

let adivinarInput = document.getElementById("adivinar");
let intentosSpan = document.getElementById("intentos");
let puntajeMaxSpan = document.getElementById("puntaje-max");
let puntajeActualSpan = document.getElementById("puntaje-actual");
let resultadoP = document.getElementById("resultado");
let adivinarBtn = document.getElementById("adivinar-btn");
let rangoP = document.getElementById("rango");

function validarEntrada(entrada) {
  if (!isNaN(entrada) && parseInt(entrada) == entrada) {
    if (entrada >= 1 && entrada <= 30) {
      return true;
    }
  }
  return false;
}

function actualizarInterfaz() {
  intentosSpan.innerHTML = intentos;
  puntajeMaxSpan.innerHTML = puntajeMax;
  puntajeActualSpan.innerHTML = puntajeActual;
}

function procesarEntrada() {

  let entrada = adivinarInput.value;
  if (validarEntrada(entrada)) {
    let numeroAdivinado = parseInt(entrada);
    if (numeroAdivinado == numero) {
      puntajeActual = intentos;
      if (puntajeActual > puntajeMax) {
        puntajeMax = puntajeActual;
      }
      resultadoP.innerHTML = "¡Ganaste! El número era " + numero + ".";
      resultadoP.style.color = "green";
      adivinarBtn.disabled = true;
    } else {
      intentos--;
      puntajeActual--;
      if (intentos == 0) {
        resultadoP.innerHTML = "¡Perdiste! El número era " + numero + ".";
        resultadoP.style.color = "red";
        adivinarBtn.disabled = true;
      } else {
        if (numeroAdivinado > numero) {
          rangoP.innerHTML = "El número es más pequeño.";
        } else {
          rangoP.innerHTML = "El número es más grande.";
        }
        resultadoP.innerHTML = "No adivinaste. Intenta de nuevo.";
        resultadoP.style.color = "black";
      }
    }
    actualizarInterfaz();
    adivinarInput.value = "";
  } else {
    resultadoP.innerHTML = "Entrada inválida. Introduce un número del 1 al 30.";
    resultadoP.style.color = "black";
  }
}
let reiniciarBtn = document.getElementById("reiniciar-btn");

reiniciarBtn.addEventListener("click", function() {
  numero = Math.floor(Math.random() * 30) + 1;
  intentos = 10;
  puntajeActual = 10;

  adivinarBtn.disabled = false;

  actualizarInterfaz();
  rangoP.innerHTML = "";
  resultadoP.innerHTML = "";
});

adivinarBtn.addEventListener("click", procesarEntrada);
