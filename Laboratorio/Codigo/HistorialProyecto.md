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


[18] Sistema de combate inicial
- Creada la clase Proyectil.
- Implementado sistema de objetivos para torres mediante Torre.Objetivo.
- Implementada generación automática de proyectiles al detectar enemigos en rango.
- Incorporado movimiento de proyectiles hacia el objetivo seleccionado.
- Implementada cadencia de disparo para evitar disparos continuos.
- Agregado sistema de vida para enemigos.
- Implementado daño mediante impacto de proyectiles.
- Implementada eliminación de enemigos al agotar su vida.
- Incorporado sistema de recompensas económicas por eliminación.
- Agregadas barras de vida visuales para enemigos.
- Verificada la integración completa entre torres, proyectiles y enemigos.

[19] Refactorización de combate e integración de enemigos con Base de Datos

- Creada la clase Economia.
- Trasladada la lógica de obtención de costos de defensas fuera de Game1.
- Trasladada la lógica de obtención de recompensas fuera de Game1.
- Creada la clase Combate.
- Trasladada la selección de objetivos de las torres a Combate.
- Trasladada la generación de proyectiles a Combate.
- Trasladada la actualización de proyectiles a Combate.
- Reducida la cantidad de lógica de combate presente en Game1.
- Creada la clase DatosEnemigo.
- Implementada carga de estadísticas de enemigos desde MySQL.
- Agregado campo Recompensa a la tabla EnemyTypes.
- Creado procedimiento almacenado Enemigos().
- Implementada lectura de recompensas de enemigos desde Base de Datos.
- Verificada la integración completa entre enemigos, recompensas y Base de Datos.

[20] Integración avanzada de estadísticas de combate con Base de Datos

- Implementada lectura de vida de enemigos desde Base de Datos
- Implementada lectura de velocidad de enemigos desde Base de Datos
- Implementada lectura de daño de defensas desde Base de Datos
- Agregados métodos de configuración de vida y velocidad en Enemigo
- Agregado atributo de daño configurable en Proyectil
- Incorporada obtención de daño desde DefenseTypes.DañoBase
- Verificada la correcta integración de estadísticas mediante pruebas desde MySQL

[21] Sistema de oleadas y victoria

- Integrada la clase Oleadas desarrollada por Benjamín Sala.
- Implementado sistema de oleadas progresivas.
- Incorporadas pausas entre oleadas.
- Implementada transición automática entre oleadas.
- Integrados indicadores visuales de oleada.
- Implementada condición de victoria al superar todas las oleadas.
- Incorporada pantalla de victoria.
- Verificada la correcta integración con el sistema de combate existente.

[22] Sistema de tipos de enemigos
- Integrados múltiples tipos de enemigos utilizando los registros de EnemyTypes.
- Incorporados sprites específicos para Enemigo Basico, Enemigo Rapido y Tanque.
- Implementada selección automática de tipo de enemigo según la oleada actual.
- Integrada carga dinámica de vida desde Base de Datos para cada tipo de enemigo.
- Integrada carga dinámica de velocidad desde Base de Datos para cada tipo de enemigo.
- Integrada carga dinámica de recompensas desde Base de Datos para cada tipo de enemigo.
- Verificado el comportamiento diferenciado entre enemigos rápidos y enemigos tanque.
- Comprobada la integración completa entre oleadas, sprites de enemigos y estadísticas obtenidas desde MySQL.

[23] Mejoras de interacción y venta de defensas
- Corregida la orientación visual de los enemigos.
- Unificada la dirección base utilizada por todos los sprites de enemigos.
- Adaptado el sistema de inversión horizontal para funcionar correctamente con enemigos actuales y futuros.
- Eliminado el sistema de selección mediante click derecho.
- Implementada selección de defensas mediante click izquierdo sobre una posición ocupada.
- Implementada deselección mediante click izquierdo fuera de cualquier slot.
- Unificados los sistemas de construcción y selección en un único esquema de interacción.
- Incorporado sistema de venta de defensas mediante la tecla V.
- Implementada devolución del 50% del costo original de la defensa vendida.
- Liberación automática del slot al vender una defensa.
- Eliminación correcta de la instancia de Torre asociada a la defensa vendida.
- Verificada la reconstrucción de defensas en slots previamente liberados.

