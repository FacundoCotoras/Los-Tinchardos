<!--NAVBAR-->
<nav class="navbar navbar-expand-md barra-superior py-3">
  <div class="container-xl">
    <a class="navbar-brand d-flex align-items-center gap-3 text-dark" href="home.php">
      <svg class="logo" viewBox="0 0 40 40" aria-hidden="true"><circle cx="20" cy="20" r="20" fill="#c8372d"/><rect y="18" width="40" height="4" fill="#fff"/><circle cx="20" cy="20" r="6" fill="#fff" stroke="#c8372d" stroke-width="2"/><circle cx="20" cy="20" r="2.5" fill="#1f2630"/></svg>
      <div><div class="fw-bold">Mi Pokédex</div><p class="subtitulo-marca">Pokémon Rojo Fuego</p></div>
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav ms-auto align-items-md-center gap-md-2">
        <?php if (isset($_SESSION['usuario_id'])) { ?>
            <!-- CON SESIÓN: saludo y cerrar sesión -->
            <li class="nav-item">
              <span class="nav-link">Hola, <?php echo htmlspecialchars($_SESSION['nombre_usuario']); ?></span>
            </li>
            <li class="nav-item">
              <a class="btn boton-suave btn-sm" href="php/logout.php">Cerrar sesión</a>
            </li>
        <?php } else { ?>
            <!-- SIN SESIÓN: los botones de siempre -->
            <li class="nav-item">
              <a class="nav-link fw-semibold" href="./IniciarSesion.php">Iniciar sesión</a>
            </li>
            <li class="nav-item">
              <a class="btn boton-suave btn-sm" href="./Registrarse.php">Crear cuenta</a>
            </li>
        <?php } ?>
      </ul>
    </div>
  </div>
</nav>
<!--NAVBAR-->
