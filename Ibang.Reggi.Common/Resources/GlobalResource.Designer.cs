﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ibang.Reggi.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GlobalResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GlobalResource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ibang.Reggi.Common.Resources.GlobalResource", typeof(GlobalResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Fecha de registro de tiempo.
        /// </summary>
        public static string DateHour {
            get {
                return ResourceManager.GetString("DateHour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Descripción.
        /// </summary>
        public static string Description {
            get {
                return ResourceManager.GetString("Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Horas.
        /// </summary>
        public static string Hour {
            get {
                return ResourceManager.GetString("Hour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Identificador de una actividad.
        /// </summary>
        public static string IdActivity {
            get {
                return ResourceManager.GetString("IdActivity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Identificador del usuario.
        /// </summary>
        public static string IdUser {
            get {
                return ResourceManager.GetString("IdUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Solo se permiten números y caracteres.
        /// </summary>
        public static string OnlyNumbersAndLetters {
            get {
                return ResourceManager.GetString("OnlyNumbersAndLetters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo {0} es requerido.
        /// </summary>
        public static string RequiredField {
            get {
                return ResourceManager.GetString("RequiredField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo {0} debe ser de máximo {1} caracteres.
        /// </summary>
        public static string StringLenghtField {
            get {
                return ResourceManager.GetString("StringLenghtField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Reggi.
        /// </summary>
        public static string SwaggerTitle {
            get {
                return ResourceManager.GetString("SwaggerTitle", resourceCulture);
            }
        }
    }
}