# Programa 1: Media y Desviación Estándar con PSP0

Implementación del **Programa 1** del ciclo Personal Software Process (PSP0), desarrollado en **C# sobre .NET 9** siguiendo las especificaciones del *Assignment Kit for Program 1* (Software Engineering Institute - SEI).

El programa lee un conjunto de n números reales desde un archivo de texto plano, los almacena en memoria dinámica utilizando una **lista enlazada simple propia** (sin librerías de colecciones genéricas) y calcula la **media aritmética** y la **desviación estándar muestral** (dividiendo entre n - 1).

## Estructura del repositorio

```text
├── Programa1.sln                               # Solución principal del proyecto
├── .gitignore                                  # Reglas de exclusión de artefactos y binarios
├── README.md                                   # Guía de uso y documentación general
├── datos/                                      # Archivos de entrada para pruebas
│   ├── columna1_tamano_proxy.txt               # Datos de prueba: Columna 1 del Kit (Tabla 1)
│   ├── columna2_horas.txt                      # Datos de prueba: Columna 2 del Kit (Tabla 1)
│   ├── tabla3_ejemplo.txt                      # Datos de prueba: Ejemplo de cálculo (Tabla 3)
│   └── pruebas_borde/                          # Casos de prueba borde y valores límite
├── src/
│   └── Programa1.Estadistica/
│       ├── Dominio/                            # Lógica matemática y lista enlazada propia
│       │   ├── Nodo.cs                         # Estructura del nodo individual
│       │   ├── ListaEnlazada.cs                # Lista dinámica con inserción O(1)
│       │   ├── CalculadoraEstadistica.cs       # Cálculo de media y desviación muestral
│       │   ├── ResultadoEstadistico.cs         # Registro de resultados
│       │   └── DatosInsuficientesException.cs  # Excepción ante cantidad insuficiente
│       ├── Infraestructura/                    # Acceso a archivos y análisis numérico
│       │   ├── LectorArchivoNumeros.cs         # Lector línea por línea con cultura invariante
│       │   └── DatosInvalidosException.cs      # Excepción ante datos corruptos o no numéricos
│       ├── Presentacion/                       # Interfaz con el usuario
│       │   └── ConsolaUI.cs                    # Presentación alineada y captura de ruta
│       ├── Aplicacion.cs                       # Orquestación del flujo y códigos de salida
│       ├── Program.cs                          # Punto de entrada de la consola
│       └── Programa1.Estadistica.csproj        # Configuración de compilación estricta
└── docs/                                       # Documentación formal del proceso PSP0
    ├── flujo_psp0.svg                          # Diagrama del ciclo de vida PSP0
    ├── planeacion/                             # Requisitos funcionales/no funcionales y estimación
    ├── diseno/                                 # Pseudocódigo, traza de escritorio, estándar y diagramas SVG
    ├── pruebas/                                # Casos de prueba CP-01 a CP-18, evidencias e informe
    └── postmortem/                             # Resumen del plan (PPS), conteo LOC y propuesta PIP 1
```

## Requisitos previos

* SDK de **.NET 9.0** o superior instalado en el sistema.
* Terminal de comandos (PowerShell, Bash, zsh o CMD).

## Compilación

El proyecto tiene activada la regla `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`, garantizando una compilación limpia sin advertencias ni errores:

```bash
dotnet build Programa1.sln
```

## Instrucciones de ejecución

El programa admite dos modos de operación:

### 1. Pasando la ruta del archivo como argumento

```bash
dotnet run --project src/Programa1.Estadistica -- datos/columna1_tamano_proxy.txt
```

### 2. Modo interactivo por consola

Si se ejecuta el programa sin argumentos, solicitará la ruta en la terminal:

```bash
dotnet run --project src/Programa1.Estadistica
```

Ejemplo de interacción:
```text
==================================================
 PSP0 · Programa 1 — Media y desviación estándar
==================================================
Ruta del archivo de datos (un número por línea): datos/columna2_horas.txt
Archivo leído : datos/columna2_horas.txt
Datos (n)     : 10
Media         : 60.32
Desv. estándar: 62.26
```

## Resultados de verificación con datos oficiales del Kit

| Archivo de prueba | Cantidad (n) | Media aritmética | Desviación estándar (n - 1) | Estado |
|---|---:|---:|---:|:---:|
| `datos/columna1_tamano_proxy.txt` | 10 | 550.60 | 572.03 | Aprobado |
| `datos/columna2_horas.txt` | 10 | 60.32 | 62.26 | Aprobado |
| `datos/tabla3_ejemplo.txt` | 10 | 638.90 | 625.63 | Aprobado |

## Códigos de salida del sistema

* `0`: El archivo fue procesado con éxito y se generaron los resultados estadísticos.
* `1`: Ocurrió un error en la ruta, el archivo estaba vacío, contenía líneas no numéricas o los datos eran insuficientes para el cálculo. El programa imprime un mensaje descriptivo con el prefijo `ERROR:` sin mostrar trazas de excepción.

## Resumen del proceso PSP0

* **Tiempo planeado:** 300 minutos (5.0 horas).
* **Tiempo real registrado:** 334 minutos (5.56 horas).
* **Error de estimación global:** +11.3 %.
* **Líneas de código nuevo (LOC):** 138 líneas efectivas en producción (sin líneas vacías ni comentarios).
* **Defectos registrados:** 9 defectos detectados y corregidos entre diseño, compilación y pruebas.
* **Propuesta de mejora (PIP 1):** Codificar con el pseudocódigo a la vista y adelantar pruebas manuales por consola desde la primera compilación limpia.
