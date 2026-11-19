namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Excepción arrojada cuando el conjunto de datos no cumple con el tamaño mínimo requerido para un cálculo.
/// </summary>
public sealed class DatosInsuficientesException : Exception
{
    public DatosInsuficientesException(string mensaje)
        : base(mensaje)
    {
    }
}
