HISTORIAL DE COMMITS DEL PROYECTO

[1] Base del proyecto
- Instalación y configuración inicial de MonoGame.
- Ventana ampliada a 1600x900 para una mejor visualización.
- Mapa cargado y escalado al tamaño de la ventana.
- Pruebas iniciales de movimiento con personaje temporal.

[2] Sistema de construcción (primera versión)
- Incorporado sprite de cañón.
- Creado primer slot de construcción funcional.
- Detección de click sobre área válida.
- Colocación de torreta al construir.
- Sistema debug para visualizar zonas de construcción.

[3] Sistema de construcción mediante listas
- Reemplazado sistema de slot único por listas.
- Implementadas listas para:
    * Posiciones de torretas.
    * Áreas de construcción.
    * Estado de ocupación de cada slot.
- Adaptado sistema debug para múltiples slots.
- Primeros dos slots funcionales.
- Cada slot permite construir de forma independiente.

[4] Refactorización del sistema de construcción
- Reemplazadas las listas independientes de posiciones, áreas de construcción y estado de ocupación.
- Creado struct Slot para almacenar toda la información de una posición construible.
- Implementada lista de Slot para gestionar las posiciones de construcción del mapa.
- Sistema de detección de click adaptado al nuevo método.
- Sistema debug adaptado para visualizar múltiples slots.
- Verificado el funcionamiento correcto con múltiples posiciones de construcción.

[5] Sistema completo de posiciones construibles
- Añadidos todos los slots de construcción del mapa.
- Configuradas las posiciones visuales de las torretas.
- Ajustadas manualmente las áreas de construcción para cada slot.
- Verificado el funcionamiento correcto de los 38 slots disponibles.
- Comprobada la compatibilidad del sistema basado en struct Slot con todas las posiciones del mapa.
- Finalizado el sistema base de colocación de defensas.

[6] Sistema de tipos de defensa
- Incorporados nuevos sprites de defensas.
- Agregados los tipos Cañón, Torreta y Lanzacohetes.
- Creado enum TipoTorre para representar cada defensa.
- Modificado struct Slot para almacenar el tipo de defensa colocada.
- Sistema de dibujo adaptado para mostrar la textura correspondiente según el tipo de torre.
- Verificado el funcionamiento correcto de múltiples tipos de defensas dentro del mapa.

[7] Selección de tipo de defensa
- Implementado sistema de selección mediante teclado.
- Tecla 1: Cañón.
- Tecla 2: Torreta.
- Tecla 3: Lanzacohetes.
- Adaptado el sistema de construcción para colocar el tipo seleccionado por el jugador.
- Verificado el funcionamiento correcto de construcción y reemplazo de defensas en cualquier slot.

[8] Sistema de selección e inspección de defensas
- Implementada selección de defensas mediante click derecho.
- Incorporado sistema de deselección al hacer click fuera de una defensa.
- Agregado sistema de alcance visual para la defensa seleccionada.
- Implementados alcances distintos para cada tipo de defensa.
- Sustituido sistema temporal de depuración por anillo visual de alcance.
- Verificado el funcionamiento correcto de selección, deselección y visualización de alcance.

[9] Integración inicial con Base de Datos
- Instalado MySqlConnector.
- Implementada conexión entre MonoGame y MySQL.
- Ejecutada consulta mediante Stored Procedure.
- Lectura correcta de registros de DefenseTypes.
- Verificada la comunicación entre el juego y la base de datos.

[10] Integración funcional de estadísticas desde Base de Datos
- Creada la clase DatosDefensa.
- Implementada una colección en memoria para almacenar las defensas obtenidas desde la BD.
- Modificada la lectura del Stored Procedure Defensas() para cargar los atributos de cada defensa.
- Incorporado el campo Rango al procedimiento almacenado.
- Verificada la carga correcta de Nombre, Costo, Daño, Vida y Rango.
- Reemplazados los rangos hardcodeados por valores obtenidos desde MySQL.
- Comprobada la actualización dinámica del juego al modificar registros de DefenseTypes.
- Validada la utilización de datos de la BD dentro de la lógica de MonoGame.

