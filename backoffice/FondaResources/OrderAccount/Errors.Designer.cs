﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FondaResources.OrderAccount {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FondaResources.OrderAccount.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to CommandCloseOrder.
        /// </summary>
        public static string ClassNameCloseOrder {
            get {
                return ResourceManager.GetString("ClassNameCloseOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGenerateInvoice.
        /// </summary>
        public static string ClassNameGenerateInvoice {
            get {
                return ResourceManager.GetString("ClassNameGenerateInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGetCloseOrders.
        /// </summary>
        public static string ClassNameGetCloseOrders {
            get {
                return ResourceManager.GetString("ClassNameGetCloseOrders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGetInvoice.
        /// </summary>
        public static string ClassNameGetInvoice {
            get {
                return ResourceManager.GetString("ClassNameGetInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGetOrder.
        /// </summary>
        public static string ClassNameGetOrder {
            get {
                return ResourceManager.GetString("ClassNameGetOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGetOrders.
        /// </summary>
        public static string ClassNameGetOrders {
            get {
                return ResourceManager.GetString("ClassNameGetOrders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandPayOrder.
        /// </summary>
        public static string ClassNamePayOrder {
            get {
                return ResourceManager.GetString("ClassNamePayOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute.
        /// </summary>
        public static string CommandMethod {
            get {
                return ResourceManager.GetString("CommandMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al crear la factura para una orden cerrada.
        /// </summary>
        public static string ErrorMessageGenerateInvoice {
            get {
                return ResourceManager.GetString("ErrorMessageGenerateInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error obteniendo las ordenes cerradas de un Restaurante.
        /// </summary>
        public static string ErrorMessageGetCloseOrders {
            get {
                return ResourceManager.GetString("ErrorMessageGetCloseOrders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al obtener la factura de una orden cerrada.
        /// </summary>
        public static string ErrorMessageGetInvoice {
            get {
                return ResourceManager.GetString("ErrorMessageGetInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al obtener una orden.
        /// </summary>
        public static string ErrorMessageGetOrder {
            get {
                return ResourceManager.GetString("ErrorMessageGetOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error obteniendo las ordenes de un Restaurante.
        /// </summary>
        public static string ErrorMessageGetOrders {
            get {
                return ResourceManager.GetString("ErrorMessageGetOrders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al pagar una orden abierta en un Restaurante.
        /// </summary>
        public static string ErrorMessagePayOrder {
            get {
                return ResourceManager.GetString("ErrorMessagePayOrder", resourceCulture);
            }
        }
    }
}