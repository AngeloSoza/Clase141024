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

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, double precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        // Crear inventario con un tamaño de 5 productos
        Inventario inventario = new Inventario(5);

        // Ciclo para permitir al usuario interactuar con el inventario
        string opcion;
        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Añadir producto");
            Console.WriteLine("2. Actualizar stock");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("4. Calcular valor total del inventario");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Añadir producto
                    Console.Write("\nIngrese el nombre del producto: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese el precio del producto: ");
                    double precio = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Ingrese la cantidad en stock: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());

                    inventario.AgregarProducto(nombre, precio, cantidad);
                    break;

                case "2":
                    // Actualizar stock
                    Console.Write("\nIngrese el nombre del producto a actualizar: ");
                    string nombreActualizar = Console.ReadLine();

                    Console.Write("Ingrese la nueva cantidad: ");
                    int nuevaCantidad = Convert.ToInt32(Console.ReadLine());

                    inventario.ActualizarStock(nombreActualizar, nuevaCantidad);
                    break;

                case "3":
                    // Mostrar inventario
                    inventario.MostrarInventario();
                    break;

                case "4":
                    // Calcular valor total
                    double valorTotal = inventario.CalcularValorTotal();
                    Console.WriteLine($"\nValor total del inventario: {valorTotal}\n");
                    break;

                case "5":
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.\n");
                    break;
            }
        }
        while (opcion != "5");
    }
}
