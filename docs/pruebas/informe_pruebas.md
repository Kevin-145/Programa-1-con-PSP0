# Informe de ejecución de pruebas en consola

* **Programa:** Programa 1 (Media y Desviación Estándar con PSP0)
* **Fecha:** 19 de noviembre de 2026
* **Modalidad de prueba:** Ejecución directa en consola contra binario compilado (.NET 9)
* **Archivo de evidencia:** `docs/pruebas/evidencias/ejecucion_consola_casos_prueba.txt`

## 1. Resumen general de resultados

Se ejecutaron los 18 casos de prueba definidos en el plan. Cada prueba se ejecutó mediante invocación por consola, validando la salida estándar, el formato visual, el redondeo a dos decimales y el código de retorno del proceso.

| Total de casos evaluados | Casos aprobados | Casos reprobados | Porcentaje de éxito |
|---|---|---|---|
| 18 | 18 | 0 | 100 % |

## 2. Detalle de ejecución por caso de prueba

| Caso | Entrada / Condición | Resultado esperado | Resultado obtenido en consola | Código salida | Estado |
|---|---|---|---|---|---|
| CP-01 | `datos/columna1_tamano_proxy.txt` | Media: 550.60, Desv: 572.03 | Media: 550.60, Desv: 572.03 | 0 | Aprobado |
| CP-02 | `datos/columna2_horas.txt` | Media: 60.32, Desv: 62.26 | Media: 60.32, Desv: 62.26 | 0 | Aprobado |
| CP-03 | `datos/tabla3_ejemplo.txt` | Media: 638.90, Desv: 625.63 | Media: 638.90, Desv: 625.63 | 0 | Aprobado |
| CP-04 | `datos/pruebas_borde/vacio.txt` | Mensaje de archivo sin datos | "ERROR: El archivo no contiene datos..." | 1 | Aprobado |
| CP-05 | `datos/pruebas_borde/un_dato.txt` | Media: 42.50, Desv: no definida | Media: 42.50, Desv: no definida | 0 | Aprobado |
| CP-06 | `datos/pruebas_borde/sin_dispersion.txt` | Media: 7.00, Desv: 0.00 | Media: 7.00, Desv: 0.00 | 0 | Aprobado |
| CP-07 | `datos/pruebas_borde/negativos_decimales.txt` | Media: 0.00, Desv: 2.50 | Media: 0.00, Desv: 2.50 | 0 | Aprobado |
| CP-08 | `datos/pruebas_borde/orden_tres.txt` | Media: 2.00, Desv: 1.00 | Media: 2.00, Desv: 1.00 | 0 | Aprobado |
| CP-09 | `datos/pruebas_borde/lineas_en_blanco.txt` | n: 2, Media: 15.00, Desv: 7.07 | Media: 15.00, Desv: 7.07 | 0 | Aprobado |
| CP-10 | `datos/pruebas_borde/dato_no_numerico.txt` | Notifica error en línea 3 | "ERROR: Línea 3: «abc» no es un número real..." | 1 | Aprobado |
| CP-11 | `datos/pruebas_borde/solo_espacios.txt` | Archivo sin contenido | "ERROR: El archivo no contiene datos..." | 1 | Aprobado |
| CP-12 | `datos/no_existe_archivo_xyz.txt` | Archivo no encontrado | "ERROR: No se encontró el archivo..." | 1 | Aprobado |
| CP-13 | `datos/pruebas_borde/cultura_invariante.txt` | Media: 10.75, Desv: 6.01 en es-CO | Media: 10.75, Desv: 6.01 | 0 | Aprobado |
| CP-14 | Integración relativa `columna2_horas.txt` | n: 10, Media: 60.32, Desv: 62.26 | Media: 60.32, Desv: 62.26 | 0 | Aprobado |
| CP-15 | Ruta pasada por argumento en consola | Formato visual alineado F2 | Etiquetas a 14 caracteres alineadas | 0 | Aprobado |
| CP-16 | Entrada interactiva sin argumentos | Prompt interactivo de ruta | Solicita ruta, procesa y finaliza | 0 | Aprobado |
| CP-17 | Entrada interactiva con archivo vacío | Error claro sin traza | "ERROR: El archivo no contiene datos..." | 1 | Aprobado |
| CP-18 | Entrada con un solo valor numérico | Aviso sin fallo de ejecución | "Desv. estándar: no definida..." | 0 | Aprobado |

## 3. Comprobación de los valores del Assignment Kit

Los tres conjuntos de prueba oficiales del kit arrojaron concordancia exacta con la Tabla 2:

1. **Tabla 1, Columna 1 (Tamaño Proxy):**
   * Cantidad esperada: 10 datos
   * Media calculada: 550.60 (esperado: 550.60)
   * Desviación estándar calculada: 572.03 (esperado: 572.03)
   * Diferencia: 0.00
2. **Tabla 1, Columna 2 (Horas de desarrollo):**
   * Cantidad esperada: 10 datos
   * Media calculada: 60.32 (esperado: 60.32)
   * Desviación estándar calculada: 62.26 (esperado: 62.26)
   * Diferencia: 0.00
3. **Tabla 3 (Ejemplo de prueba):**
   * Cantidad esperada: 10 datos
   * Media calculada: 638.90 (esperado: 638.90)
   * Desviación estándar calculada: 625.63 (esperado: 625.63)
   * Diferencia: 0.00

## 4. Validación de casos borde y robustez

* **Entornos regionales (es-CO):** El uso de `CultureInfo.InvariantCulture` en el lector y en la interfaz garantizó que cadenas como "15.0" se procesaran numéricamente como quince unidades y no como ciento cincuenta, evitando el error común de localización.
* **Control de excepciones:** En ningún escenario de error se imprimieron trazas de pila (stack traces) ni valores indefinidos como `NaN` o `Infinity`. Todos los mensajes de fallo iniciaron con el prefijo "ERROR:" y retornaron código de salida 1.
* **Manejo de n < 2:** Cuando el archivo contiene un solo registro, la media se calcula normalmente (42.50) y en lugar de generar una división por cero en (n - 1), el sistema informa formalmente que la desviación estándar no está definida, retornando código de salida 0.

La totalidad de los requisitos funcionales y no funcionales evaluados en pruebas manuales por consola quedaron satisfechos.
