# ⚽ ALQANCHA - Sistema de Reservas de Canchas

**ALQANCHA** es una aplicación web desarrollada con **ASP.NET Core MVC** y **Entity Framework Core**. Permite gestionar reservas de canchas de fútbol, jugadores disponibles, sanciones y más.

### 🎯 ¿Qué hace ALQANCHA?

- ✅ **Administradores**: Tienen permisos totales para realizar todos los ABM (Altas, Bajas y Modificaciones).
- ✅ **Jugadores libres**: Se registran con sus horarios disponibles y pueden ser asignados automáticamente a reservas que requieran refuerzos.
- ✅ **Canchas**: Cada cancha tiene horarios, capacidad y precio, con disponibilidad controlada por las reservas.
- ✅ **Reservas**: Se vinculan a canchas y jugadores. El precio se incrementa automáticamente si se elige la opción de transmitir por streaming.
- ✅ **Sanciones**: Se pueden asignar penalizaciones a jugadores por comportamiento o ausencias.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core MVC (.NET 6.0 o superior)
- Entity Framework Core
- SQL Server
- Bootstrap 5
- HTML + CSS personalizado

---

## 🛠️ Requisitos previos

- .NET SDK 6.0 o superior
- SQL Server (local o remoto)
- Visual Studio 2022 o Visual Studio Code

---

## 🧪 Pasos para correr el proyecto

1. **Clonar el repositorio:**

bash

git clone https://github.com/InakiGallas/ALQANCHA.git

cd ALQANCHA

Verificar la cadena de conexión en appsettings.json:


"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=AlqAnchaDb;Trusted_Connection=True;"
}
Cambiala si usás una instancia distinta o autenticación por usuario y contraseña.

Ejecutar las migraciones para crear la base de datos:

Update-Database
Desde la Consola de Administrador de paquetes (en Visual Studio) o con CLI de EF Core si usás VS Code.

Ejecutar la aplicación (F5 o botón ▶️ "Run"):

✨ Funcionalidades principales
✅ Alta, edición y baja de reservas

✅ CRUD de jugadores libres y asignación automática si una reserva requiere refuerzos

✅ ABM completo de canchas

✅ Gestión de sanciones a jugadores

📅 Administración de horarios disponibles

📸 Aumento de precio si el partido es transmitido por streaming

🔍 Búsqueda rápida de reservas

📱 Acceso directo a WhatsApp desde la app

🎨 Interfaz visual
Carrusel en la página de inicio con imágenes de fútbol

Logo personalizado

Paleta de colores deportivos

Botones estilizados y tablas limpias

Footer automático y adaptable al contenido

🧑‍💻 Autor
💻 Desarrollado por: Iñaki Gallastegui

✉️ Contacto: inaki.gallaste@gmail.com

⚠️ Licencia
Este proyecto está disponible con fines educativos y personales.
Si lo vas a usar en producción, adaptá la lógica a tus necesidades.

⭐ ¡Gracias por visitar el proyecto!
Si te gustó este sistema o querés colaborar, no dudes en dejar una estrella ⭐ en el repo.