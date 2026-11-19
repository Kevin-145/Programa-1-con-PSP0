namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Representa un elemento individual dentro de la lista enlazada simple.
/// </summary>
public sealed class Nodo
{
    public Nodo(double valor) => Valor = valor;

    public double Valor { get; }

    public Nodo? Siguiente { get; internal set; }
}
