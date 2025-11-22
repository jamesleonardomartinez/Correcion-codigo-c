# Calculadora Mejorada

## 📋 Descripción

Este proyecto es una calculadora de consola desarrollada en C# que ha sido **refactorizada desde una versión con malas prácticas** hacia código limpio y mantenible. Incluye operaciones matemáticas básicas con validación de errores y un historial de operaciones.


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
## ✨ Mejoras Implementadas

Este proyecto ha sido refactorizado corrigiendo múltiples problemas:

- Eliminado `goto`, usando bucle `while` apropiado
- Clases y variables con nombres descriptivos (`Calculator`, `CalculatorHistory`)
- Manejo específico de excepciones con mensajes informativos
- Validación de división y módulo por cero
- Validación de raíces cuadradas de números negativos
- Uso de `switch expressions` moderno de C#
- Eliminado código redundante y operaciones innecesarias
- Removidos `Thread.Sleep` innecesarios
- Uso de métodos de biblioteca estándar (`Math.Pow`, `Math.Sqrt`)
- Código modular con métodos auxiliares claros
- Actualizado a .NET 8.0 con soporte actual
