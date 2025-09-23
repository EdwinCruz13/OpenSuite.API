# OpenSuite ERP - API REST

**OpenSuite ERP** es una plataforma modular de **gestión empresarial multiempresa**, diseñada para centralizar y automatizar procesos administrativos, financieros y operativos en organizaciones con múltiples filiales o sucursales.

Este repositorio contiene la **API REST** desarrollada en **ASP.NET Core (.NET 9)** que sirve como backend del sistema.

---

## 📌 Descripción del proyecto

El objetivo de **OpenSuite ERP API** es proporcionar un backend robusto, escalable y seguro para soportar las operaciones de un **ERP multiempresa**, facilitando:

- La **gestión de múltiples empresas y sucursales** bajo un mismo sistema.
- La integración con distintos módulos (finanzas, administración, contabilidad, compras, almacén, préstamos, RRHH, bla bla bla).
- Una arquitectura en capas para facilitar mantenimiento, escalabilidad y despliegue en la nube (AWS o entornos locales).

---

## 🏗️ Arquitectura

El sistema sigue una **arquitectura en capas**:

- **OpenSuite.API** → API REST (controladores, middleware, configuración de servicios).
- **Datos** → Capa de acceso a datos (ADO.NET y EF Core).
- **Shared** (en preparación) → Utilidades y componentes reutilizables.
- **Negocio / Aplicación** (a desarrollar) → Contendrá la lógica de negocio y reglas de aplicación.

Además, cuenta con soporte para:

- ** Autenticación y autorización** con JWT.
- ** ADO.NET** para acceso a datos com un proveedor a la bd.
- ** Entity Framework Core** como un proveedor a la bd.
- ** Manejo de variables de entorno** mediante `.env`.

---

## 🚀 Tecnologías

- **.NET 9 (ASP.NET Core Web API)**
- **Entity Framework Core / ADO.NET**
- **SQL Server**
- **ADO.NET**
- **JWT** (autenticación y autorización)
- **Scalar (documentación de la API)
- - **Swagger** (documentación de la API)

---

## ⚙️ Configuración y ejecución

### 1. Clonar repositorio
```bash
git clone https://github.com/tu-usuario/OpenSuite.API.git
cd OpenSuite.API
