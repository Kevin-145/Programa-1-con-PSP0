namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Contenedor inmutable para los resultados estadísticos obtenidos.
/// </summary>
public sealed record ResultadoEstadistico(int Cantidad, double Media, double? DesviacionEstandar);
