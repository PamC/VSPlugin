﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace VSNDK.Tasks.BarDescriptor {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.qnx.com/schemas/application/1.0", IsNullable=true)]
    public partial class asset {
        
        private string pathField;
        
        private string entryField;
        
        private string typeField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string entry {
            get {
                return this.entryField;
            }
            set {
                this.entryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.qnx.com/schemas/application/1.0", IsNullable=false)]
    public partial class qnx {
        
        private string idField;
        
        private string nameField;
        
        private string versionNumberField;
        
        private string buildIdField;
        
        private string descriptionField;
        
        private string authorField;
        
        private string categoryField;
        
        private qnxInitialWindow[] initialWindowField;
        
        private asset[] assetField;
        
        private qnxConfiguration[] configurationField;
        
        private qnxIcon[] iconField;
        
        private qnxAction[] actionField;
        
        private qnxEnv[] envField;
        
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string versionNumber {
            get {
                return this.versionNumberField;
            }
            set {
                this.versionNumberField = value;
            }
        }
        
        /// <remarks/>
        public string buildId {
            get {
                return this.buildIdField;
            }
            set {
                this.buildIdField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        public string category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("initialWindow")]
        public qnxInitialWindow[] initialWindows {
            get {
                return this.initialWindowField;
            }
            set {
                this.initialWindowField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("asset", IsNullable=true)]
        public asset[] assets {
            get {
                return this.assetField;
            }
            set {
                this.assetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("configuration")]
        public qnxConfiguration[] configurations {
            get {
                return this.configurationField;
            }
            set {
                this.configurationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("icon")]
        public qnxIcon[] icons {
            get {
                return this.iconField;
            }
            set {
                this.iconField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("action", IsNullable=true)]
        public qnxAction[] actions {
            get {
                return this.actionField;
            }
            set {
                this.actionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("env")]
        public qnxEnv[] envs {
            get {
                return this.envField;
            }
            set {
                this.envField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    public partial class qnxInitialWindow {
        
        private string aspectRatioField;
        
        private string autoOrientsField;
        
        private string systemChromeField;
        
        private string transparentField;
        
        /// <remarks/>
        public string aspectRatio {
            get {
                return this.aspectRatioField;
            }
            set {
                this.aspectRatioField = value;
            }
        }
        
        /// <remarks/>
        public string autoOrients {
            get {
                return this.autoOrientsField;
            }
            set {
                this.autoOrientsField = value;
            }
        }
        
        /// <remarks/>
        public string systemChrome {
            get {
                return this.systemChromeField;
            }
            set {
                this.systemChromeField = value;
            }
        }
        
        /// <remarks/>
        public string transparent {
            get {
                return this.transparentField;
            }
            set {
                this.transparentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    public partial class qnxConfiguration {
        
        private string platformArchitectureField;
        
        private asset[] assetField;
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string platformArchitecture {
            get {
                return this.platformArchitectureField;
            }
            set {
                this.platformArchitectureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("asset", IsNullable=true)]
        public asset[] asset {
            get {
                return this.assetField;
            }
            set {
                this.assetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    public partial class qnxIcon {
        
        private string imageField;
        
        /// <remarks/>
        public string image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    public partial class qnxAction {
        
        private string systemField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string system {
            get {
                return this.systemField;
            }
            set {
                this.systemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.qnx.com/schemas/application/1.0")]
    public partial class qnxEnv {
        
        private string varField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string var {
            get {
                return this.varField;
            }
            set {
                this.varField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}
