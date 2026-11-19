# Diseño: Pseudocódigo del Programa 1

El pseudocódigo define la lógica de cada componente antes de escribir el código fuente. Se estructura en lenguaje natural estructurado, donde la indentación delimita los bloques de control.

## 1. Orquestación del flujo (Aplicacion.Ejecutar)

```text
INICIO Metodo Ejecutar(args, entrada, salida): entero
    ui <- nueva ConsolaUI(entrada, salida)
    ui.MostrarEncabezado()

    SI longitud(args) > 0 ENTONCES
        ruta <- args[0]
    SINO
        ruta <- ui.PedirRuta()
    FIN SI

    INTENTAR
        datos <- LectorArchivoNumeros.Leer(ruta)
        resultado <- CalculadoraEstadistica.Calcular(datos)
        ui.MostrarResultado(ruta, resultado)
        RETORNAR 0
    CAPTURAR DatosInvalidosException o DatosInsuficientesException COMO ex
        ui.MostrarError(ex.Mensaje)
        RETORNAR 1
    FIN INTENTAR
FIN Metodo
```

## 2. Lectura y validación de datos (LectorArchivoNumeros)

```text
INICIO Metodo Leer(ruta): ListaEnlazada
    SI ruta es nula o solo contiene espacios ENTONCES
        LANZAR DatosInvalidosException("Indique la ruta del archivo de datos.")
    FIN SI

    SI NO ExisteArchivo(ruta) ENTONCES
        LANZAR DatosInvalidosException("No se encontró el archivo «" + ruta + "». Revise la ruta.")
    FIN SI

    lineas <- LeerLineasDeArchivo(ruta)
    RETORNAR LeerLineas(lineas)
FIN Metodo

INICIO Metodo LeerLineas(lineas): ListaEnlazada
    lista <- nueva ListaEnlazada()
    numeroLinea <- 0

    PARA CADA linea EN lineas HACER
        numeroLinea <- numeroLinea + 1
        texto <- RecortarEspacios(linea)
        SI longitud(texto) > 0 ENTONCES
            valor <- Convertir(texto, numeroLinea)
            lista.Agregar(valor)
        FIN SI
    FIN PARA

    SI lista.EstaVacia ENTONCES
        LANZAR DatosInvalidosException("El archivo no contiene datos. Escriba un número por línea.")
    FIN SI

    RETORNAR lista
FIN Metodo

INICIO Metodo Convertir(texto, numeroLinea): real
    // Se utiliza cultura invariante para garantizar la interpretación del punto decimal
    SI IntentarConvertirADouble(texto, CulturaInvariante, valor) Y EsFinito(valor) ENTONCES
        RETORNAR valor
    SINO
        LANZAR DatosInvalidosException("Línea " + numeroLinea + ": «" + texto + "» no es un número real. Use punto decimal (ej. 15.0).", numeroLinea)
    FIN SI
FIN Metodo
```

## 3. Estructura de datos enlazada (ListaEnlazada)

```text
CLASE Nodo
    Valor: real
    Siguiente: Nodo (opcional)

    CONSTRUCTOR(valor)
        Valor <- valor
        Siguiente <- nulo
    FIN CONSTRUCTOR
FIN CLASE

CLASE ListaEnlazada
    primero: Nodo (inicialmente nulo)
    ultimo: Nodo (inicialmente nulo)
    Cantidad: entero (inicialmente 0)

    PROPIEDAD EstaVacia: logico
        RETORNAR Cantidad == 0
    FIN PROPIEDAD

    METODO Agregar(valor: real)
        nuevo <- nuevo Nodo(valor)
        SI ultimo es nulo ENTONCES
            primero <- nuevo
        SINO
            ultimo.Siguiente <- nuevo
        FIN SI
        ultimo <- nuevo
        Cantidad <- Cantidad + 1
    FIN METODO

    METODO ObtenerIterador(): Iterador
        actual <- primero
        MIENTRAS actual NO SEA nulo HACER
            ENTREGAR actual.Valor
            actual <- actual.Siguiente
        FIN MIENTRAS
    FIN METODO
FIN CLASE
```

## 4. Cálculo estadístico (CalculadoraEstadistica)

Fórmulas matemáticas aplicadas:
* Media aritmética: x̄ = (Σ x) / n
* Desviación estándar muestral: s = √( (Σ (x - x̄)²) / (n - 1) )

```text
INICIO Metodo Media(datos: ListaEnlazada): real
    SI datos.EstaVacia ENTONCES
        LANZAR DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.")
    FIN SI

    suma <- 0.0
    PARA CADA x EN datos HACER
        suma <- suma + x
    FIN PARA

    RETORNAR suma / datos.Cantidad
FIN Metodo

INICIO Metodo DesviacionEstandar(datos: ListaEnlazada): real
    SI datos.Cantidad < 2 ENTONCES
        LANZAR DatosInsuficientesException("Se necesitan al menos 2 datos para calcular la desviación estándar.")
    FIN SI

    media <- Media(datos)
    sumaCuadrados <- 0.0

    PARA CADA x EN datos HACER
        diferencia <- x - media
        sumaCuadrados <- sumaCuadrados + (diferencia * diferencia)
    FIN PARA

    varianza <- sumaCuadrados / (datos.Cantidad - 1)
    RETORNAR RaizCuadrada(varianza)
FIN Metodo

INICIO Metodo Calcular(datos: ListaEnlazada): ResultadoEstadistico
    media <- Media(datos)
    desviacion <- nulo

    SI datos.Cantidad >= 2 ENTONCES
        desviacion <- DesviacionEstandar(datos)
    FIN SI

    RETORNAR nuevo ResultadoEstadistico(datos.Cantidad, media, desviacion)
FIN Metodo
```

## 5. Traza de escritorio manual con datos de la Tabla 3

Para comprobar el algoritmo de cálculo antes de codificar, se efectúa la traza con los 10 valores de la Tabla 3 del kit:
Valores: 186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601.

| Paso | Operación | Resultado intermedio |
|---|---|---|
| 1 | Cantidad de elementos (n) | 10 |
| 2 | Suma de valores (Σ x) | 6389.00 |
| 3 | Cálculo de la media (6389.00 / 10) | 638.90 |
| 4 | Suma de diferencias al cuadrado Σ (x - 638.90)² | 3522760.90 |
| 5 | División entre (n - 1) = 9 | 391417.88 |
| 6 | Raíz cuadrada de la varianza | 625.63 |

Los cálculos manuales coinciden con los resultados de referencia del kit (638.90 y 625.63), lo que valida el diseño matemático previo a la implementación.
