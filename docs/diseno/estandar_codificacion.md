# Estándar de codificación en C# (.NET 9)

Este estándar define las reglas de estilo y buenas prácticas técnicas para el desarrollo del Programa 1. Su cumplimiento se verifica durante la revisión de código y en la fase de compilación, donde el proyecto tiene configurado `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`.

## Reglas de desarrollo

| Código | Regla | Ejemplo correcto | Ejemplo incorrecto |
|---|---|---|---|
| E-01 | Nombres de clases, métodos, propiedades y registros en PascalCase, utilizando nombres descriptivos en español. | `CalculadoraEstadistica.Media()` | `calc.m()`, `calculadora_estadistica` |
| E-02 | Variables locales y parámetros en camelCase. | `sumaCuadrados`, `numeroLinea` | `SC`, `suma_cuadrados` |
| E-03 | Campos privados con prefijo de guion bajo y camelCase. | `_primero`, `_ultimo` | `primero`, `m_primero` |
| E-04 | Constantes declaradas explícitamente, evitando números mágicos. | `MinimoParaDesviacion = 2` | `if (n < 2)` |
| E-05 | Un único tipo por archivo; el archivo debe llamarse exactamente igual que el tipo. | `ListaEnlazada.cs` | `Tipos.cs` |
| E-06 | Espacios de nombres con alcance de archivo (file-scoped namespaces). | `namespace Programa1.Estadistica.Dominio;` | bloques con llaves anidadas |
| E-07 | Llaves obligatorias en todas las estructuras de control, con estilo Allman en líneas propias. | `if (condicion) { ... }` | `if (x) return;` |
| E-08 | Métodos de 30 líneas o menos con una única responsabilidad. | Métodos específicos de cálculo y conversión | Métodos monolíticos de 100 líneas |
| E-09 | Comentarios XML `///` únicamente en miembros públicos para documentar su contrato. Comentarios de línea `//` solo para explicar decisiones técnicas no evidentes. | `/// <summary>Calcula la media...` | `// suma 1 al contador` |
| E-10 | Validación preventiva de argumentos nulos en métodos públicos. | `ArgumentNullException.ThrowIfNull(datos);` | omitir validación |
| E-11 | Manejo de situaciones de error esperadas mediante excepciones de dominio e infraestructura. Prohibido capturar `Exception` de forma genérica o silenciosa. | `throw new DatosInvalidosException(...)` | `catch { }` |
| E-12 | Análisis y formato numérico con cultura invariante. | `CultureInfo.InvariantCulture` | `double.Parse(texto)` |
| E-13 | Acumuladores de suma y cálculos estadísticos en tipo `double`. | `double suma = 0.0;` | `int suma = 0;` |
| E-14 | Tipos de referencia anulables habilitados (`<Nullable>enable</Nullable>`), gestionando explícitamente los valores nulos. | `double? DesviacionEstandar` | valores centinela como `-1` |
| E-15 | Cero líneas de código comentado o impresiones de depuración en los commits. | Código limpio | `// Console.WriteLine(temp);` |
| E-16 | La capa de dominio no debe tener referencias a `Console` ni operaciones de entrada/salida de archivos. | `CalculadoraEstadistica` recibe `ListaEnlazada` | leer archivo dentro de la calculadora |

## Convenciones de commits en Git

* Se realiza una confirmación al concluir cada fase del ciclo PSP0 con el prefijo correspondiente: `planeacion:`, `diseno:`, `codigo:`, `compilacion:`, `pruebas:`, `postmortem:`.
* Mensajes escritos en tiempo presente, concisos y descriptivos de los cambios incorporados.
* Exclusión de directorios generados por la compilación (`bin/`, `obj/`, `.vs/`) mediante el archivo `.gitignore`.