[24] Sistema de mejoras y reinicio de partida
- Implementado sistema de niveles para defensas.
- Agregada propiedad Nivel a las torres.
- Inicialización automática de nuevas defensas en nivel 1.
- Incorporada mejora de defensas mediante la tecla M.
- Implementado límite máximo de mejora en nivel 3.
- Integrado sistema de detección de pulsación única para acciones con teclado.
- Corregido comportamiento de repetición al mantener presionadas las teclas.
- Integrados sprites específicos para los niveles 2 y 3 de todas las defensas.
- Implementado cambio visual automático según el nivel de mejora.
- Agregado costo de mejora dependiente del tipo de defensa.
- Implementado costo diferenciado entre nivel 1→2 y nivel 2→3.
- Integrado descuento automático de dinero al mejorar defensas.
- Incorporada información de nivel, costo de mejora y valor de venta al HUD.
- Implementado sistema de reinicio de partida mediante la tecla R del código de Benjamín Sala.
- Reinicio completo de vidas, dinero, oleadas, enemigos, proyectiles, torres y slots.
- Integrada pantalla de reinicio visible tras Victoria y Game Over del código de Benjamín Sala.


[25] Efectos funcionales de mejoras nivel 2
- Integrado disparo múltiple para lanzacohetes mejorados.
- Implementado doble misil para lanzacohetes nivel 2.
- Implementado triple misil para lanzacohetes nivel 3.
- Integrado doble disparo para cañón nivel 2.
- Aplicado modificador de daño para balancear el doble disparo del cañón.
- Integrado doble disparo para torreta nivel 2.
- Aplicado modificador de daño para balancear el doble disparo de la torreta.
- Diferenciadas mecánicamente las mejoras respecto de sus versiones base.
- Verificado comportamiento de daño contra enemigos básicos, rápidos y tanque.
- Corregido comportamiento de disparo múltiple respetando cooldown y objetivos.


[26] Mejoras nivel 3 y proyectiles visuales
- Implementado disparo pesado para cañón nivel 3.
- Implementada alta cadencia de fuego para torreta nivel 3.
- Completadas las mejoras funcionales de los tres tipos de defensa.
- Agregada separación visual para proyectiles múltiples.
- Integrado sistema de proyectiles según tipo de defensa.
- Agregados sprites específicos para proyectiles de cañón, torreta y lanzacohetes.
- Incorporada propiedad de tipo en proyectiles.
- Implementada rotación automática de proyectiles según dirección de movimiento.
- Ajustado escalado individual para cada tipo de proyectil.
- Mejorado el punto de origen de los disparos respecto a la posición de la defensa.
- Reemplazados los proyectiles temporales de depuración por sprites definitivos.

[27] Rotación de defensas y ajuste visual de sprites
- Implementada rotación automática de defensas hacia el enemigo objetivo.
- Incorporada persistencia de rotación en cada defensa.
- Integrado sistema de apuntado visual para cañón, torreta y lanzacohetes.
- Ajustado el origen de rotación de las defensas para mejorar el seguimiento de objetivos.
- Agregado desplazamiento visual específico para lanzacohetes.
- Reemplazado sistema estático de orientación por apuntado dinámico.
- Corregida alineación visual de defensas durante la rotación.
- Eliminados márgenes innecesarios en sprites de defensas.
- Mejorado el centrado visual de los modelos al rotar.
- Ajustada la posición relativa entre defensa y base de soporte.
- Realizadas pruebas visuales de rotación en los tres tipos de defensa.
- Estabilizada la presentación gráfica final de las defensas para entrega.

[28] Implementación del Rey Topo y ajustes visuales
- Integrado enemigo jefe exclusivo para la oleada final.
- Agregado sprite propio para el Rey Topo.
- Configurada la aparición de un único jefe en la oleada 5.
- Implementada habilidad de invocación periódica de enemigos básicos por parte del jefe.
- Aumentada la escala visual del Rey Topo para diferenciarlo del resto de enemigos.
- Ajustado el pivote de rotación del lanzacohetes nivel 1 para mejorar el centrado visual durante el apuntado.
- Corregidos y recortados sprites de defensas para mejorar la alineación durante la rotación.
- Realizadas pruebas de balance preliminar del jefe frente a las defensas de nivel máximo.


