﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
namespace Cn.Youdundianzi.App {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class AppConfig {

        static public readonly string APPCONF_FILE_NAME = "APP_CONFIG.config";

        private Introduction introField = new Introduction();

        private Exams examsField = new Exams();

        private Practices practicesField = new Practices();

        private Options optionsField = new Options();

        private string mainTitleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Introduction Intro {
            get {
                return this.introField;
            }
            set {
                this.introField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Exams Exams {
            get {
                return this.examsField;
            }
            set {
                this.examsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Practices Practices {
            get {
                return this.practicesField;
            }
            set {
                this.practicesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Options Options {
            get {
                return this.optionsField;
            }
            set {
                this.optionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MainTitle {
            get {
                return this.mainTitleField;
            }
            set {
                this.mainTitleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Introduction {

        private string introFilePathField = string.Empty;

        private string titleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IntroFilePath {
            get {
                return this.introFilePathField;
            }
            set {
                this.introFilePathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UsrCtrlInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class ClsInfo {

        private string clsNameField = string.Empty;

        private string clsFilePathField = string.Empty;

        private string configFilePathField = string.Empty;

        private string nameField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ClsName {
            get {
                return this.clsNameField;
            }
            set {
                this.clsNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ClsFilePath {
            get {
                return this.clsFilePathField;
            }
            set {
                this.clsFilePathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConfigFilePath
        {
            get
            {
                return this.configFilePathField;
            }
            set
            {
                this.configFilePathField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class UsrCtrlInfo : ClsInfo {
        
        private int xField;
        
        private bool xFieldSpecified;
        
        private int yField;
        
        private bool yFieldSpecified;
        
        private int heightField;
        
        private bool heightFieldSpecified;
        
        private int widthField;
        
        private bool widthFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool XSpecified {
            get {
                return this.xFieldSpecified;
            }
            set {
                this.xFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YSpecified {
            get {
                return this.yFieldSpecified;
            }
            set {
                this.yFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HeightSpecified {
            get {
                return this.heightFieldSpecified;
            }
            set {
                this.heightFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WidthSpecified {
            get {
                return this.widthFieldSpecified;
            }
            set {
                this.widthFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Options {
        
        private ClsInfo[] optionField;

        private ClsInfo monitorField = new ClsInfo();
        
        private string titleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Option", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo[] Option {
            get {
                return this.optionField;
            }
            set {
                this.optionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Monitor",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo Monitor
        {
            get
            {
                return this.monitorField;
            }
            set
            {
                this.monitorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Practices {
        
        private Practice[] practiceField;

        private string titleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Practice[] Practice {
            get {
                return this.practiceField;
            }
            set {
                this.practiceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Exam))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Practice {

        private ClsInfo monitorField = new ClsInfo();

        private ClsInfo translatorField = new ClsInfo();

        private ClsInfo stateManagerField = new ClsInfo();
        
        private string licenseListField;

        private UsrCtrlInfo modelDisplayField = new UsrCtrlInfo();

        private ClsInfo lEDConfigField = new ClsInfo();

        private ClsInfo lEDField = new ClsInfo();

        private ClsInfo settingField = new ClsInfo();

        private string titleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo Monitor {
            get {
                return this.monitorField;
            }
            set {
                this.monitorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo Translator {
            get {
                return this.translatorField;
            }
            set {
                this.translatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo StateManager {
            get {
                return this.stateManagerField;
            }
            set {
                this.stateManagerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LicenseList {
            get {
                return this.licenseListField;
            }
            set {
                this.licenseListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UsrCtrlInfo ModelDisplay {
            get {
                return this.modelDisplayField;
            }
            set {
                this.modelDisplayField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo LED {
            get {
                return this.lEDField;
            }
            set {
                this.lEDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo LEDConfig
        {
            get
            {
                return this.lEDConfigField;
            }
            set
            {
                this.lEDConfigField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ClsInfo Setting {
            get {
                return this.settingField;
            }
            set {
                this.settingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Exam : Practice {

        private UsrCtrlInfo examCtrlField = new UsrCtrlInfo();

        private bool hasQueueField = false;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UsrCtrlInfo ExamCtrl {
            get {
                return this.examCtrlField;
            }
            set {
                this.examCtrlField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool HasQueue
        {
            get
            {
                return this.hasQueueField;
            }
            set
            {
                this.hasQueueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public partial class Exams {
        
        private Exam[] examField;

        private string titleField = string.Empty;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Exam", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Exam[] Exam {
            get {
                return this.examField;
            }
            set {
                this.examField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
    }
}