[11] Sistema económico inicial
- Implementado dinero inicial de partida.
- Creada la función ObtenerCosto() utilizando los datos cargados desde la base de datos.
- Las defensas ahora consumen recursos al construirse.
- Bloqueada la construcción cuando el jugador no dispone de dinero suficiente.
- Agregado HUD mostrando dinero disponible en tiempo real.
- Agregado HUD mostrando la defensa seleccionada.
- Agregado HUD mostrando el costo de la defensa seleccionada.
- Configurada la SpriteFont para soportar caracteres especiales y acentos (ñ, á, etc.).

[12] Reorganización inicial del proyecto

- Creado archivo TipoTorre.cs.
- Creado archivo Slot.cs.
- Creado archivo DatosDefensa.cs.
- Creado archivo BaseDatos.cs.
- Creado archivo HUD.cs.
- Separadas estructuras y sistemas auxiliares de Game1.cs.
- Reorganizada la arquitectura del proyecto para facilitar futuras ampliaciones.
- Verificado el funcionamiento correcto tras la refactorización.
- Creación de archivo HistorialProyecto.md

[13] Refactorización del sistema de slots
- Creado archivo Mapa.cs.
- Movida toda la configuración de slots de construcción a una clase independiente.
- Implementado método Mapa.CrearSlots().
- Eliminados los 38 bloques de inicialización de slots de Game1.cs.
- Simplificado el método Initialize().
- Separados los datos del mapa de la lógica principal del juego.
- Reducido significativamente el tamaño de Game1.cs.
- Verificado el funcionamiento correcto de construcción, selección y visualización de alcance tras la refactorización.

[14] Integración inicial del sistema de enemigos
- Integrado el sistema de movimiento del enemigo desarrollado por mi compañero Benjamín Sala.
- Incorporada la clase Enemigo al proyecto principal.
- Agregada carga de textura para enemigos.
- Implementada generación de enemigo de prueba.
- Integrado sistema de recorrido por waypoints.
- Adaptada la ruta al mapa escalado de 1600x900.
- Corregido error al finalizar el recorrido.
- Verificado el movimiento completo entre entrada y salida.
- Hecho sistema debug para ver waypoints del recorrido de enemigos.

[15] Generación continua de enemigos
- Implementado sistema de generación automática de enemigos.
- Añadido contador de aparición de enemigos.
- Configurada frecuencia de generación mediante framesEntreEnemigos.
- Adaptada la integración del sistema para utilizar la clase Enemigo.
- Verificada la generación simultánea de múltiples enemigos sobre el mapa.
- Comprobado el recorrido correcto de múltiples enemigos utilizando los waypoints adaptados.

  [16] Sistema de vidas de la base
- Integrado sistema de vidas al proyecto principal.
- Implementada pérdida de vidas cuando un enemigo alcanza la salida.
- Eliminación automática de enemigos al finalizar el recorrido.
- Integrados indicadores visuales mediante corazones.
- Integrada pantalla de Game Over.
- Adaptado el sistema desarrollado por Benjamín Sala al proyecto principal.
- Verificado el funcionamiento correcto de vidas, derrota y eliminación de enemigos.

[17] Sistema de objetivos para torres
- Creado archivo Torre.cs.
- Implementada lista de torres independientes del sistema de slots.
- Creada instancia de Torre al construir una defensa.
- Integrado almacenamiento de posición, tipo y rango en cada torre.
- Implementado sistema de búsqueda de enemigos dentro del alcance de cada torre.
- Incorporada propiedad Objetivo para almacenamiento del enemigo detectado.
- Adaptado el sistema para que múltiples torres puedan detectar enemigos simultáneamente.
- Implementado sistema debug para ver enemigos detectados.
- Verificado el funcionamiento correcto de detección de objetivos y asignación de enemigos a torres.
  

PENDIENTE
- Completar sistema de enemigos (oleadas y atributos de enemigos).
- Sistema de proyectiles.
- Sistema de ataque y daño a enemigos.
- Obtener dinero al eliminar enemigos.
- Mejoras, reparación y venta de defensas.
- Personaje jugable.
