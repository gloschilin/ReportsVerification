namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    /// <summary>
    /// Типы рекомендаций для загруженных отчетов
    /// </summary>
    public enum ReportsRecomendationTypes
    {
        /// <summary>
        /// Рекомендация про расчет по взносам 
        /// </summary>
        CalculationContributionsRecomendation,

        /// <summary>
        /// Рекомендация про 6-НДФЛ 
        /// </summary>
        Ndfl6Recomendation,

        /// <summary>
        /// Рекомендация про СЗВ-М
        /// </summary>
        SzvmReomendation,

        /// <summary>
        /// Рекомендация про ЕНВД
        /// </summary>
        EnvdRecomendation,

        /// <summary>
        /// Рекомендация про земельный налог
        /// </summary>
        DeclarationOnLandTaxRecomendation,

        /// <summary>
        /// Рекомендация про бухотчетность
        /// </summary>
        AccountingReportingRecomendation,

        /// <summary>
        /// Рекомендация 1 по налог на имущество
        /// </summary>
        DeclarationOnPropertyTaxRecomendation,

        /// <summary>
        /// Рекомендация 1 по налог на имущество (авансы)
        /// </summary>
        CalculationAdvancePaymentRecomendation,

        /// <summary>
        /// Рекомендация НДС
        /// </summary>
        NdsRecomendation,

        /// <summary>
        /// Рекомендация прибыль
        /// </summary>
        DeclarationOnIncomeTaxRecomendation,

        /// <summary>
        /// Рекомендация УСН
        /// </summary>
        UsnRecomendation,

        /// <summary>
        /// Рекомендация транспорт
        /// </summary>
        TransportDeclarationRecomendation,

        /// <summary>
        /// Рекомендация 4-ФСС
        /// </summary>
        Fss4Recomendation
    }
}