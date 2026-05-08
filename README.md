# CifradoApp
Aplicación de escritorio desarrollada en **C# con WinForms (.NET 7.0)** que permite cifrar y descifrar números enteros de 6 dígitos, aplicando un algoritmo de sustitución y transposición de dígitos.

---

## Arquitectura: 3 Capas + Separación de Responsabilidades
```css
CifradoApp/
│
├── CifradoApp.sln
│
└── CifradoApp/                        ← Proyecto WinForms
    │
    ├── Program.cs                    ← Entry point
    │
    ├── Core/                         ← Lógica de negocio (pura, sin UI)
    │   └── CifradoService.cs         ← Cifrado y descifrado
    │
    ├── Helpers/                      ← Utilitarios
    │   └── InputValidator.cs         ← Validación de entradas
    │
    └── Forms/                        ← Capa de presentación
        ├── MainForm.cs               ← Ventana principal (info autor)
        ├── EncryptForm.cs            ← Ventana de cifrado
        └── DecryptForm.cs            ← Ventana de descifrado
```

---

## Algoritmo documentado

### Cifrado — Ejemplo con `123456`
```
Entrada:          1  2  3  4  5  6
+7 mod 10:        8  9  0  1  2  3
Swap [0]↔[2]:     0  9  8  1  2  3
Swap [1]↔[3]:     0  1  8  9  2  3
Swap [4]↔[5]:     0  1  8  9  3  2
Salida cifrada:   018932
```

### Descifrado — Revertir `018932`
```
Entrada:          0  1  8  9  3  2
Swap [4]↔[5]:     0  1  8  9  2  3
Swap [1]↔[3]:     0  9  8  1  2  3
Swap [0]↔[2]:     8  9  0  1  2  3
-7 mod 10:        1  2  3  4  5  6
Salida original:  123456  ✓
```

### Cifrado — Ejemplo con `791658`
```
Entrada:          7  9  1  6  5  8
+7 mod 10:        4  6  8  3  2  5
Swap [0]↔[2]:     8  6  4  3  2  5
Swap [1]↔[3]:     8  3  4  6  2  5
Swap [4]↔[5]:     8  3  4  6  5  2
Salida cifrada:   834652
```

### Descifrado — Revertir `834652`
```
Entrada:          8  3  4  6  5  2
Swap [4]↔[5]:     8  3  4  6  2  5
Swap [1]↔[3]:     8  6  4  3  2  5
Swap [0]↔[2]:     4  6  8  3  2  5
-7 mod 10:        7  9  1  6  5  8
Salida original:  791658  ✓
```

---

## Casos de prueba

| # | Entrada | Cifrado | Descifrado | Válido |
|---|---------|---------|------------|--------|
| 1 | 123456  | 018932  | 123456     | ✅     |
| 2 | 791658  | 834652  | 791658     | ✅     |

---

## Requisitos

- Windows 10 / 11
- [.NET 7.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Visual Studio 2022 (para desarrollo)

---

## Cómo ejecutar

```bash
# Clonar o descomprimir el proyecto
cd CifradoApp

# Restaurar dependencias
dotnet restore

# Compilar
dotnet build

# Ejecutar
dotnet run --project CifradoApp/CifradoApp.csproj
```

---

## Reglas de validación

- La entrada debe contener **exactamente 6 dígitos**.
- Solo se aceptan **caracteres numéricos** (0–9).
- No se permiten espacios, letras ni caracteres especiales.

---

## Tecnologías utilizadas

| Tecnología | Versión | Uso |
|---|---|---|
| C# | 11 | Lenguaje principal |
| .NET | 7.0 | Framework de ejecución |
| WinForms | 7.0 | Interfaz gráfica de usuario |

---

## Licencia
Proyecto académico Aplicaciones I - Maestría en IA (Profundización) 20261 — uso educativo.
