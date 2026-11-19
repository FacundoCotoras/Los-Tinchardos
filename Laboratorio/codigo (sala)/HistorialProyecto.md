# Historial del proyecto – TopoCamino

## Estructura

| Archivo | Que hace |
|---|---|
| `Program.cs` | Punto de entrada, arranca `Game1` |
| `Game1.cs` | Bucle principal: carga, update, draw, vidas, game over y victoria |
| `Mapa.cs` | Dibuja el fondo y guarda el camino (`Mapa.Camino`) |
| `Enemigo.cs` | El topo: recorre el camino punto por punto |
| `Oleadas.cs` | Las 5 oleadas: cantidad, frecuencia y velocidad de los enemigos |
| `HUD.cs` | Corazones, cartel de oleada, Game Over y Victoria |
| `Content/` | Imagenes (`mapa`, `topo`, `corazon`, `gameover`, `oleada1-5`, etc.) |
| `ArchivosDeRespaldo/` | Copia del codigo original (`Game1` + `Personaje` antes de separarlo) |

## Cambios

1. **Movimiento:** el topo recorre el camino del mapa (que hace de fondo).
2. **Varios topos y vidas:** aparecen varios topos; si uno llega al final se pierde 1 de 3 vidas. Con 0 vidas aparece el Game Over.
3. **Oleadas:** 5 oleadas con mas topos y mas velocidad; el cartel muestra en cual se esta. Al terminar la 5 aparece Victoria.
4. **Reorganizacion:** el codigo se separo en una clase por archivo (`Personaje` paso a llamarse `Enemigo`).

## Controles

- `R`: reiniciar (en Game Over o Victoria)
- `Esc`: salir

## Pendiente

- Defensas / torres y forma de eliminar topos (sin esto no se puede superar la oleada 1).
