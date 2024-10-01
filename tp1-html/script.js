document.getElementById("formContacto").addEventListener("submit", function(event) {
   event.preventDefault(); // Previene el envío del formulario
   validarForm();
});

function validarForm() {
   var nombre = document.getElementById("nombre").value;
   var email = document.getElementById("mail").value;
   var motivo = document.getElementById("motivo").value;
   var mensaje = document.getElementById("mensaje").value;
   var mensajesError = document.querySelectorAll(".errorMensaje");

   mensajesError.forEach(function(elemento) {
       elemento.textContent = "";
   });

   let esValido = true;

   if (nombre == "") {
       document.querySelector("#nombre + .errorMensaje").textContent = "El nombre es obligatorio";
       esValido = false;
   }
   if (email == "") {
       document.querySelector("#mail + .errorMensaje").textContent = "El email es obligatorio";
       esValido = false;
   }
   if (motivo == "") {
       document.querySelector("#motivo + .errorMensaje").textContent = "Debe seleccionar un motivo";
       esValido = false;
   }
   if (mensaje == "") {
       document.querySelector("#mensaje + .errorMensaje").textContent = "El mensaje es obligatorio";
       esValido = false;
   }

   if (esValido) {
       alert("Formulario enviado correctamente");
       document.getElementById("formContacto").submit(); 
   }
}