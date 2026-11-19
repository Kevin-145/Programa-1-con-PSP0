using System.Globalization;
using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Presentacion;

/// <summary>
/// Gestiona la presentación visual en consola y la interacción con el usuario.
/// </summary>
public sealed class ConsolaUI
{
    private const string Formato = "F2";
    private readonly TextReader _entrada;
    private readonly TextWriter _salida;

    public ConsolaUI(TextReader entrada, TextWriter salida)
    {
        _entrada = entrada ?? throw new ArgumentNullException(nameof(entrada));
        _salida = salida ?? throw new ArgumentNullException(nameof(salida));
    }

    public void MostrarEncabezado()
    {
        _salida.WriteLine("==================================================");
        _salida.WriteLine(" PSP0 · Programa 1 — Media y desviación estándar");
        _salida.WriteLine("==================================================");
    }

    public string PedirRuta()
    {
        _salida.Write("Ruta del archivo de datos (un número por línea): ");
        return _entrada.ReadLine()?.Trim() ?? string.Empty;
    }

    public void MostrarResultado(string ruta, ResultadoEstadistico resultado)
    {
        ArgumentNullException.ThrowIfNull(resultado);
        _salida.WriteLine($"Archivo leído : {ruta}");
        _salida.WriteLine($"Datos (n)     : {resultado.Cantidad}");
        _salida.WriteLine($"Media         : {Formatear(resultado.Media)}");
        _salida.WriteLine(resultado.DesviacionEstandar is { } desviacion
            ? $"Desv. estándar: {Formatear(desviacion)}"
            : $"Desv. estándar: no definida (se necesitan al menos {CalculadoraEstadistica.MinimoParaDesviacion} datos)");
    }

    public void MostrarError(string mensaje) => _salida.WriteLine($"ERROR: {mensaje}");

    private static string Formatear(double valor) => valor.ToString(Formato, CultureInfo.InvariantCulture);
}
