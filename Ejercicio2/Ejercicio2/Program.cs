/*Crea un programa que administre un inventario de productos.
Cada producto tiene un nombre, un precio y una cantidad en
stock. El programa debe permitir:
✓ Añadir nuevos productos al inventario.
✓ Actualizar la cantidad en stock de un producto
existente.
✓ Calcular el valor total del inventario (sumando el valor
de cada producto: precio × cantidad en stock).
Requisitos:
✓ Implementar la función agregar_producto (inventario,
nombre, precio, cantidad) para añadir productos.
✓ Implementar la función actualizar_stock (inventario,
nombre, nueva_cantidad) para modificar la cantidad de
un producto.
✓ Implementar la función calcular_valor_total (inventario)
que devuelva el valor total del inventario.*/

using System;

public class ControlDeInventario
{
    using System;


            

class Inventario
{
    private Producto[] productos;
    private int contador;

    public Inventario(int tamaño)
    {
        productos = new Producto[tamaño];
        contador = 0;
    }

    // Función para añadir productos interactivamente
    public void AgregarProducto(string nombre, double precio, int cantidad)
    {
        if (contador < productos.Length)
        {
            productos[contador] = new Producto(nombre, precio, cantidad);
            contador++;
            Console.WriteLine($"Producto '{nombre}' añadido al inventario.\n");
        }
        else
        {
            Console.WriteLine("No se pueden añadir más productos, inventario lleno.\n");
        }
    }

    // Función para actualizar el stock de un producto
    public void ActualizarStock(string nombre, int nuevaCantidad)
    {
        for (int i = 0; i < contador; i++)
        {
            if (productos[i].Nombre == nombre)
            {
                productos[i].Cantidad = nuevaCantidad;
                Console.WriteLine($"Stock de '{nombre}' actualizado a {nuevaCantidad} unidades.\n");
                return;
            }
        }
        Console.WriteLine($"Producto '{nombre}' no encontrado.\n");
    }

    // Función para calcular el valor total del inventario
    public double CalcularValorTotal()
    {
        double valorTotal = 0;
        for (int i = 0; i < contador; i++)
        {
            valorTotal += productos[i].Precio * productos[i].Cantidad;
        }
        return valorTotal;
    }

    // Función para mostrar el inventario actual
    public void MostrarInventario()
    {
        Console.WriteLine("\nInventario Actual:");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"Producto: {productos[i].Nombre}, Precio: {productos[i].Precio}, Cantidad: {productos[i].Cantidad}");
        }
    }
}

