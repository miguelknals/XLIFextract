using System;
using System.Collections.Generic;
using System.Text;

namespace XLIFextract
{
    // 
    // Este código fuente fue generado automáticamente por xsd, Versión=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:xliff:document:2.0", IsNullable = false)]
    public partial class xliff
    {

        private xliffFile[] fileField;

        private xliffWordcounts[] wordcountsField;

        private string versionField;

        private string srcLangField;

        private string trgLangField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("file")]
        public xliffFile[] file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("wordcounts")]
        public xliffWordcounts[] wordcounts
        {
            get
            {
                return this.wordcountsField;
            }
            set
            {
                this.wordcountsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string srcLang
        {
            get
            {
                return this.srcLangField;
            }
            set
            {
                this.srcLangField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string trgLang
        {
            get
            {
                return this.trgLangField;
            }
            set
            {
                this.trgLangField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffFile
    {

        private xliffFileNotes[] notesField;

        private xliffFileUnit[] unitField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("notes")]
        public xliffFileNotes[] notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("unit")]
        public xliffFileUnit[] unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffFileNotes
    {

        private string noteField;

        /// <remarks/>
        public string note
        {
            get
            {
                return this.noteField;
            }
            set
            {
                this.noteField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffFileUnit
    {

        private xliffFileUnitSegment[] segmentField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("segment")]
        public xliffFileUnitSegment[] segment
        {
            get
            {
                return this.segmentField;
            }
            set
            {
                this.segmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffFileUnitSegment
    {

        private string sourceField;

        private string targetField;

        private string stateField;

        private string segnumberField;

        private string markupField;

        private string wordcountField;

        private string previousField;

        /// <remarks/>
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        public string target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string segnumber
        {
            get
            {
                return this.segnumberField;
            }
            set
            {
                this.segnumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string markup
        {
            get
            {
                return this.markupField;
            }
            set
            {
                this.markupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string wordcount
        {
            get
            {
                return this.wordcountField;
            }
            set
            {
                this.wordcountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string previous
        {
            get
            {
                return this.previousField;
            }
            set
            {
                this.previousField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcounts
    {

        private xliffWordcountsFinal[] finalField;

        private xliffWordcountsExact[] exactField;

        private xliffWordcountsMachine[] machineField;

        private xliffWordcountsNew[] newField;

        private xliffWordcountsDuplicate[] duplicateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("final")]
        public xliffWordcountsFinal[] final
        {
            get
            {
                return this.finalField;
            }
            set
            {
                this.finalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exact")]
        public xliffWordcountsExact[] exact
        {
            get
            {
                return this.exactField;
            }
            set
            {
                this.exactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("machine")]
        public xliffWordcountsMachine[] machine
        {
            get
            {
                return this.machineField;
            }
            set
            {
                this.machineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("new")]
        public xliffWordcountsNew[] @new
        {
            get
            {
                return this.newField;
            }
            set
            {
                this.newField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("duplicate")]
        public xliffWordcountsDuplicate[] duplicate
        {
            get
            {
                return this.duplicateField;
            }
            set
            {
                this.duplicateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcountsFinal
    {

        private string wcField;

        private string eventsField;

        /// <remarks/>
        public string wc
        {
            get
            {
                return this.wcField;
            }
            set
            {
                this.wcField = value;
            }
        }

        /// <remarks/>
        public string events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcountsExact
    {

        private string wcField;

        private string eventsField;

        /// <remarks/>
        public string wc
        {
            get
            {
                return this.wcField;
            }
            set
            {
                this.wcField = value;
            }
        }

        /// <remarks/>
        public string events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcountsMachine
    {

        private string wcField;

        private string eventsField;

        /// <remarks/>
        public string wc
        {
            get
            {
                return this.wcField;
            }
            set
            {
                this.wcField = value;
            }
        }

        /// <remarks/>
        public string events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcountsNew
    {

        private string wcField;

        private string eventsField;

        /// <remarks/>
        public string wc
        {
            get
            {
                return this.wcField;
            }
            set
            {
                this.wcField = value;
            }
        }

        /// <remarks/>
        public string events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    public partial class xliffWordcountsDuplicate
    {

        private string wcField;

        private string eventsField;

        /// <remarks/>
        public string wc
        {
            get
            {
                return this.wcField;
            }
            set
            {
                this.wcField = value;
            }
        }

        /// <remarks/>
        public string events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:oasis:names:tc:xliff:document:2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:oasis:names:tc:xliff:document:2.0", IsNullable = false)]
    public partial class NewDataSet
    {

        private xliff[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("xliff")]
        public xliff[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

}
