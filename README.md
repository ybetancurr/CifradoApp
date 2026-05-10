# Informe de Pruebas de Funcionalidad — CifradoApp

## 1. Introducción

El presente informe documenta el desarrollo y las pruebas de funcionalidad de **CifradoApp**, una aplicación de escritorio construida con **C#, WPF y .NET 7.0**, cuyo propósito es cifrar y descifrar números enteros de 6 dígitos mediante un algoritmo de sustitución y transposición.

El objetivo de la actividad es aplicar buenas prácticas de programación en el desarrollo de aplicaciones con interfaz gráfica, organizando el código de manera modular mediante la separación en capas: lógica de negocio (`Core`), utilitarios (`Helpers`) y presentación (`Forms`).

---

## 2. Desarrollo

### 2.1 Arquitectura del proyecto

El proyecto sigue una arquitectura de tres capas con separación de responsabilidades:

```
CifradoApp/
├── CifradoApp.sln
└── CifradoApp/
    ├── Program.cs
    ├── Core/
    │   └── CifradoService.cs
    ├── Helpers/
    │   └── InputValidator.cs
    └── Forms/
        ├── MainWindow.xaml / .cs
        ├── HomeView.xaml / .cs
        ├── EncryptForm.xaml / .cs
        └── DecryptForm.xaml / .cs
```

- **`CifradoService`** — contiene el algoritmo de cifrado y descifrado. No tiene dependencias de UI.
- **`InputValidator`** — centraliza la validación de entradas del usuario.
- **`MainWindow`** — ventana principal con sidebar de navegación y contenedor dinámico.
- **`HomeView`** — vista de bienvenida con información del autor y accesos directos.
- **`EncryptForm`** — vista de cifrado de números.
- **`DecryptForm`** — vista de descifrado de números.


### 2.2 Algoritmo de cifrado

El algoritmo opera en dos pasos sobre los dígitos individuales del número ingresado:

**Paso 1 — Sustitución:** a cada dígito se le suma 7 y se obtiene el residuo de la división entre 10.

```
dígito_cifrado = (dígito + 7) % 10
```

**Paso 2 — Transposición:** se intercambian las posiciones de los dígitos según el siguiente esquema:

```
[0] ↔ [2]
[1] ↔ [3]
[4] ↔ [5]
```

---

### 2.3 Algoritmo de descifrado

El descifrado revierte el proceso en orden inverso:

**Paso 1 — Revertir transposición:** se aplican los mismos intercambios en orden inverso:

```
[4] ↔ [5]
[1] ↔ [3]
[0] ↔ [2]
```

**Paso 2 — Revertir sustitución:** a cada dígito se le resta 7 con módulo 10, usando `+10` para evitar valores negativos:

```
dígito_original = (dígito - 7 + 10) % 10
```

---

### 2.4 Descripción de las ventanas

**MainWindow** — ventana principal con sidebar oscuro (`#1A1A2E`) que contiene la navegación (Inicio, Cifrar, Descifrar, Salir) y un área de contenido dinámico donde se cargan las vistas sin abrir ventanas adicionales.

**HomeView** — vista de bienvenida que muestra información del autor y dos tarjetas de acceso rápido a las funciones de cifrado y descifrado.

**EncryptForm** — vista de cifrado. El usuario ingresa un número de 6 dígitos, presiona "Cifrar" y obtiene el resultado en una tarjeta con acento visual púrpura. Incluye validación de entrada y botón "Limpiar".

**DecryptForm** — vista de descifrado. Misma estructura que `EncryptForm` pero invierte el proceso, con acento visual verde para diferenciar visualmente ambas operaciones.

---

## 3. Pruebas de funcionalidad

### Caso de prueba 1 — Número: `123456`

**Cifrado paso a paso:**

```
Entrada:          1  2  3  4  5  6
+7 mod 10:        8  9  0  1  2  3
Swap [0]↔[2]:     0  9  8  1  2  3
Swap [1]↔[3]:     0  1  8  9  2  3
Swap [4]↔[5]:     0  1  8  9  3  2
Resultado:        018932
```

**Descifrado paso a paso:**

```
Entrada:          0  1  8  9  3  2
Swap [4]↔[5]:     0  1  8  9  2  3
Swap [1]↔[3]:     0  9  8  1  2  3
Swap [0]↔[2]:     8  9  0  1  2  3
-7 mod 10:        1  2  3  4  5  6
Resultado:        123456  ✓
```

| Operación | Entrada | Resultado |
|-----------|---------|-----------|
| Cifrado   | 123456  | 018932    |
| Descifrado| 018932  | 123456 ✓  |

---

### Caso de prueba 2 — Número: `791658`

**Cifrado paso a paso:**

```
Entrada:          7  9  1  6  5  8
+7 mod 10:        4  6  8  3  2  5
Swap [0]↔[2]:     8  6  4  3  2  5
Swap [1]↔[3]:     8  3  4  6  2  5
Swap [4]↔[5]:     8  3  4  6  5  2
Resultado:        834652
```

**Descifrado paso a paso:**

```
Entrada:          8  3  4  6  5  2
Swap [4]↔[5]:     8  3  4  6  2  5
Swap [1]↔[3]:     8  6  4  3  2  5
Swap [0]↔[2]:     4  6  8  3  2  5
-7 mod 10:        7  9  1  6  5  8
Resultado:        791658  ✓
```

| Operación | Entrada | Resultado |
|-----------|---------|-----------|
| Cifrado   | 791658  | 834652    |
| Descifrado| 834652  | 791658 ✓  |

---

## 4. Conclusión

El desarrollo de CifradoApp permitió aplicar de manera práctica los fundamentos de la programación orientada a objetos y el diseño de interfaces gráficas en .NET. La separación del proyecto en capas (`Core`, `Helpers`, `Forms`) facilitó la organización del código, favoreciendo la reutilización y el mantenimiento: el algoritmo de cifrado puede modificarse sin tocar la interfaz, y la interfaz puede rediseñarse sin afectar la lógica.

La implementación del algoritmo de sustitución y transposición demostró que operaciones aparentemente simples requieren un análisis cuidadoso del orden de las operaciones, especialmente en el proceso inverso de descifrado, donde el orden de los intercambios debe revertirse exactamente para recuperar el número original.

Finalmente, el uso de WPF permitió construir una interfaz moderna y estructurada mediante la separación entre diseño (XAML) y lógica (code-behind), un patrón que sienta las bases para arquitecturas más avanzadas como MVVM.
