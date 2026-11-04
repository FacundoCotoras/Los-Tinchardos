<?php session_start(); ?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="./css/estilo.css">
    <title>Crear cuenta · Mi Pokédex</title>
</head>
<body>
    <?php include 'navbar.php'; ?>

    <!--FORM DE REGISTRARSE-->
    <main class="container-xl py-5">
  <div class="row justify-content-center">
    <div class="col-md-8 col-lg-5">
      <div class="tarjeta p-4">
        <h2 class="h3 fw-bold">Crear cuenta</h2>
        <p class="small text-secondary">Tu cuaderno de aventura empieza aquí.</p>
        <form action="php/logica_registrarse.php" method="post">
          <div class="row">
            <div class="col-6">
        <div class="mb-3">
          <label for="nombre" class="form-label">Nombre</label>
          <input type="text" class="form-control" id="nombre" name="nombre" placeholder="Tu nombre" required >
        </div></div>
            <div class="col-6">
        <div class="mb-3">
          <label for="apellido" class="form-label">Apellido</label>
          <input type="text" class="form-control" id="apellido" name="apellido" placeholder="Tu apellido" required >
        </div></div>
          </div>
        <div class="mb-3">
          <label for="correo" class="form-label">Correo</label>
          <input type="email" class="form-control" id="correo" name="correo" placeholder="tu@email.com" required >
        </div>
        <div class="mb-3">
          <label for="contrasena" class="form-label">Contraseña</label>
          <input type="password" class="form-control" id="contrasena" name="contrasena" placeholder="••••••••" required >
        </div>
        <div class="mb-3">
          <label for="confirmar" class="form-label">Confirmar contraseña</label>
          <input type="password" class="form-control" id="confirmar" name="confirmar" placeholder="••••••••" required >
        </div>
          <button type="submit" class="btn boton-rojo w-100 mt-1">Crear cuenta</button>
        </form>
        <hr>
        <p class="text-center small text-secondary mb-0">¿Ya tienes una cuenta? <a href="IniciarSesion.php" class="enlace-rojo">Iniciar sesión</a></p>
      </div>
    </div>
  </div>
</main>
    <!--FORM DE REGISTRARSE-->

    <?php include 'pie.php'; ?>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
