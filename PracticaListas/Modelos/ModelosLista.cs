using System;
using Practica1_Listas.Estructuras;

namespace Practica1_Listas.Modelos
{
    /// <summary>
    /// Clase Producto utilizada en el Ejercicio 1 (Productos disponibles y retirados).
    /// Contiene un nombre básico (producto1, producto2, ...), cantidad aleatoria y precio decimal aleatorio.
    /// </summary>
    public class ProductoEscaneado
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public ProductoEscaneado(string nombre, int cantidad, decimal precio)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Nombre} (Cantidad: {Cantidad}, Precio: ${Precio:F2})";
        }
    }

    /// <summary>
    /// Clase Alumno utilizada en el Ejercicio 3 (Aprobados y Reprobados).
    /// Almacena el nombre del alumno y su calificación numérica decimal.
    /// </summary>
    public class Alumno
    {
        public string Nombre { get; set; }
        public decimal Calificacion { get; set; }

        public Alumno(string nombre, decimal calificacion)
        {
            Nombre = nombre;
            Calificacion = calificacion;
        }

        public override string ToString()
        {
            return $"{Nombre} (Calificación: {Calificacion:F2})";
        }
    }

    /// <summary>
    /// Clase ProductoCompra utilizada en el Ejercicio 4 (Eliminar y ordenar productos).
    /// Almacena clave del producto, nombre y precio decimal.
    /// </summary>
    public class ProductoCompra
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public ProductoCompra(string clave, string nombre, decimal precio)
        {
            Clave = clave;
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"[Clave: {Clave}] {Nombre} - ${Precio:F2}";
        }
    }

    /// <summary>
    /// Clase GrupoLetra utilizada en el Ejercicio 5 (Listar palabras por letra).
    /// Asocia una letra inicial con su propia lista de palabras que inician con dicha letra.
    /// </summary>
    public class GrupoLetra
    {
        public char LetraInicial { get; set; }
        public ListaEnlazada<string> Palabras { get; set; }

        public GrupoLetra(char letraInicial)
        {
            LetraInicial = char.ToUpperInvariant(letraInicial);
            Palabras = new ListaEnlazada<string>();
        }
    }
}
