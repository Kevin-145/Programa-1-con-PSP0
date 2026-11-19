# Propuesta de mejora del proceso (PIP #1 - Process Improvement Proposal)

* **Estudiante:** Kevin Santiago Rodríguez Oliveros
* **Programa:** Programa 1 (Media y desviación estándar)
* **Nivel PSP actual:** PSP0
* **Fecha:** 19 de noviembre de 2026

## Registro de propuestas de mejora

| Número | Problema identificado (respaldado con datos) | Propuesta de acción concreta | Prioridad | Criterio de medición para el Programa 2 |
|---|---|---|---|---|
| 1 | El 77.8 % de los defectos (7 de 9) se inyectó en la fase de Código. Tres de ellos (D6 con la fórmula de n - 1, D7 con cultura invariante y D9 con lista vacía) ya estaban resueltos en el diseño previo y aun así se programaron de forma errónea. | Mantener visible el documento de pseudocódigo en una ventana contigua mientras se programa, marcando mentalmente cada estructura al transcribirla. Realizar una lectura rápida contra las reglas de codificación (E-12 y E-13) antes de invocar la compilación. | Alta | Defectos de tipo 70 (Datos) y 80 (Función) eliminados en la fase de pruebas ≤ 1. |
| 2 | El tiempo medio para corregir un defecto en Pruebas fue de 6.75 minutos, 4.5 veces mayor que en Compilación (1.5 minutos). | Preparar y ejecutar manualmente en consola los casos de prueba con los datos de referencia del kit apenas termine la primera compilación limpia de la calculadora estadística, antes de construir interfaces adicionales. | Media | Tiempo total de corrección de defectos en pruebas < 15 minutos. |
| 3 | Subestimación del tiempo total en un +11.3 % (334 minutos reales frente a 300 planeados), concentrándose la diferencia en Código (+28 min) y Pruebas (+22 min). | Utilizar la distribución porcentual real del Programa 1 (Código ≈ 35 % y Pruebas ≈ 25 % del tiempo total) como base para la estimación del Programa 2, conservando el margen de contingencia del 10 %. | Media | Error porcentual de estimación de tiempo total acotado entre -10 % y +10 %. |
| 4 | Se requirió ajustar manualmente un bloque de tiempo de 27 minutos debido a que el cronómetro de PSP Tracker quedó detenido tras una pausa de almuerzo. | Utilizar el estado de pausa de la herramienta de registro en lugar de cerrar el proyecto ante interrupciones breves, y revisar el estado del temporizador al retomar la sesión de trabajo. | Baja | 100 % de los registros de tiempo capturados directamente con el temporizador activo. |

## Compromiso para el Programa 2 (PSP0.1)

Incorporar las propuestas 1 y 2 en la lista de chequeo personal de desarrollo y registrar formalmente este formulario PIP en PSP Tracker al iniciar el siguiente ciclo de trabajo.
