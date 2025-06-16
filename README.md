## 📝 Documentación del Proyecto: Prueba Técnica Carsales

### 📦 Requisitos Previos

#### Backend (.NET 8)
- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (opcional) o cualquier editor compatible

#### Frontend (Angular)
- [Node.js (v18 o superior)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli): instalar con `npm install -g @angular/cli`


### 🧬 1. Clonar el repositorio

Asegúrate de tener Git instalado. Si no lo tenés, podés descargarlo desde [git-scm.com](https://git-scm.com/).

Luego, ejecutá en la terminal:

```bash
git clone https://github.com/jespinozar89/PruebaTecnicaCarsales.git
```

Esto creará una carpeta llamada `PruebaTecnicaCarsales` con todo el contenido del proyecto.

## 🚀 Instrucciones para Ejecutar el Proyecto

### 🔧 Backend (.NET)

1. Navegar al directorio del backend:
   ```bash
   cd PruebaTecnicaCarsales/Backend
   ```

2. Restaurar y compilar el proyecto:
   ```bash
   dotnet restore
   dotnet build
   ```

3. Ejecutar la API:
   ```bash
   dotnet run
   ```

4. La API estará disponible en:  
   `http://localhost:5075/api/Character`

---

### 🌐 Frontend (Angular)

1. Navegar al directorio del frontend:
   ```bash
   cd PruebaTecnicaCarsales/Frontend
   ```

2. Instalar dependencias:
   ```bash
   npm install
   ```

3. Ejecutar la aplicación:
   ```bash
   ng serve
   ```

4. Acceder desde el navegador:  
   `http://localhost:4200`

---

## 🧪 Funcionalidades Clave

- **Página principal** (`/`): Bienvenida al sistema
- **Listado de personajes** (`/characters`): Tabla paginada con buscador y botones de detalle
- **Detalle de personaje** (`/characters/:id`): Vista con datos completos del personaje
- **Búsqueda de personajes**: Campo de búsqueda reactivo con filtro por nombre
- **Paginación**: Navegación por página de resultados
- **Diseño limpio y minimalista** sin frameworks

---

## 🧱 Estructura Relevante

```bash
Frontend/
  ├── features/
  │   ├── characters/
  │   │   ├── character-list/
  │   │   ├── detail-character/
  │   │   ├── models/
  │   │   └── services/
  │   └── home/
  ├── layout/
  └── app.routes.ts

Backend/
  └── Controllers/
      └── CharacterController.cs
```

---

## 🌍 Variables de entorno

La URL de la API está centralizada en el archivo:  
```ts
src/environments/environment.ts
```

Ejemplo:

```ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5075/api/Character',
  logoPath: 'logo.png'
};
```
