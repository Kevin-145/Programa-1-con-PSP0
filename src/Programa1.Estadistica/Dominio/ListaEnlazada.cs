using System.Collections;

namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Estructura lineal de nodos enlazados que almacena valores numéricos reales.
/// </summary>
public sealed class ListaEnlazada : IEnumerable<double>
{
    private Nodo? _primero;
    private Nodo? _ultimo;

    public int Cantidad { get; private set; }

    public bool EstaVacia => Cantidad == 0;

    /// <summary>
    /// Inserta un nuevo valor al final de la estructura en tiempo constante.
    /// </summary>
    public void Agregar(double valor)
    {
        var nuevo = new Nodo(valor);
        if (_ultimo is null)
        {
            _primero = nuevo;
        }
        else
        {
            _ultimo.Siguiente = nuevo;
        }

        _ultimo = nuevo;
        Cantidad++;
    }

    public IEnumerator<double> GetEnumerator()
    {
        for (var actual = _primero; actual is not null; actual = actual.Siguiente)
        {
            yield return actual.Valor;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
