<?php session_start(); ?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="./css/estilo.css">
    <title>Iniciar sesión · Mi Pokédex</title>
</head>
<body>
    <?php include 'navbar.php'; ?>

    <!--FORM DE LOGIN-->
    <main class="container-xl py-5">
  <div class="row justify-content-center">
    <div class="col-md-8 col-lg-5">
      <div class="tarjeta p-4">
        <h2 class="h3 fw-bold">Iniciar sesión</h2>
        <p class="small text-secondary">Qué bueno verte de nuevo, entrenador.</p>
        <form action="php/logica_IniciarSesion.php" method="post">
        <div class="mb-3">
          <label for="user" class="form-label">Correo</label>
          <input type="email" class="form-control" id="user" name="user" placeholder="tu@email.com" required >
        </div>
        <div class="mb-3">
          <label for="pass" class="form-label">Contraseña</label>
          <input type="password" class="form-control" id="pass" name="pass" placeholder="••••••••" required >
        </div>
          <button type="submit" class="btn boton-rojo w-100 mt-1">Iniciar sesión</button>
        </form>
        <hr>
        <p class="text-center small text-secondary mb-0">¿Aún no tienes cuenta? <a href="Registrarse.php" class="enlace-rojo">Crear cuenta</a></p>
      </div>
    </div>
  </div>
</main>
    <!--FORM DE LOGIN-->

    <?php include 'pie.php'; ?>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
