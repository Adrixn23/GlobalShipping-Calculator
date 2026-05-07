# 🌐 GlobalShipping-Calculator v1.0
### Sistema de Cálculo de Tarifas Internacionales - Arquitectura SOLID Premium

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512bd4.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_N--Layer-blue.svg)](#arquitectura-y-diseño)
[![SOLID](https://img.shields.io/badge/SOLID-Strict_Compliance-success.svg)](#principios-solid-aplicados)

**GlobalShipping-Calculator** es una solución empresarial diseñada para el cálculo automatizado de tarifas de envío internacional. El sistema ha sido construido bajo estándares rigurosos de ingeniería de software, priorizando la escalabilidad, el desacoplamiento y la integridad de los datos de negocio.

---

## Capturas de Pantalla
Interfaz **Premium Dark Minimalist** implementada con iconos SVG nativos para garantizar rendimiento y compatibilidad.

| Formulario de Cotización | Resultado de Cálculo |
| :---: | :---: |
| ![Inicio](./docs/img/screenshot_inicio.jpeg) | ![Resultado](./docs/img/screenshot_resultado.jpeg) |

---

## Características Principales
*   **Motor de Cálculo Extensible:** Implementación del **Patrón Strategy** para añadir nuevas regiones sin modificar el código base (**Open/Closed Principle**).
*   **Validación de Carga (Anti-Tontos):** Control estricto de límites de peso (`MaxWeight`) por país, configurable desde la base de datos.
*   **Persistencia Profesional:** Uso de **Entity Framework Core (Code First)** con migraciones automáticas y SQL Server.
*   **UI/UX de Alta Gama:** Diseño minimalista centrado en la usabilidad, libre de dependencias externas de iconos (SVG nativos).

---

## 🧠 Arquitectura y Diseño (DAS)
El sistema sigue una **Arquitectura en Capas (N-Layer)** física y lógicamente separada en proyectos independientes para garantizar la separación de intereses (Separation of Concerns).

1.  **GlobalShipping.Core:** El corazón del negocio. Entidades e Interfaces puras (Sin dependencias).
2.  **GlobalShipping.Services:** Implementación de la lógica y estrategias de cálculo.
3.  **GlobalShipping.Infrastructure:** Acceso a datos y persistencia (EF Core).
4.  **GlobalShipping-Calculator:** Capa de presentación (ASP.NET Core MVC 9.0).



## Principios SOLID Aplicados
Esta solución es un caso de estudio sobre el cumplimiento estricto de los principios **SOLID**:

*   **S (Single Responsibility):** Cada estrategia de cálculo tiene una única responsabilidad: gestionar su propia región y fórmula.
*   **O (Open/Closed):** El sistema está cerrado a modificaciones pero abierto a extensiones a través de la inyección de múltiples implementaciones de `IShippingStrategy`.
*   **L (Liskov Substitution):** Todas las estrategias son intercambiables y respetan el contrato de la interfaz sin efectos secundarios negativos.
*   **I (Interface Segregation):** Interfaces pequeñas y cohesivas para evitar que los clientes dependan de métodos que no utilizan.
*   **D (Dependency Inversion):** El alto nivel (Web/Services) no depende del bajo nivel (Infraestructura), ambos dependen de abstracciones (Core).

---

## Reglas de Negocio Vigentes
| Destino | Código | Tarifa (USD/Kg) | Límite de Peso |
| :--- | :---: | :---: | :---: |
| **India** | IN | $5.00 | 50 Kg |
| **Estados Unidos** | US | $8.00 | 100 Kg |
| **Reino Unido** | UK | $10.00 | 70 Kg |

---

## 🔧 Instalación y Despliegue

### Prerrequisitos
*   .NET 9.0 SDK
*   SQL Server LocalDB (v15.0+)

### Pasos de Configuración
1.  Clonar el repositorio.
2.  Configurar la cadena de conexión en `appsettings.json`.
3.  Ejecutar las migraciones de base de datos:
    ```bash
    dotnet ef database update --project GlobalShipping.Infrastructure --startup-project GlobalShipping-Calculator
    ```
4.  Iniciar la aplicación:
    ```bash
    dotnet run --project GlobalShipping-Calculator
    ```

---

## 🎓 Autor
*   **Adrian Francisco Brito Nelkitts** - *Desarrollo de Software / Arquitectura*

