# Plan de pruebas: Casos de prueba del Programa 1

Este documento define los 18 casos de prueba (CP-01 a CP-18) diseñados para verificar el cumplimiento de los requisitos funcionales y no funcionales del Programa 1 mediante ejecución directa en consola.

Los valores esperados provienen de las tablas de referencia del Assignment Kit (SEI, 2010), de cálculos algebraicos directos y de los criterios de aceptación definidos en la planeación.

## Matriz de casos de prueba

| Identificador | Requisitos asociados | Archivo de entrada o condición | Resultado esperado | Criterio de verificación en consola |
|---|---|---|---|---|
| CP-01 | RF-03, RF-04, RNF-03 | `datos/columna1_tamano_proxy.txt` (10 valores) | Media: 550.60, Desv. estándar: 572.03 | Salida formateada a dos decimales y código de salida 0. |
| CP-02 | RF-03, RF-04, RNF-03 | `datos/columna2_horas.txt` (10 valores) | Media: 60.32, Desv. estándar: 62.26 | Salida formateada a dos decimales y código de salida 0. |
| CP-03 | RF-03, RF-04, RNF-03 | `datos/tabla3_ejemplo.txt` (10 valores) | Media: 638.90, Desv. estándar: 625.63 | Salida formateada a dos decimales y código de salida 0. |
| CP-04 | RF-06 | `datos/pruebas_borde/vacio.txt` (0 bytes) | Notificación de archivo sin datos | Mensaje "ERROR: El archivo no contiene datos..." y código 1. |
| CP-05 | RF-04, RF-06 | `datos/pruebas_borde/un_dato.txt` (valor 42.5) | Media: 42.50, Desviación no definida | Mensaje indicando que se requieren mínimo 2 datos y código 0. |
| CP-06 | RF-04 | `datos/pruebas_borde/sin_dispersion.txt` (7, 7, 7, 7) | Media: 7.00, Desv. estándar: 0.00 | Verificación de dispersión nula y código 0. |
| CP-07 | RF-03, RF-04 | `datos/pruebas_borde/negativos_decimales.txt` (-2.5, 0, 2.5) | Media: 0.00, Desv. estándar: 2.50 | Manejo de signo y números reales, código 0. |
| CP-08 | RF-02 | `datos/pruebas_borde/orden_tres.txt` (3, 1, 2) | n: 3, Media: 2.00, Desv. estándar: 1.00 | Almacenamiento correcto en lista enlazada y código 0. |
| CP-09 | RF-01 | `datos/pruebas_borde/lineas_en_blanco.txt` (10, blank, 20) | n: 2, Media: 15.00, Desv. estándar: 7.07 | Omisión de líneas vacías o con espacios, código 0. |
| CP-10 | RF-06, RNF-05 | `datos/pruebas_borde/dato_no_numerico.txt` (línea 3: abc) | Reporte específico de línea errónea | Mensaje "ERROR: Línea 3: «abc» no es un número real..." y código 1. |
| CP-11 | RF-06 | `datos/pruebas_borde/solo_espacios.txt` (espacios y saltos) | Archivo sin contenido numérico | Mensaje "ERROR: El archivo no contiene datos..." y código 1. |
| CP-12 | RF-06 | Archivo inexistente (`datos/no_existe_archivo_xyz.txt`) | Archivo no encontrado | Mensaje "ERROR: No se encontró el archivo..." y código 1. |
| CP-13 | RNF-02 | `datos/pruebas_borde/cultura_invariante.txt` (15.0, 6.5) en es-CO | Media: 10.75, Desv. estándar: 6.01 | Interpretación con punto decimal sin importar cultura, código 0. |
| CP-14 | RF-01 | Archivo real con ruta relativa (`datos/columna2_horas.txt`) | n: 10, Media: 60.32, Desv. estándar: 62.26 | Integración de lectura en disco y código 0. |
| CP-15 | RF-05, RF-07 | Ejecución pasando ruta por argumento `args[0]` | Impresión alineada y formateada | Encabezado, etiquetas a 14 caracteres y código 0. |
| CP-16 | RF-07 | Ejecución interactiva sin argumentos suministrados | Solicitud interactiva de ruta | Muestra prompt de captura, lee la ruta y procesa con código 0. |
| CP-17 | RF-06, RF-07 | Entrada interactiva suministrando archivo vacío | Manejo controlado de error | Mensaje "ERROR: El archivo no contiene datos..." sin trazas y código 1. |
| CP-18 | RF-04, RF-06 | Entrada interactiva o por argumento con un solo dato | Cálculo parcial sin excepción no controlada | Media calculada, aviso de desviación no definida y código 0. |

## Cobertura de requisitos

* **RF-01 (Lectura de archivo línea por línea):** CP-01, CP-02, CP-03, CP-09, CP-14.
* **RF-02 (Estructura de lista enlazada propia):** CP-08.
* **RF-03 (Media aritmética):** CP-01, CP-02, CP-03, CP-05, CP-06, CP-07, CP-08, CP-09, CP-13, CP-14.
* **RF-04 (Desviación estándar muestral con n - 1):** CP-01, CP-02, CP-03, CP-05, CP-06, CP-07, CP-08, CP-09, CP-13, CP-14, CP-18.
* **RF-05 (Presentación alineada con 2 decimales):** CP-01, CP-02, CP-03, CP-15.
* **RF-06 (Validación de entradas y mensajes de error):** CP-04, CP-05, CP-10, CP-11, CP-12, CP-17, CP-18.
* **RF-07 (Recepción de ruta por argumento o consola):** CP-15, CP-16, CP-17.
* **RNF-01 (Plataforma .NET 9):** Todos los casos.
* **RNF-02 (Cultura invariante / punto decimal):** CP-02, CP-05, CP-07, CP-09, CP-10, CP-13.
* **RNF-03 (Precisión numérica double):** CP-01, CP-02, CP-03.
* **RNF-04 (Arquitectura en capas y cero advertencias):** Verificado en compilación.
* **RNF-05 (Claridad de mensajes de error):** CP-04, CP-10, CP-11, CP-12, CP-17.
* **RNF-06 (Eficiencia algorítmica):** CP-01, CP-02, CP-03.
* **RNF-07 (Verificación manual por consola):** CP-01 a CP-18.
* **RNF-08 (Control de versiones Git por fase):** Historial de confirmaciones.
