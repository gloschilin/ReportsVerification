namespace ReportsVerification.Web.Services.Validation
{
    public enum ValidationStepType
    {
        //Nds

        /// <summary>
        /// Проверка декларации по НДС за 1 кв 
        /// Есть ли возмещение
        /// </summary>
        Nds1VosmechenieValidator,

        /// <summary>
        /// Проверка декларации по НДС за 1 кв 
        /// Доля вычетов
        /// </summary>
        Nds1DeductionValidator,

        /// <summary>
        /// Проверка декларации по НДС за 2 кв 
        /// Есть ли возмещение
        /// </summary>
        Nds2VosmechenieValidator,

        /// <summary>
        /// /// <summary>
        /// Проверка декларации по НДС за 2 кв 
        /// Доля вычетов
        /// </summary>
        /// </summary>
        Nds2DeductionValidator,

        /// <summary>
        /// Проверка декларации по НДС за 3 кв 
        /// Есть ли возмещение
        /// </summary>
        Nds3VosmechenieValidator,

        /// <summary>
        /// /// <summary>
        /// Проверка декларации по НДС за 2 кв 
        /// Доля вычетов
        /// </summary>
        /// </summary>
        Nds3DeductionValidator,

        //DeclarationOnIncomeTax

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 1 кв
        /// Соотношение прямых расходов и выручки от реализации
        /// </summary>
        DeclarationOnIncomeTaxDirectCosts1Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 2 кв 
        /// Соотношение прямых расходов и выручки от реализации
        /// </summary>
        DeclarationOnIncomeTaxDirectCosts2Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 3 кв 
        /// Соотношение прямых расходов и выручки от реализации
        /// </summary>
        DeclarationOnIncomeTaxDirectCosts3Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 1 кв 
        /// Убыток
        /// </summary>
        DeclarationOnIncomeTaxLoss1Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 2 кв 
        /// Убыток
        /// </summary>
        DeclarationOnIncomeTaxLoss2Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 3 кв 
        /// Убыток
        /// </summary>
        DeclarationOnIncomeTaxLoss3Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 1 кв 
        /// Выручку по НДС и прибыли
        /// </summary>
        DeclarationOnIncomeTaxRevenuesNds1Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 2 кв 
        /// Выручку по НДС и прибыли
        /// </summary>
        DeclarationOnIncomeTaxRevenuesNds2Validator,

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 3 кв 
        /// Выручку по НДС и прибыли
        /// </summary>
        DeclarationOnIncomeTaxRevenuesNds3Validator,

        //Primary

        /// <summary>
        /// Валидация после загрузки 
        /// Валидайия отчетов на уникальность
        /// </summary>
        PrimaryReportsIsUniqueValidator,

        /// <summary>
        /// Валидация после загрузки 
        /// По  году (он во всех загруженных файлах должен быть один) 
        /// Пока закладываем проверку по 2017 году
        /// </summary>
        PrimaryReportsByYearValidator,

        /// <summary>
        /// Валидация после загрузки 
        /// По ИНН (во всех загруженный файлах ИНН должен быть один)
        /// </summary>
        PrimaryReportsByInnValidator,

        //НДФЛ6

        /// <summary>
        /// Проверка 6-НДФЛ за 1 кв. 
        /// Зарплату на региональный МРОТ
        /// </summary>
        Ndfl61WageMrotValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 2 кв. 
        /// Зарплату на региональный МРОТ
        /// </summary>
        Ndfl62WageMrotValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 3 кв. 
        /// Зарплату на региональный МРОТ
        /// </summary>
        Ndfl63WageMrotValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 4 кв. 
        /// Зарплату на региональный МРОТ
        /// </summary>
        Ndfl64WageMrotValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 1 кв. 
        /// На исчисленный налог
        /// </summary>
        Ndfl61TaxesValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 2 кв.
        /// На исчисленный налог 
        /// </summary>
        Ndfl62TaxesValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 3 кв. 
        /// На исчисленный налог
        /// </summary>
        Ndfl63TaxesValidator,

        /// <summary>
        /// Проверка 6-НДФЛ за 4 кв. 
        /// На исчисленный налог
        /// </summary>
        Ndfl64TaxesValidator,

        //Расчет по взносам

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// Сравнение базы с 6-НДФЛ 
        /// </summary>
        CalculationContributions1WithNdfl6BaseValidator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// Сравнение базы с 6-НДФЛ 
        /// </summary>
        CalculationContributions2WithNdfl6BaseValidator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// Сравнение базы с 6-НДФЛ 
        /// </summary>
        CalculationContributions3WithNdfl6BaseValidator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// Сравнение базы с 6-НДФЛ 
        /// </summary>
        CalculationContributions4WithNdfl6BaseValidator,

        CalculationContributionsFirst11ErrorsValidator,
        CalculationContributionsFirst12ErrorsValidator,
        CalculationContributionsFirst13ErrorsValidator,
        CalculationContributionsFirst21ErrorsValidator,
        CalculationContributionsFirst22ErrorsValidator,
        CalculationContributionsFirst23ErrorsValidator,
        CalculationContributionsFirst31ErrorsValidator,
        CalculationContributionsFirst32ErrorsValidator,
        CalculationContributionsFirst33ErrorsValidator,
        CalculationContributionsSecondErrors11Validator,
        CalculationContributionsSecondErrors12Validator,
        CalculationContributionsSecondErrors13Validator,
        CalculationContributionsSecondErrors21Validator,
        CalculationContributionsSecondErrors22Validator,
        CalculationContributionsSecondErrors23Validator,
        CalculationContributionsSecondErrors31Validator,
        CalculationContributionsSecondErrors32Validator,
        CalculationContributionsSecondErrors33Validator,

        //СЗВМ VS Расчет по взносам

        CalculationContributionsVsSzvm11Validator,
        CalculationContributionsVsSzvm12Validator,
        CalculationContributionsVsSzvm13Validator,
        CalculationContributionsVsSzvm24Validator,
        CalculationContributionsVsSzvm25Validator,
        CalculationContributionsVsSzvm26Validator,
        CalculationContributionsVsSzvm37Validator,
        CalculationContributionsVsSzvm38Validator,
        CalculationContributionsVsSzvm39Validator
    }
}