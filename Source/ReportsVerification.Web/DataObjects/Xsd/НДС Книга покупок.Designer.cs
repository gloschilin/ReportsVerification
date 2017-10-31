// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.4.0.7
//    <NameSpace>ReportsVerification.Web.DataObjects.Xsd.PurchasesBookNds</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><DataMemberNameArg>OnlyIfDifferent</DataMemberNameArg><DataMemberOnXmlIgnore>False</DataMemberOnXmlIgnore><CodeBaseTag>Net20</CodeBaseTag><InitializeFields>All</InitializeFields><GenerateUnusedComplexTypes>False</GenerateUnusedComplexTypes><GenerateUnusedSimpleTypes>False</GenerateUnusedSimpleTypes><GenerateXMLAttributes>True</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableLazyLoading>False</EnableLazyLoading><VirtualProp>False</VirtualProp><PascalCase>False</PascalCase><AutomaticProperties>False</AutomaticProperties><PropNameSpecified>None</PropNameSpecified><PrivateFieldName>StartWithUnderscore</PrivateFieldName><PrivateFieldNamePrefix></PrivateFieldNamePrefix><EnableRestriction>False</EnableRestriction><RestrictionMaxLenght>False</RestrictionMaxLenght><RestrictionRegEx>False</RestrictionRegEx><RestrictionRange>False</RestrictionRange><ValidateProperty>False</ValidateProperty><ClassNamePrefix></ClassNamePrefix><ClassLevel>Public</ClassLevel><PartialClass>True</PartialClass><ClassesInSeparateFiles>False</ClassesInSeparateFiles><ClassesInSeparateFilesDir></ClassesInSeparateFilesDir><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><EnableAppInfoSettings>False</EnableAppInfoSettings><EnableExternalSchemasCache>False</EnableExternalSchemasCache><EnableDebug>False</EnableDebug><EnableWarn>False</EnableWarn><ExcludeImportedTypes>False</ExcludeImportedTypes><ExpandNesteadAttributeGroup>False</ExpandNesteadAttributeGroup><CleanupCode>False</CleanupCode><EnableXmlSerialization>False</EnableXmlSerialization><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><EnableEncoding>False</EnableEncoding><EnableXMLIndent>False</EnableXMLIndent><IndentChar>Indent2Space</IndentChar><NewLineAttr>False</NewLineAttr><OmitXML>False</OmitXML><Encoder>UTF8</Encoder><Serializer>XmlSerializer</Serializer><sspNullable>False</sspNullable><sspString>False</sspString><sspCollection>False</sspCollection><sspComplexType>False</sspComplexType><sspSimpleType>False</sspSimpleType><sspEnumType>False</sspEnumType><XmlSerializerEvent>False</XmlSerializerEvent><BaseClassName>EntityBase</BaseClassName><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><CustomUsings></CustomUsings><AttributesToExlude></AttributesToExlude>
//  </auto-generated>
// ------------------------------------------------------------------------------

using ReportsVerification.Web.DataObjects.Interfaces;

