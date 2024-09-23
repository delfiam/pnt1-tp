function validarForm() {

      var nombre = document.getElementById("nombre").value;
      var email = document.getElementById("mail").value;
      var motivo = document.getElementById("motivo").value;
      var mensaje = document.getElementById("mensaje").value;
   
      if (nombre == "" || email == "" || motivo == "" || mensaje == "") {
         alert("Todos los campos son obligatorios");
        
      }
      else {
         alert("Formulario enviado correctamente");
         
      }

}