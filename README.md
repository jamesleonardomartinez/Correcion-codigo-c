# Calculadora Mejorada

## 📋 Descripción

Este proyecto es una calculadora de consola desarrollada en C# que ha sido **refactorizada desde una versión con malas prácticas** hacia código limpio y mantenible. Incluye operaciones matemáticas básicas con validación de errores y un historial de operaciones.

## 🎯 Características

- ✅ Código limpio y legible
- ✅ Manejo apropiado de excepciones
- ✅ Validación de operaciones (división por cero, raíces negativas)
- ✅ Nombres de variables descriptivos
- ✅ Estructura modular y mantenible
- ✅ Historial de operaciones persistente

## 🔧 Funcionalidades

La calculadora ofrece las siguientes operaciones:

1. **Suma** - Suma dos números
2. **Resta** - Resta dos números
3. **Multiplicación** - Multiplica dos números
4. **División** - Divide dos números (con validación de división por cero)
5. **Potencia** - Calcula potencias
6. **Módulo** - Calcula el resto de una división (con validación)
7. **Raíz cuadrada** - Calcula la raíz cuadrada (con validación de negativos)
9. **Historial** - Muestra todas las operaciones realizadas

## 🛠️ Requisitos

- .NET 8.0 o superior
- Sistema operativo: Windows, Linux o macOS

## 📦 Instalación y Ejecución

### Compilar el proyecto:
```bash
dotnet build
```

### Ejecutar la aplicación:
```bash
dotnet run
```

## 💻 Uso

Al ejecutar el programa, aparecerá un menú interactivo:

```
=== CALCULADORA ===
1) Suma  2) Resta  3) Multiplicación  4) División
5) Potencia  6) Módulo  7) Raíz cuadrada  9) Historial  0) Salir
Opción:
```

Seleccione la operación deseada e ingrese los valores cuando se le solicite.

### Ejemplos:

**Suma:**
```
Opción: 1
Primer número: 5
Segundo número: 3

Resultado: 8.0000
```

**Raíz cuadrada:**
```
Opción: 7
Número: 16

Resultado: 4.0000
```

**Ver historial:**
```
Opción: 9

=== HISTORIAL DE OPERACIONES ===
1. 5 + 3 = 8.0000
2. √16 = 4.0000
```

## ✨ Mejoras Implementadas

Este proyecto ha sido refactorizado corrigiendo múltiples problemas:

- ✅ Eliminado `goto`, usando bucle `while` apropiado
- ✅ Clases y variables con nombres descriptivos (`Calculator`, `CalculatorHistory`)
- ✅ Manejo específico de excepciones con mensajes informativos
- ✅ Validación de división y módulo por cero
- ✅ Validación de raíces cuadradas de números negativos
- ✅ Uso de `switch expressions` moderno de C#
- ✅ Eliminado código redundante y operaciones innecesarias
- ✅ Removidos `Thread.Sleep` innecesarios
- ✅ Uso de métodos de biblioteca estándar (`Math.Pow`, `Math.Sqrt`)
- ✅ Código modular con métodos auxiliares claros
- ✅ Actualizado a .NET 8.0 con soporte actual
