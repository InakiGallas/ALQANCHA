# ⚽ ALQANCHA - Sistema de Reservas de Canchas

**ALQANCHA** es una aplicación web desarrollada con **ASP.NET Core MVC** y **Entity Framework Core**. Permite gestionar reservas de canchas de fútbol, jugadores disponibles, sanciones y más.

Incluye:
- CRUD completo de reservas, jugadores, canchas y sanciones
- Búsqueda por nombre o fecha
- Incremento automático de precio si se transmite el partido
- Interfaz visual moderna con Bootstrap y carrusel en la home

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
git clone https://github.com/TU_USUARIO/ALQANCHA.git
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

📅 Gestión de horarios disponibles por cancha

🧑‍🤝‍🧑 Asignación de jugadores faltantes automáticamente

📸 Aumento de precio por partido transmitido en streaming

🚫 Asignación de sanciones a jugadores

🔎 Búsqueda rápida de reservas

📱 Acceso directo a contacto por WhatsApp

🎨 Interfaz visual
Carrusel en la página de inicio con imágenes de fútbol

Logo personalizado

Colores adaptados al contexto deportivo

Botones y tablas estilizadas

Footer automático y adaptable




🧑‍💻 Autor
💻 Desarrollado por: [Iñaki Galalstegui]

✉️ Contacto: [inaki.gallaste@gmail.com]

⚠️ Licencia
Este proyecto está disponible con fines educativos y personales. Si lo vas a usar en producción, adaptá la lógica a tus necesidades.

⭐ ¡Gracias por visitar el proyecto!
Si te gustó este sistema o querés colaborar, no dudes en dejar una estrella ⭐ en el repo.