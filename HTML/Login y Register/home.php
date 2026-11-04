<?php session_start(); ?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="./css/estilo.css">
    <title>Mi Pokédex</title>
</head>
<body>
    <?php include 'navbar.php'; ?>

    <main class="container-xl d-flex align-items-center justify-content-center text-center py-5">
    <?php if (isset($_SESSION['usuario_id'])) { ?>
        <!-- CON SESIÓN -->
        <div>
    <div class="spinner-border texto-rojo cargando mb-4" role="status"><span class="visually-hidden">Cargando</span></div>
    <h1 class="display-1 fw-bold">En proceso</h1>
  </div>
    <?php } else { ?>
        <!-- SIN SESIÓN: bienvenida -->
        <div class="bienvenida">
    <svg class="logo logo-grande mb-4" viewBox="0 0 40 40" aria-hidden="true"><circle cx="20" cy="20" r="20" fill="#c8372d"/><rect y="18" width="40" height="4" fill="#fff"/><circle cx="20" cy="20" r="6" fill="#fff" stroke="#c8372d" stroke-width="2"/><circle cx="20" cy="20" r="2.5" fill="#1f2630"/></svg>
    <p class="etiqueta etiqueta-roja mb-2">Cuaderno de aventura / Kanto</p>
    <h1 class="titulo-pagina mb-3">¡Bienvenido a Mi Pokédex!</h1>
    <p class="text-secondary mb-4">Registra tus capturas, consulta el mapa de Kanto y organiza tu equipo de Pokémon Rojo Fuego.</p>
    <a href="Registrarse.php" class="btn boton-rojo boton-grande w-100">Registrarse</a>
    <p class="mt-3 mb-0 text-secondary">¿Ya te registraste? <a href="IniciarSesion.php" class="enlace-rojo">Inicia sesión</a></p>
  </div>
    <?php } ?>
    </main>

    <?php include 'pie.php'; ?>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
