// Definimos las letiables
let numero = Math.floor(Math.random() * 30) + 1;
let intentos = 10;
let puntajeMax = 0;
let puntajeActual = 10;

// Obtenemos los elementos del HTML
let adivinarInput = document.getElementById("adivinar");
let intentosSpan = document.getElementById("intentos");
let puntajeMaxSpan = document.getElementById("puntaje-max");
let puntajeActualSpan = document.getElementById("puntaje-actual");
let resultadoP = document.getElementById("resultado");
let adivinarBtn = document.getElementById("adivinar-btn");
let rangoP = document.getElementById("rango");

// Función para validar la entrada del usuario
function validarEntrada(entrada) {
  // Si la entrada es un número válido
  if (!isNaN(entrada) && parseInt(entrada) == entrada) {
    // Si el número está dentro del rango permitido
    if (entrada >= 1 && entrada <= 30) {
      return true;
    }
  }
  return false;
}

// Función para actualizar la interfaz de usuario
function actualizarInterfaz() {
  intentosSpan.innerHTML = intentos;
  puntajeMaxSpan.innerHTML = puntajeMax;
  puntajeActualSpan.innerHTML = puntajeActual;
}

// Función para procesar la entrada del usuario
function procesarEntrada() {

  let entrada = adivinarInput.value;
  if (validarEntrada(entrada)) {
    let numeroAdivinado = parseInt(entrada);
    if (numeroAdivinado == numero) {
      // El usuario adivinó el número
      puntajeActual += intentos;
      if (puntajeActual > puntajeMax) {
        puntajeMax = puntajeActual;
      }
      resultadoP.innerHTML = "¡Ganaste! El número era " + numero + ".";
      resultadoP.style.color = "green";
      adivinarBtn.disabled = true;
    } else {
      // El usuario no adivinó el número
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
    // La entrada no es válida
    resultadoP.innerHTML = "Entrada inválida. Introduce un número del 1 al 30.";
    resultadoP.style.color = "black";
  }
}
let reiniciarBtn = document.getElementById("reiniciar-btn");

reiniciarBtn.addEventListener("click", function() {
  // Reiniciamos las variables
  numero = Math.floor(Math.random() * 30) + 1;
  intentos = 10;
  puntajeActual = 10;

  // Habilitamos el botón Adivinar
  adivinarBtn.disabled = false;

  // Actualizamos la interfaz de usuario
  actualizarInterfaz();
  rangoP.innerHTML = "";
  resultadoP.innerHTML = "";
});

// Asignamos la función procesarEntrada al botón Adivinar
adivinarBtn.addEventListener("click", procesarEntrada);
adivinarInput.addEventListener("keyup", function(event) {
  if (event.key == "Space") { // Si se presiona la tecla Enter
    event.preventDefault(); // Evita que se refresque la página
    adivinarBtn.click(); // Simula el click del botón Adivinar
  }
});
