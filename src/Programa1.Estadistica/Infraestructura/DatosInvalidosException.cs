namespace Programa1.Estadistica.Infraestructura;

/// <summary>
/// Excepción arrojada cuando el archivo no existe, está vacío o contiene valores que no corresponden a números reales.
/// </summary>
public sealed class DatosInvalidosException : Exception
{
    public DatosInvalidosException(string mensaje, int? linea = null)
        : base(mensaje) => Linea = linea;

    public int? Linea { get; }
}
