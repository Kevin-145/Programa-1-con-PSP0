using System.Globalization;
using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Infraestructura;

/// <summary>
/// Carga y valida números reales almacenados en archivos de texto plano.
/// </summary>
public static class LectorArchivoNumeros
{
    /// <summary>
    /// Lee un archivo en disco y retorna los números reales cargados en una lista enlazada.
    /// </summary>
    public static ListaEnlazada Leer(string ruta)
    {
        if (string.IsNullOrWhiteSpace(ruta))
        {
            throw new DatosInvalidosException("Indique la ruta del archivo de datos.");
        }

        if (!File.Exists(ruta))
        {
            throw new DatosInvalidosException($"No se encontró el archivo «{ruta}». Revise la ruta.");
        }

        return LeerLineas(File.ReadLines(ruta));
    }

    /// <summary>
    /// Procesa una secuencia de líneas de texto omitiendo líneas en blanco y validando cada número.
    /// </summary>
    public static ListaEnlazada LeerLineas(IEnumerable<string> lineas)
    {
        ArgumentNullException.ThrowIfNull(lineas);
        var lista = new ListaEnlazada();
        var numeroLinea = 0;

        foreach (var linea in lineas)
        {
            numeroLinea++;
            var texto = linea.Trim();
            if (texto.Length > 0)
            {
                lista.Agregar(Convertir(texto, numeroLinea));
            }
        }

        if (lista.EstaVacia)
        {
            throw new DatosInvalidosException("El archivo no contiene datos. Escriba un número por línea.");
        }

        return lista;
    }

    // Se emplea CultureInfo.InvariantCulture para procesar siempre el punto decimal, independientemente de la cultura del SO (ej. es-CO)
    private static double Convertir(string texto, int numeroLinea)
    {
        if (double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out var valor)
            && double.IsFinite(valor))
        {
            return valor;
        }

        throw new DatosInvalidosException(
            $"Línea {numeroLinea}: «{texto}» no es un número real. Use punto decimal (ej. 15.0).", numeroLinea);
    }
}
