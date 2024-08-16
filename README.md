# 'El Torneo de los 3 Magos'

## Descripción del Juego

**El Torneo de los 3 Magos** es un juego de combate por turnos ambientado en el mundo de *Harry Potter*, inspirado en el icónico evento de la saga. El jugador elige un personaje de Hogwarts y se enfrenta a otros magos en duelos épicos. El objetivo es derrotar a todos los rivales y consagrarse campeón de La Copa de los Tres Magos.

## Gameplay

### Inicio

Al iniciar el juego, se presenta un menú principal con las siguientes opciones:

1. **Nueva Partida**
   - Inicia un nuevo torneo. El jugador elige un personaje y compite en una serie de duelos. El objetivo es derrotar a todos los rivales para ganar el torneo.

2. **Mostrar Ganadores**
   - Muestra el historial de ganadores de torneos anteriores. Aquí se pueden ver los detalles de los personajes que han ganado en partidas previas.

3. **Salir**
   - Cierra el juego.

### Selección del Personaje

- Al comenzar una nueva partida, el jugador selecciona un personaje a partir de un ID de la lista de personajes, los mismos leidos de un archivo JSON o, si no existe tal archivo, creados aleaoriamente.
- Cada personaje tiene habilidades y características únicas que afectan su rendimiento en los combates.

### Estructura del Combate

1. **Inicio del Duelo**
   - Se muestra un mensaje introductorio al comienzo de cada batalla, destacando el enfrentamiento entre el personaje del jugador y su oponente.

2. **Turnos de Combate**
   - **Turno del Personaje**: El jugador ataca al rival. Si el rival es derrotado, el personaje del jugador recibe una mejora en su salud.
   - **Turno del Rival**: El rival contraataca al personaje del jugador. Si el personaje del jugador es derrotado, el combate termina.

3. **Uso de Hechizos**
   - Durante el combate, en cada turno, se muestra un hechizo aleatorio obtenido de la **PotterAPI**.

### Condiciones de Victoria y Derrota

- **Victoria**: El personaje del jugador gana si derrota a todos los rivales. El jugador es coronado campeón del torneo.
- **Derrota**: Si el personaje del jugador es derrotado en cualquier combate, la partida termina y se muestra un mensaje de derrota, volviendo al menú de inicio.

### Final del Torneo

- Si el personaje del jugador sobrevive a todos los rivales, recibe el título de campeón del torneo y es agregado a la lista de ganadores.

### Historial de Ganadores

Se listan todos los personajes que ganaron el torneo. Se listan todos los personajes que ganaron el torneo. Si no existen ganadores, se muestra un mensaje informando de ello.

## API

**[PotterAPI](https://potterapi-fedeperin.vercel.app/es/spells)**

El juego utiliza la **PotterAPI** para obtener hechizos del mundo de *Harry Potter*. Estos hechizos se presentan aleatoriamente durante los combates para enriquecer la experiencia del jugador y añadir un elemento de autenticidad a los duelos.

## Instrucciones de Instalación

1. Clona el repositorio: `git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-paulaNerea.git`
2. Navega al directorio del proyecto.
3. Compila y ejecuta el proyecto utilizando tu entorno de desarrollo preferido.


