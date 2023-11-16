using Practica1.DTO;

namespace Practica1.DTO
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }

        public string Contrasena { get; set; }

        public string NivelAcceso { get; set; }

        public Usuario(string new_NombreUsuario, string new_NombreCompleto, string new_Contrasena, string new_NivelAcceso) {  //parametros necesarios para crear a Usuario
            //Definir el constructur del objeto
            NombreUsuario = new_NombreUsuario;
            NombreCompleto = new_NombreCompleto;
            Contrasena = new_Contrasena;
            NivelAcceso = new_NivelAcceso;
        }
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