﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowSynx.Client {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FlowSynx.Client.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested mime type is not valid: {0}.
        /// </summary>
        internal static string MimeTypeMapMimeTypeNotValid {
            get {
                return ResourceManager.GetString("MimeTypeMapMimeTypeNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operation failed: the payload could not be deserialized. See InnerException for details..
        /// </summary>
        internal static string PayloadCouldNotBeDeserialized {
            get {
                return ResourceManager.GetString("PayloadCouldNotBeDeserialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unhandled error when calling the Uri. Message: {0}..
        /// </summary>
        internal static string RequestServiceException {
            get {
                return ResourceManager.GetString("RequestServiceException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error in http request when calling and reaching the Uri..
        /// </summary>
        internal static string RequestServiceHttpRequestExceptionMessage {
            get {
                return ResourceManager.GetString("RequestServiceHttpRequestExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The http request was canceled during call the Uri..
        /// </summary>
        internal static string RequestServiceOperationCanceledException {
            get {
                return ResourceManager.GetString("RequestServiceOperationCanceledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Http request timeout during call the Uri..
        /// </summary>
        internal static string RequestServiceTimeoutException {
            get {
                return ResourceManager.GetString("RequestServiceTimeoutException", resourceCulture);
            }
        }
    }
}
