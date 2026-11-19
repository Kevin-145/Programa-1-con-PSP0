# Resumen del plan de proyecto (PPS - Project Plan Summary)

* **Estudiante:** Kevin Santiago Rodríguez Oliveros
* **Programa:** Programa 1 (Media y desviación estándar)
* **Nivel:** PSP0
* **Fecha de cierre:** 19 de noviembre de 2026
* **Repositorio:** https://github.com/Kevin-145/Programa-1-con-PSP0

## 1. Registro de tiempos por fase

| Fase del proceso PSP0 | Tiempo planeado (min) | Tiempo real (min) | Porcentaje del tiempo total | Desviación respecto al plan (min) |
|---|---:|---:|---:|---:|
| Planificación | 30 | 32 | 9.6 % | +2 |
| Diseño | 50 | 54 | 16.2 % | +4 |
| Código | 90 | 118 | 35.3 % | +28 |
| Compilación | 15 | 21 | 6.3 % | +6 |
| Pruebas (consola) | 60 | 82 | 24.6 % | +22 |
| Postmortem | 25 | 27 | 8.0 % | +2 |
| Margen de contingencia | 30 | — | — | — |
| **Total acumulado** | **300** | **334** | **100.0 %** | **+34** |

* **Error de estimación:** (334 - 300) / 300 = **+11.3 %** (subestimación moderada).
* La contingencia del 10 % prevista en la planeación ayudó a compensar el tiempo adicional invertido en la depuración durante la codificación y la ejecución de casos manuales en pruebas.

## 2. Registro de defectos inyectados y eliminados

| Fase PSP0 | Defectos inyectados | Porcentaje inyectados | Defectos eliminados | Porcentaje eliminados |
|---|---:|---:|---:|---:|
| Planificación | 1 | 11.1 % | 0 | 0.0 % |
| Diseño | 0 | 0.0 % | 1 | 11.1 % |
| Código | 7 | 77.8 % | 0 | 0.0 % |
| Compilación | 0 | 0.0 % | 4 | 44.4 % |
| Pruebas (consola) | 1 | 11.1 % | 4 | 44.4 % |
| Postmortem | 0 | 0.0 % | 0 | 0.0 % |
| **Total** | **9** | **100.0 %** | **9** | **100.0 %** |

## 3. Clasificación de defectos por tipo y costo de corrección

| Tipo de defecto (Estándar PSP) | Cantidad | Identificadores | Minutos invertidos en corregir |
|---|---:|---|---:|
| 20 Sintaxis | 3 | D2, D3, D8 | 3 |
| 30 Construcción | 1 | D4 | 2 |
| 40 Asignación | 1 | D5 | 2 |
| 60 Chequeo / Lógica de control | 1 | D9 | 6 |
| 70 Datos | 1 | D7 | 12 |
| 80 Función / Algoritmo | 2 | D1, D6 | 11 |
| **Total general** | **9** | | **36** |

* **Costo medio de corrección en Compilación:** 1.5 minutos por defecto (4 defectos resueltos en 6 minutos).
* **Costo medio de corrección en Pruebas:** 6.75 minutos por defecto (4 defectos resueltos en 27 minutos).
* Diagnosticar y corregir un defecto en la fase de pruebas costó 4.5 veces más tiempo que detectarlo oportunamente durante la compilación.

## 4. Medición del tamaño del software (LOC)

* **Criterio de conteo aplicado:** Líneas de código C# escritas directamente en la solución, excluyendo líneas en blanco, comentarios (`//`, `///`, `/* */`) y líneas que contienen únicamente llaves de apertura o cierre (`{`, `}`).

| Archivo fuente en `src/Programa1.Estadistica/` | Responsabilidad / Capa | Líneas de código efectivas (LOC) |
|---|---|---:|
| `Program.cs` | Punto de entrada y configuración UTF-8 | 3 |
| `Aplicacion.cs` | Orquestación general del flujo y códigos de salida | 20 |
| `Dominio/Nodo.cs` | Estructura del nodo simple | 5 |
| `Dominio/ListaEnlazada.cs` | Estructura de datos dinámica con inserción O(1) | 19 |
| `Dominio/CalculadoraEstadistica.cs` | Algoritmos de media y desviación muestral | 25 |
| `Dominio/ResultadoEstadistico.cs` | Registro inmutable de resultados | 2 |
| `Dominio/DatosInsuficientesException.cs` | Excepción de dominio para n insuficiente | 4 |
| `Infraestructura/LectorArchivoNumeros.cs` | Lectura de archivos y conversión con cultura invariante | 28 |
| `Infraestructura/DatosInvalidosException.cs` | Excepción para archivo no numérico o vacío | 5 |
| `Presentacion/ConsolaUI.cs` | Interfaz de consola y formato alineado F2 | 27 |
| **Total de código nuevo desarrollado** | **10 archivos fuente en producción** | **138** |

* **Productividad neta:** 138 LOC / 5.56 horas = **24.8 LOC/hora**.
* **Densidad de defectos:** 9 defectos / 0.138 KLOC = **65.2 defectos/KLOC**.

## 5. Lista de verificación de consistencia (Checklist PSP0)

- [x] El tiempo real acumulado (334 minutos) coincide exactamente con los registros del Time Log en PSP Tracker.
- [x] Cada defecto registrado cuenta con fecha, tipo, fase de inyección, fase de remoción y tiempo de solución.
- [x] Ningún defecto tiene fase de remoción anterior a su fase de inyección.
- [x] Los defectos eliminados en compilación (D2 a D5) corresponden a los errores del compilador (`CS1002`, `CS0103`, `CS0266`).
- [x] Los defectos detectados en pruebas (D6, D7, D9) corresponden a divergencias observadas en los primeros ensayos de consola y documentados en evidencias.
- [x] El defecto D8 corresponde a un fallo de sintaxis introducido al corregir D7 (Fix Ref = 7).
- [x] El historial de Git cuenta con confirmaciones individuales para cada fase del ciclo de vida PSP0.
- [x] Los resultados de cálculo del sistema coinciden exactamente con la Tabla 2 y Tabla 3 del Assignment Kit (550.60 / 572.03, 60.32 / 62.26 y 638.90 / 625.63).

## 6. Lecciones aprendidas

1. La mayor parte de los defectos (cerca del 78 %) se introdujo durante la fase de codificación. Casos como la desviación muestral (dividir entre n - 1 en lugar de n) y el manejo de cultura regional ya estaban contemplados en el diseño, lo que demuestra la necesidad de contrastar el código contra el pseudocódigo paso a paso.
2. Los defectos conceptuales y de datos (tipos 70 y 80) demandaron la mayor cantidad de tiempo de corrección (23 minutos en total).
3. La verificación manual estructurada por consola permitió identificar y resolver casos borde críticos (como archivos con solo espacios o un único valor) sin necesidad de infraestructura externa.
