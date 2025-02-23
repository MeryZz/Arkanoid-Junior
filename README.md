# Arkanoid-Junior
Proyecto 2ª evaluación PMDM

# 1. Visión General del Juego

**Título del juego**: Arkanoid Junior  
**Concepto Básico**: Arkanoid Junior es una reinterpretación del clásico juego de rompebloques, en el que el jugador controla una raqueta que se mueve de izquierda a derecha para evitar que una bola caiga. La misión es destruir bloques de colores y ganar puntos, mientras se avanza a través de niveles progresivos con dificultad creciente.  
**Género**: Arcade, rompebloques  
**Plataforma Objetivo**: PC (Unity) con sistema operativo Linux, Windows o WebGL.

# 2. Mecánicas de Juego

- **Movimiento de la raqueta**: La raqueta se controla utilizando las teclas A (para mover hacia la izquierda) y D (para mover hacia la derecha). El jugador debe evitar que la bola se caiga de la pantalla moviendo la raqueta.  
- **Comportamiento de la Bola**: La bola rebota de manera dinámica al chocar. La velocidad de la bola aumenta gradualmente conforme avanza el juego y los niveles, creando un desafío progresivo. Además, se puede cambiar la dirección de la bola si el paddle se mueve mientras la bola está en contacto con él.  
- **Tipos de Bloques y sus Características**:
  - Bloques Rosas: +5 puntos
  - Bloques Verdes: +4 puntos
  - Bloques Azules: +3 puntos
  - Bloques Rojos: -1 punto (penalización)  
- **Condiciones de Victoria y Derrota**:
  - **Victoria**: El jugador gana cuando destruye todos los bloques de los dos niveles que hay.  
  - **Derrota**: Si el jugador pierde todas las vidas (cuando la bola cae fuera de la pantalla), se activa la pantalla de GAME OVER.

# 3. Programación

## Estructura de Clases

- **GameManager**: Gestiona el flujo del juego, mantiene el control del puntaje, las vidas, los niveles y la transición entre escenas.
- **Spawner**: Controla la creación de los bloques en posiciones aleatorias.
- **Bola**: Administra el comportamiento de la bola, como su movimiento y la colisión con los bloques y la raqueta.
- **Raqueta**: Controla su movimiento y su interacción con la bola.
- **BlockPool**: Se encarga de manejar el reciclaje de bloques. Cuando un bloque es destruido, en lugar de ser destruido completamente, se desactiva y se guarda en el pool para ser reutilizado más tarde. Esto mejora la eficiencia al evitar la creación y destrucción constantes de objetos.

## Estructura de Control

El flujo principal se basa en el **GameManager**, que maneja las escenas (menú de inicio, niveles, GAME OVER). Los bloques se generan mediante el **Spawner**, y el comportamiento de la **Bola** y la **Raqueta** está definido en sus respectivos scripts. Además, cuando un bloque desaparece, el **BlockPool** se encarga de gestionarlo, lo que permite que el bloque sea reutilizado en el futuro para otros niveles.

# 4. Diseño de Niveles

- **Estructura de los Niveles**: Cada nivel contiene una disposición aleatoria de bloques que deben ser destruidos. Los niveles se hacen progresivamente más difíciles y aumenta cuando sube de nivel.
- **Progresión de Dificultad**: La velocidad de la bola aumenta de diferente forma en cada nivel:
  - En el nivel 1: aumenta 6 puntos de velocidad cada 10 segundos.
  - En el nivel 2: aumenta 6 puntos de velocidad cada 8 segundos.
- **Variaciones en la Disposición de los Bloques**: Los bloques no solo varían en color, sino también en su disposición, ya que esta es aleatoria.

# 5. Sistema de Puntuación

- **Bloque rosa**: +5 puntos  
- **Cómo se Ganan Puntos**: Cada bloque tiene un valor diferente dependiendo de su color:
  - **Bloque verde**: +4 puntos
  - **Bloque azul**: +3 puntos
  - **Bloque amarillo**: +1 punto
  - **Bloque rojo**: -1 punto

# 6. Interfaz de Usuario

- **HUD (Heads-Up Display)**:
  - **Puntos**: Se muestra en la parte superior derecha de la pantalla.
  - **Vidas**: Se muestra el número de vidas restantes en la parte inferior derecha de la pantalla.
  - **Nivel Actual**: Se indica en la parte superior izquierda de la pantalla.

- **Menús del Juego**:
  - **Menú Principal**: Contiene botones para "Jugar" (Play) y "Salir" (Exit).
  - **Pantalla de Game Over**: Muestra el “GAME OVER” y contiene un botón (Restart) para reiniciar el juego.

# 7. Arte y Estilo Visual

- **Estilo Gráfico**: Estilo 2D, con un enfoque retro pero moderno, inspirado en el estilo pixel art.
- **Paleta de Colores**:
  - Bloques: Cada color tiene su propio color y valor de puntos (rosa, verde, azul, rojo, amarillo).
  - Fondo: El típico fondo azul que resalta los bloques, la bola y la raqueta.
  - Raqueta y Bola: Colores que contrastan con el fondo oscuro.
- **Diseño de Sprites**:
  - **Raqueta**: Un bloque alargado y estrecho.
  - **Bola**: Una esfera pequeña y luminosa.
  - **Bloques**: Rectángulos con colores que llaman la atención.
  - **Fondo**: Un fondo de hexágonos azules.
  - **Bordes**: Los bordes grises para delimitar el final de la pantalla del juego.

# 8. Audio

- **Efectos de Sonido**:
  - Sonido en el menú principal hasta que pulsas alguno de los dos botones.
  - Sonido al iniciar cada una de las escenas de juego.
  - Sonido al ir a la pantalla de Game Over.

# 9. Características Técnicas

- **Motor de Juego**: Unity 2D
- **Requisitos de Rendimiento**: Requiere un PC con especificaciones medias para asegurar una experiencia fluida. La optimización será clave para asegurar que se ejecute sin problemas incluso en dispositivos más modestos. Está desarrollado en la versión de “Unity 6”, disponible para sistemas operativos como Linux, Windows o WebGL.

# 10. Monetización

- **Modelo de Negocio**: Actualmente el juego será gratuito para jugar, con posibilidad de en un futuro aplicar publicidad opcional o compras dentro del juego para adquirir power-ups o vidas extra.

# 11. Planificación del Desarrollo

## Fases del Desarrollo

1. **Fase de Conceptualización**: Definición del juego y mecánicas básicas.
2. **Fase de Prototipo**: Desarrollo de las primeras versiones de la raqueta, la bola y los bloques.
3. **Fase de Implementación**: Adición de la funcionalidad completa, incluyendo el **GameManager** y el **Spawner**.
4. **Fase de Testing**: Pruebas internas, corrección de errores y ajustes de dificultad.
5. **Fase de Optimización y Finalización**: Ajuste de gráficos, música y pulido del rendimiento.
   
