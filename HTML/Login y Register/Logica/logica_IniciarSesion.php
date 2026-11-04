<?php
session_start();
ob_start();            // conexion.php trae un HTML al final; esto lo descarta
include 'conexion.php';
ob_end_clean();
$conn->set_charset("utf8mb4");
$u = $_POST['user'];
$p = $_POST['pass'];

$stmt = $conn->prepare("CALL ValidarSesion(?)");
$stmt->bind_param("s", $u);
$stmt->execute();
$res = $stmt->get_result();

// Si existe el correo, se compara la contraseña escrita con la guardada
if (($fila = $res->fetch_assoc()) && password_verify($p, $fila['clave'])) {
// ÉXITO: Creamos las variables de sesión
$_SESSION['usuario_id'] = $fila['idusuario'];
$_SESSION['correo_usuario'] = $fila['correo'];
$_SESSION['nombre_usuario'] = $fila['nombre'];
header("Location: ../home.php"); // Entra al panel
} else {
echo "<script>
alert('Ese usuario no existe o los datos son incorrectos. Si no tienes cuenta, crea una nueva.');
window.location.href = '../IniciarSesion.php';
</script>";
}
?>