[29] Sistema de oleadas manuales y mejoras del Rey Topo
- Ampliado el juego a 6 oleadas.
- Implementadas composiciones manuales de enemigos para cada oleada.
- Agregada propiedad pública para consultar la cantidad de enemigos generados en la oleada actual.
- Integrada oleada final con enemigos escolta previos a la aparición del Rey Topo.
- Corregido el tamaño exclusivo del Rey Topo.
- Restaurado el tamaño normal para enemigos estándar.
- Implementado método para modificar dinámicamente el tamaño de enemigos.
- Ajustada la frecuencia de invocación del Rey Topo para generar esbirros con mayor continuidad.


[30] Interfaz de jefe y mejoras visuales de combate
- Incorporada barra de vida global para el Rey Topo.
- Agregado identificador visual "REY TOPO" durante la fase de jefe final.
- Implementada visualización numérica de vida del jefe.
- Ajustado el punto de salida de proyectiles para acompañar la orientación de las defensas.

[31] Sistema de usuarios persistente y perfiles de jugador
- Implementado sistema de registro de usuarios conectado a MySQL.
- Implementado sistema de carga de usuarios desde el menú principal.
- Agregada entrada de texto para creación y selección de perfiles.
- Incorporada validación de usuarios existentes durante el registro.
- Incorporada validación de usuarios inexistentes durante la carga.
- Implementada persistencia de victorias mediante la tabla Players.
- Asociadas las victorias al usuario actualmente cargado.
- Integrado guardado automático de victorias al completar una partida.
- Agregada visualización del jugador activo durante la partida.
- Agregada visualización de victorias acumuladas por usuario.
- Incorporados mensajes informativos para registro exitoso de usuarios.
- Incorporados mensajes informativos para carga de usuarios.
- Incorporados mensajes de error para usuarios inexistentes.
- Incorporados mensajes de error para intentos de registro duplicados.
- Integrada navegación completa del sistema de usuarios desde el menú principal.

[32] Rediseño del HUD y panel de jugador
- Integrado nuevo HUD lateral diseñado por Agus.
- Incorporada visualización permanente de dinero, vidas y oleada actual.
- Reorganizada la información de torretas seleccionadas.
- Integrada visualización contextual de mejoras y venta de defensas.
- Unificada la estética visual de la interfaz mediante paneles temáticos.
- Adaptado el HUD al sistema actual de economía y selección de torres.
- Incorporado panel independiente para información de jugador.
- Agregada visualización de usuario activo.
- Agregada visualización de victorias persistentes obtenidas desde la base de datos.
- Mejorada la legibilidad general de la interfaz durante la partida.

[33] Rebalanceo general de combate y centralización de estadísticas
- Reducido el dinero inicial de partida de 1000 a 250.
- Rebalanceados los atributos base de las defensas.
- Rebalanceados los atributos base de los enemigos.
- Ajustado el daño del Lanzacohetes para evitar estrategias dominantes.
- Incrementado significativamente el cooldown del Lanzacohetes.
- Incrementado el daño de la Torreta para convertirla en una opción viable.
- Ajustado el cooldown del Cañón para reforzar su rol de defensa equilibrada.
- Incrementada la vida del Enemigo Básico.
- Incrementada la vida del Enemigo Rápido.
- Incrementada la vida del Tanque.
- Incorporado CooldownBase a la base de datos.
- Integrada carga de cooldowns desde MySQL.
- Eliminados valores hardcodeados de cooldown en las estadísticas base de las defensas.
- Centralizados los parámetros principales de balance en la base de datos.
- Mejorada la diferenciación entre Cañón, Torreta y Lanzacohetes.
- Mejorada la variedad de estrategias viables durante la partida.


PENDIENTE

- Ajustar salida exacta de proyectiles para defensas multidisparo.
- Revisar composición definitiva de las oleadas.
- Implementar vida para defensas.
- Implementar daño de enemigos a defensas.
- Implementar sistema de reparación.
- Mejorar habilidad de invocación del Rey Topo (punto de aparición de esbirros).
- Ajustar posición visual del Rey Topo en el camino.
- Refinar interfaz de la barra de vida del jefe.
- Implementar animaciones del Rey Topo.
- Revisar interfaz final.
- Corregir comportamiento de ESC durante la escritura de usuario.
- Personaje jugable (pendiente de definición).
