<?php
session_start();
ob_start();            // conexion.php trae un HTML al final; esto lo descarta
include 'conexion.php';
ob_end_clean();
$conn->set_charset("utf8mb4");
$nombre = $_POST['nombre'];
$apellido = $_POST['apellido'];
$correo = $_POST['correo'];
$contrasena = $_POST['contrasena'];
$confirmar = $_POST['confirmar'];

if ($contrasena != $confirmar) {
echo "<script>
alert('Las contraseñas no coinciden.');
window.location.href = '../Registrarse.php';
</script>";
exit();
}

// La contraseña se guarda encriptada
$hash = password_hash($contrasena, PASSWORD_DEFAULT);

$stmt = $conn->prepare("CALL NuevoUsuario(?, ?, ?, ?)");
$stmt->bind_param("ssss", $correo, $nombre, $hash, $apellido);
$stmt->execute();
$res = $stmt->get_result();
$fila = $res->fetch_assoc();

if ($fila['resultado'] == '3') {
$_SESSION['usuario_id'] = $fila["id"];
$_SESSION['correo_usuario'] = $correo;
$_SESSION['nombre_usuario'] = $nombre;
header("Location: ../home.php");
} else {
echo "<script>
alert('Ese correo ya está registrado. Inicia sesión o usa otro.');
window.location.href = '../Registrarse.php';
</script>";
}
?>
