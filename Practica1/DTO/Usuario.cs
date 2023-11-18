using Practica1.DTO;

namespace Practica1.DTO
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Contrasena { get; set; }
        public string NivelAcceso { get; set; }

    }
}

/*
1.- Creacion de objetos = {DTO,MODEL}
    - DTO
        - Definir los atributos que tendra cada objeto.
        - Definir el constructor de cada objeto.

    - MODEL
        - Definir los atributos que tendra cada objeto.
        - Cambiar DTO Por Model (using namespace proyecto.Model)
    

2.- Configurar BD
    - Insertar 2 librerias
        Microsoft.EntityFrameworkCore
        MySqle.EntityFrameworkCore

    - Insertar 2 carpetas
        Model
        Context

    - Crear una clase de tipo DbContext
        - Listar las tablas que tendra la base (crear tabla)
        - Escribir la configuracion para entrar a la base de datos.
        - Modelar la base de datos (Entity) >.<

3.- Controllers
*/