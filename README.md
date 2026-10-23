# Práctica Unidad II · Colas

Estructura de Datos — DSM 4A-4D. Aplicación de escritorio en **C# / Windows Forms (.NET 8)** con un menú que abre los tres ejercicios de la práctica de colas.

## Cómo ejecutarlo

- **Visual Studio 2022**: abrir `PracticaColas.sln` y presionar F5.
- **Consola**: `dotnet run --project PracticaColas`

## Ejercicios

| # | Ejercicio | Estructura usada |
|---|-----------|------------------|
| 1 | Ventanilla de un banco | `ColaBanco`: cola circular sobre un arreglo (capacidad 10) con `InsertaCola`, `EliminaCola`, `ColaLlena`, `ColaVacia`, frente y final |
| 2 | Juego: pintar coches | `Cola<T>`: cola dinámica con nodos ligados |
| 3 | Estacionamiento para autos | `ColaCircularDobleAutos`: cola circular doblemente ligada; cada `Auto` es un nodo |

### 1. Ventanilla de un banco
- Captura el nombre del cliente y el tipo de movimiento (comboBox); el turno y la hora de llegada se asignan solos.
- **Formar en la cola** valida los datos y el sobreflujo (`ColaLlena()`), actualiza la tabla y muestra una ventana con los datos del cliente.
- **Atender en ventanilla** valida el subflujo (`ColaVacia()`), saca al primer cliente y calcula su tiempo de espera con la hora del sistema.
- Después de cada operación se actualiza la tabla y se muestran el **frente** y el **final**.

### 2. Juego: pintar coches
- Llega un coche cada 20 s; cada 3 coches pintados el intervalo baja 3 s (mínimo 5 s).
- Se elige un color de la paleta y se hace clic en el **primer** coche; si se intenta pintar otro, el juego avisa que hay que respetar la cola.
- El color que pide cada coche se genera al azar.
- El juego termina cuando hay 5 coches enfilados y muestra coches pintados, tiempo total y récord (que se guarda entre partidas).

### 3. Estacionamiento para autos
- Menú: **1. Entrada de Auto** y **2. Salida de Autos**.
- Entrada: captura placas y propietario, toma la hora con `DateTime.Now`, inserta en la cola y confirma con un mensaje.
- Salida: valida que no esté vacío, muestra placas, propietario, hora de entrada, hora de salida y el costo ($2.00 por segundo).
- La tabla puede recorrerse del frente al final o al revés (enlaces `Anterior`).

## Organización

```
PracticaColas/
├── Estructuras/   ColaBanco, Cola<T>, ColaCircularDobleAutos
├── Modelos/       Cliente, Coche, Auto
├── Utilidades/    Validaciones, Tema (estilos), Dibujos (imágenes con GDI+)
└── Formularios/   frmMenu, frmBanco, frmPintarCoches, frmEstacionamiento
```