#pragma warning disable
namespace ReportsVerification.Web.DataObjects.Xsd.PurchasesBookNds
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Xml;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Файл : IXsdReport
    {
        
        #region Private fields
        private ФайлДокумент _документ;
        
        private string _идФайл;
        
        private string _версПрог;
        
        private ФайлВерсФорм _версФорм;
        #endregion
        
        public Файл()
        {
            this._документ = new ФайлДокумент();
        }
        
        public ФайлДокумент Документ
        {
            get
            {
                return this._документ;
            }
            set
            {
                this._документ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ИдФайл
        {
            get
            {
                return this._идФайл;
            }
            set
            {
                this._идФайл = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ВерсПрог
        {
            get
            {
                return this._версПрог;
            }
            set
            {
                this._версПрог = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ФайлВерсФорм ВерсФорм
        {
            get
            {
                return this._версФорм;
            }
            set
            {
                this._версФорм = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ФайлДокумент
    {
        
        #region Private fields
        private ФайлДокументКнигаПокуп _книгаПокуп;
        
        private string _индекс;
        
        private string _номКорр;
        
        private ФайлДокументПризнСвед8 _признСвед8;
        #endregion
        
        public ФайлДокумент()
        {
            this._книгаПокуп = new ФайлДокументКнигаПокуп();
        }
        
        public ФайлДокументКнигаПокуп КнигаПокуп
        {
            get
            {
                return this._книгаПокуп;
            }
            set
            {
                this._книгаПокуп = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Индекс
        {
            get
            {
                return this._индекс;
            }
            set
            {
                this._индекс = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string НомКорр
        {
            get
            {
                return this._номКорр;
            }
            set
            {
                this._номКорр = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ФайлДокументПризнСвед8 ПризнСвед8
        {
            get
            {
                return this._признСвед8;
            }
            set
            {
                this._признСвед8 = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ФайлДокументКнигаПокуп
    {
        
        #region Private fields
        private List<ФайлДокументКнигаПокупКнПокСтр> _кнПокСтр;
        
        private decimal _сумНДСВсКПк;
        #endregion
        
        public ФайлДокументКнигаПокуп()
        {
            this._кнПокСтр = new List<ФайлДокументКнигаПокупКнПокСтр>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("КнПокСтр")]
        public List<ФайлДокументКнигаПокупКнПокСтр> КнПокСтр
        {
            get
            {
                return this._кнПокСтр;
            }
            set
            {
                this._кнПокСтр = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal СумНДСВсКПк
        {
            get
            {
                return this._сумНДСВсКПк;
            }
            set
            {
                this._сумНДСВсКПк = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ФайлДокументКнигаПокупКнПокСтр
    {
        
        #region Private fields
        private List<ФайлДокументКнигаПокупКнПокСтрКодВидОпер> _кодВидОпер;
        
        private List<ФайлДокументКнигаПокупКнПокСтрДокПдтвУпл> _докПдтвУпл;
        
        private List<string> _датаУчТов;
        
        private List<СвУчСдТип> _свПрод;
        
        private СвУчСдТип _свПос;
        
        private List<string> _регНомТД;
        
        private string _номерПор;
        
        private string _номСчФПрод;
        
        private string _датаСчФПрод;
        
        private string _номИспрСчФ;
        
        private string _датаИспрСчФ;
        
        private string _номКСчФПрод;
        
        private string _датаКСчФПрод;
        
        private string _номИспрКСчФ;
        
        private string _датаИспрКСчФ;
        
        private string _оКВ;
        
        private decimal _стоимПокупВ;
        
        private decimal _сумНДСВыч;
        #endregion
        
        public ФайлДокументКнигаПокупКнПокСтр()
        {
            this._регНомТД = new List<string>();
            this._свПос = new СвУчСдТип();
            this._свПрод = new List<СвУчСдТип>();
            this._датаУчТов = new List<string>();
            this._докПдтвУпл = new List<ФайлДокументКнигаПокупКнПокСтрДокПдтвУпл>();
            this._кодВидОпер = new List<ФайлДокументКнигаПокупКнПокСтрКодВидОпер>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("КодВидОпер")]
        public List<ФайлДокументКнигаПокупКнПокСтрКодВидОпер> КодВидОпер
        {
            get
            {
                return this._кодВидОпер;
            }
            set
            {
                this._кодВидОпер = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("ДокПдтвУпл")]
        public List<ФайлДокументКнигаПокупКнПокСтрДокПдтвУпл> ДокПдтвУпл
        {
            get
            {
                return this._докПдтвУпл;
            }
            set
            {
                this._докПдтвУпл = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("ДатаУчТов")]
        public List<string> ДатаУчТов
        {
            get
            {
                return this._датаУчТов;
            }
            set
            {
                this._датаУчТов = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("СвПрод")]
        public List<СвУчСдТип> СвПрод
        {
            get
            {
                return this._свПрод;
            }
            set
            {
                this._свПрод = value;
            }
        }
        
        public СвУчСдТип СвПос
        {
            get
            {
                return this._свПос;
            }
            set
            {
                this._свПос = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("РегНомТД")]
        public List<string> РегНомТД
        {
            get
            {
                return this._регНомТД;
            }
            set
            {
                this._регНомТД = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string НомерПор
        {
            get
            {
                return this._номерПор;
            }
            set
            {
                this._номерПор = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string НомСчФПрод
        {
            get
            {
                return this._номСчФПрод;
            }
            set
            {
                this._номСчФПрод = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ДатаСчФПрод
        {
            get
            {
                return this._датаСчФПрод;
            }
            set
            {
                this._датаСчФПрод = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string НомИспрСчФ
        {
            get
            {
                return this._номИспрСчФ;
            }
            set
            {
                this._номИспрСчФ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ДатаИспрСчФ
        {
            get
            {
                return this._датаИспрСчФ;
            }
            set
            {
                this._датаИспрСчФ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string НомКСчФПрод
        {
            get
            {
                return this._номКСчФПрод;
            }
            set
            {
                this._номКСчФПрод = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ДатаКСчФПрод
        {
            get
            {
                return this._датаКСчФПрод;
            }
            set
            {
                this._датаКСчФПрод = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string НомИспрКСчФ
        {
            get
            {
                return this._номИспрКСчФ;
            }
            set
            {
                this._номИспрКСчФ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ДатаИспрКСчФ
        {
            get
            {
                return this._датаИспрКСчФ;
            }
            set
            {
                this._датаИспрКСчФ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ОКВ
        {
            get
            {
                return this._оКВ;
            }
            set
            {
                this._оКВ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal СтоимПокупВ
        {
            get
            {
                return this._стоимПокупВ;
            }
            set
            {
                this._стоимПокупВ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal СумНДСВыч
        {
            get
            {
                return this._сумНДСВыч;
            }
            set
            {
                this._сумНДСВыч = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum ФайлДокументКнигаПокупКнПокСтрКодВидОпер
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("20")]
        Item20,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("22")]
        Item22,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ФайлДокументКнигаПокупКнПокСтрДокПдтвУпл
    {
        
        #region Private fields
        private string _номДокПдтвУпл;
        
        private string _датаДокПдтвУпл;
        #endregion
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string НомДокПдтвУпл
        {
            get
            {
                return this._номДокПдтвУпл;
            }
            set
            {
                this._номДокПдтвУпл = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ДатаДокПдтвУпл
        {
            get
            {
                return this._датаДокПдтвУпл;
            }
            set
            {
                this._датаДокПдтвУпл = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class СвУчСдТип
    {
        
        #region Private fields
        private object _item;
        #endregion
        
        [System.Xml.Serialization.XmlElementAttribute("СведИП", typeof(СвУчСдТипСведИП))]
        [System.Xml.Serialization.XmlElementAttribute("СведЮЛ", typeof(СвУчСдТипСведЮЛ))]
        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class СвУчСдТипСведИП
    {
        
        #region Private fields
        private string _иННФЛ;
        #endregion
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ИННФЛ
        {
            get
            {
                return this._иННФЛ;
            }
            set
            {
                this._иННФЛ = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class СвУчСдТипСведЮЛ
    {
        
        #region Private fields
        private string _иННЮЛ;
        
        private string _кПП;
        #endregion
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ИННЮЛ
        {
            get
            {
                return this._иННЮЛ;
            }
            set
            {
                this._иННЮЛ = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string КПП
        {
            get
            {
                return this._кПП;
            }
            set
            {
                this._кПП = value;
            }
        }
    }
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum ФайлДокументПризнСвед8
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum ФайлВерсФорм
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5.05")]
        Item505,
    }
}
#pragma warning restore
