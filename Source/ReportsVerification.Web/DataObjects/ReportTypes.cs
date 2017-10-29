namespace ReportsVerification.Web.DataObjects
{
    /// <summary>
    /// Типы обрабатываемый отчетов
    /// </summary>
    public enum ReportTypes
    {
        /// <summary>
        /// 2 НДФЛ
        /// </summary>
        Ndfl2,

        /// <summary>
        /// 6 НДФЛ
        /// </summary>
        Ndfl6,

        /// <summary>
        /// Бухгалтерская отчетность
        /// </summary>
        AccountingStatement,

        /// <summary>
        /// Бухгалтерская отчетность упрощенка
        /// </summary>
        AccountingStatementSimplifiedTaxation,

        /// <summary>
        /// ЕНВД
        /// </summary>
        Envd,

        /// <summary>
        /// Декларация по земельному  налогу
        /// </summary>
        DeclarationOnLandTax,

        /// <summary>
        /// Декларация по налогу на имущество
        /// </summary>
        DeclarationOnPropertyTax,

        /// <summary>
        /// Декларация по налогу на прибыль
        /// </summary>
        DeclarationOnIncomeTax,

        /// <summary>
        /// НДС
        /// </summary>
        Nds,

        /// <summary>
        /// УСН
        /// </summary>
        Usn,

        /// <summary>
        /// Расчет по авансовому платежу по налогу на имущество организаций
        /// </summary>
        CalculationAdvancePayment,

        /// <summary>
        /// Расчет по взносам
        /// </summary>
        CalculationContributions,

        /// <summary>
        /// СЗВМ
        /// </summary>
        SzvM,

        /// <summary>
        /// Транспортная декларация
        /// </summary>
        TransportDeclaration
    }
}