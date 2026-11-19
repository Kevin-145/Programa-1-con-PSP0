namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Provee métodos para el cálculo de la media y la desviación estándar muestral.
/// </summary>
public static class CalculadoraEstadistica
{
    public const int MinimoParaDesviacion = 2;

    /// <summary>
    /// Calcula el promedio aritmético de los valores almacenados en la lista.
    /// </summary>
    public static double Media(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);
        if (datos.EstaVacia)
        {
            throw new DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.");
        }

        double suma = 0.0;
        foreach (var valor in datos)
        {
            suma += valor;
        }

        return suma / datos.Cantidad;
    }

    /// <summary>
    /// Calcula la desviación estándar muestral dividiendo la suma de diferencias al cuadrado entre n - 1.
    /// </summary>
    public static double DesviacionEstandar(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);
        if (datos.Cantidad < MinimoParaDesviacion)
        {
            throw new DatosInsuficientesException(
                $"Se necesitan al menos {MinimoParaDesviacion} datos para calcular la desviación estándar.");
        }

        var media = Media(datos);
        double sumaCuadrados = 0.0;
        foreach (var valor in datos)
        {
            sumaCuadrados += Math.Pow(valor - media, 2);
        }

        return Math.Sqrt(sumaCuadrados / (datos.Cantidad - 1));
    }

    /// <summary>
    /// Calcula la cantidad de datos, la media y la desviación estándar muestral (si n >= 2).
    /// </summary>
    public static ResultadoEstadistico Calcular(ListaEnlazada datos)
    {
        var media = Media(datos);
        double? desviacion = datos.Cantidad >= MinimoParaDesviacion ? DesviacionEstandar(datos) : null;
        return new ResultadoEstadistico(datos.Cantidad, media, desviacion);
    }
}
