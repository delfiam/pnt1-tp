function validarForm() {

      var nombre = document.getElementById("nombre").value;
      var email = document.getElementById("email").value;
      var mensaje = document.getElementById("mensaje").value;
   
      if (nombre == "" || email == "" || mensaje == "") {
         alert("Todos los campos son obligatorios");
         return false;
      }
      else {
         alert("Mensaje enviado correctamente");
         return true;
      }

}