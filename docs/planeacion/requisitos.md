# Programa 1: Media y desviación estándar - Requisitos del sistema

Fuente: Assignment Kit for Program 1 (SEI, 2010). Nivel PSP0.

## Enunciado

Desarrollar un programa en consola que calcule la media aritmética y la desviación estándar de una serie de n números reales leídos desde un archivo de texto. Los datos leídos deben almacenarse en memoria mediante una lista enlazada desarrollada por cuenta propia, sin utilizar colecciones predefinidas del lenguaje como List<double>. Los resultados deben verificarse con los datos de prueba de la Tabla 1 del material de trabajo.

## Preguntas resueltas antes de estimar

| Número | Pregunta inicial | Decisión adoptada |
|---|---|---|
| 1 | ¿La desviación estándar es muestral o poblacional? | Muestral. La fórmula del kit divide la suma de cuadrados entre n - 1. |
| 2 | ¿Cómo ingresan los datos al programa? | Mediante lectura de un archivo de texto plano indicado por argumento o solicitado por consola. |
| 3 | ¿Qué formato tiene el archivo de entrada? | Un número real por cada línea, empleando el punto como separador decimal. Las líneas vacías o en blanco se omiten. |
| 4 | ¿Se pueden usar listas genéricas del framework (.NET)? | No. El enunciado solicita expresamente una lista enlazada propia mediante nodos y referencias. |
| 5 | ¿Cuántos decimales se deben mostrar en pantalla? | Dos decimales exactos con punto, conforme a la Tabla 2 de resultados del kit. |
| 6 | ¿Cómo se verificará la solución? | Mediante pruebas manuales por consola contra casos normales, límites y de error, comprobando salidas y códigos de terminación. |

## Requisitos funcionales

| Código | Descripción | Criterio de aceptación |
|---|---|---|
| RF-01 | Leer n números reales desde un archivo de texto plano, uno por línea. | Procesa correctamente los 10 valores de cada columna de la Tabla 1 e ignora líneas en blanco o con espacios. |
| RF-02 | Almacenar los números leídos en una estructura de lista enlazada propia. | La clase ListaEnlazada almacena cada valor en un nodo independiente, preservando la cantidad n y el orden de ingreso. |
| RF-03 | Calcular la media aritmética del conjunto de datos. | Con los datos de la Tabla 1 obtiene 550.60 para la columna 1 y 60.32 para la columna 2, con una diferencia máxima de 0.01. |
| RF-04 | Calcular la desviación estándar muestral dividiendo entre n - 1. | Con los datos de la Tabla 1 obtiene 572.03 para la columna 1 y 62.26 para la columna 2, con diferencia máxima de 0.01. Si n = 1, indica que no está definida. |
| RF-05 | Presentar n, la media y la desviación estándar formateadas a dos decimales. | La interfaz de consola imprime los valores con dos decimales (formato F2) y con las etiquetas alineadas verticalmente. |
| RF-06 | Validar los datos de entrada y notificar errores claramente al usuario. | Si el archivo no existe, está vacío, contiene caracteres no numéricos o no tiene datos suficientes, muestra un mensaje con el prefijo "ERROR:" y finaliza con código de salida 1 sin emitir trazas de excepción ni valores NaN. |
| RF-07 | Permitir suministrar la ruta del archivo por argumento de consola o por entrada interactiva. | Si se pasa la ruta como argumento (args[0]), procesa el archivo inmediatamente. Si se ejecuta sin argumentos, solicita la ruta al usuario antes de continuar. |

## Requisitos no funcionales

| Código | Descripción | Criterio de aceptación |
|---|---|---|
| RNF-01 | Plataforma y tecnología. | Aplicación de consola en C# sobre .NET 9, ejecutable en Windows y Linux mediante el comando dotnet run. |
| RNF-02 | Independencia de la cultura regional. | El programa analiza y muestra números con punto decimal utilizando CultureInfo.InvariantCulture, asegurando funcionamiento uniforme en sistemas con configuración es-CO. |
| RNF-03 | Precisión de cálculo. | Las operaciones matemáticas se realizan con tipos de datos double, garantizando concordancia con las tablas del kit. |
| RNF-04 | Mantenibilidad y arquitectura en capas. | Código organizado en Dominio, Infraestructura y Presentación. Métodos de máximo 30 líneas y compilación limpia con TreatWarningsAsErrors activado. |
| RNF-05 | Claridad en la interacción con el usuario. | Los mensajes de error explican de forma directa la causa del fallo y señalan la acción correctiva (por ejemplo, el número de línea exacto de un dato no válido). |
| RNF-06 | Eficiencia en inserción y recorrido. | La lista enlazada mantiene referencia al último nodo para registrar elementos en tiempo constante O(1), y los cálculos se efectúan en tiempo lineal O(n). |
| RNF-07 | Validación por consola y registro de evidencias. | Verificación manual de 18 casos de prueba directamente en la terminal, almacenando el resultado obtenido en archivos de texto dentro de docs/pruebas/evidencias/. |
| RNF-08 | Control de versiones alineado a PSP0. | Repositorio Git con confirmaciones individuales para cada fase del proceso: planeación, diseño, código, compilación, pruebas y postmortem. |
