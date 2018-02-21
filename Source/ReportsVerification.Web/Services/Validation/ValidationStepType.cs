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
        /// Проверка декларации по НДС за 2 кв 
        /// Доля вычетов
        /// </summary>
        Nds3DeductionValidator,

        /// <summary>
        /// Проверка декларации по НДС за 4 кв 
        /// Доля вычетов
        /// </summary>
        Nds4DeductionValidator,

        /// <summary>
        /// Проверка декларации по НДС за 4 кв 
        /// Есть ли возмещение
        /// </summary>
        Nds4VosmechenieValidator,

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
        /// Проверка декларации по налогу на прибыль за 4 кв 
        /// Соотношение прямых расходов и выручки от реализации
        /// </summary>
        DeclarationOnIncomeTaxDirectCosts4Validator,
        
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
        /// Проверка декларации по налогу на прибыль за 4 кв 
        /// Убыток
        /// </summary>
        DeclarationOnIncomeTaxLoss4Validator,
        
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

        /// <summary>
        /// Проверка декларации по налогу на прибыль за 4 кв 
        /// Выручку по НДС и прибыли
        /// </summary>
        DeclarationOnIncomeTaxRevenuesNds4Validator,

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
        /// В фалйле НДФЛ2 все годы должны быть одинаковые
        /// </summary>
        PrimaryReportsNdfl2ByYearValidator,

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

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst11ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst12ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst13ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst21ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst22ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst23ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst31ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst32ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst33ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst41ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst42ErrorsValidator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsFirst43ErrorsValidator,
        
        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors11Validator,

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors12Validator,

        /// <summary>
        /// Проверка расчета по взносам за 1 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors13Validator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors21Validator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors22Validator,

        /// <summary>
        /// Проверка расчета по взносам за 2 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors23Validator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors31Validator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors32Validator,

        /// <summary>
        /// Проверка расчета по взносам за 3 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors33Validator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors41Validator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors42Validator,

        /// <summary>
        /// Проверка расчета по взносам за 4 кв.  
        /// На ошибки, из-за которых отчет не считается сданным 
        /// </summary>
        CalculationContributionsSecondErrors43Validator,
        
        //СЗВМ VS Расчет по взносам
        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 1 кв. с СЗВ-М за январь 
        /// </summary>
        CalculationContributionsVsSzvm11Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 1 кв. с СЗВ-М за февраль  
        /// </summary>
        CalculationContributionsVsSzvm12Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 1 кв. с СЗВ-М за март  
        /// </summary>
        CalculationContributionsVsSzvm13Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 2 кв. с СЗВ-М за апрель  
        /// </summary>
        CalculationContributionsVsSzvm24Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 2 кв. с СЗВ-М за май  
        /// </summary>
        CalculationContributionsVsSzvm25Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 2 кв. с СЗВ-М за июнь  
        /// </summary>
        CalculationContributionsVsSzvm26Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 3 кв. с СЗВ-М за июль  
        /// </summary>
        CalculationContributionsVsSzvm37Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 3 кв. с СЗВ-М за август  
        /// </summary>
        CalculationContributionsVsSzvm38Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 3 кв. с СЗВ-М за сентябрь  
        /// </summary>
        CalculationContributionsVsSzvm39Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 4 кв. с СЗВ-М за октябрь
        /// </summary>
        CalculationContributionsVsSzvm410Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 4 кв. с СЗВ-М за ноябрь
        /// </summary>
        CalculationContributionsVsSzvm411Validator,

        /// <summary>
        /// Сравнение расчета по взносам и СЗВ-М
        /// Сравнение расчета по взносам за 4 кв. с СЗВ-М за декабрь
        /// </summary>
        CalculationContributionsVsSzvm412Validator

        //Валюта баланса  за год предшествующий предыдущему
        //Валюта баланса  за предыдущий год
        //Валюта баланса  за отчетный год
        //Изменение отложенных налоговых активов отчетного года
        //Изменение отложенных налоговых активов предыдущего  года
        //Изменение отложенных налоговых обязательств отчетного года
        //Изменение отложенных налоговых обязательств предыдущего  года
        //Изменение нераспределенной прибыли отчетного года
        //Изменение нераспределенной прибыли предыдущего года
        //Уставный капитал по данным баланса и отчета об изменении капитала за отчетный  год
        //Уставный капитал по данным баланса и отчета об изменении капитала за предыдущий год
        //Уставный капитал по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        //Собственные акции по данным баланса и отчета об изменении капитала за отчетный  год
        //Собственные акции по данным баланса и отчета об изменении капитала за предыдущий год
        //Собственные акции по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        //Резервный капитал  по данным баланса и отчета об изменении капитала за отчетный  год
        //Резервный капитал  по данным баланса и отчета об изменении капитала за предыдущий год
        //Резервный капитал  по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        //Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за отчетный  год
        //Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за предыдущий год
        //Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        //Итого капитал по данным баланса и отчета об изменении капитала за отчетный  год
        //Итого капитал по данным баланса и отчета об изменении капитала за предыдущий год
        //Итого капитал по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        //Сумма переоценки и добавочного капитала по данным баланса и отчета об изменении капитала за отчетный  год
        //Сумма переоценки и добавочного капитала по данным баланса и отчета об изменении капитала за предыдущий год
        //Денежные средства на конец отчетного периода по данным баланса и отчета о движении денежных средств
        //Денежные средства на начало отчетного периода по данным баланса и отчета о движении денежных средств
        //Денежные средства на начало отчетного периода по данным баланса и отчета о движении денежных средств
        //Чистая прибыль (убыток) за  отчетный период по данным баланса и отчета об изменении капитала
        //Чистая прибыль (убыток) за пошлый год по данным баланса и отчета об изменении капитала
        //Общая сумма дохода за год (проверка по ставке 13%)
        //Общая сумма дохода за год (проверка по ставке 9%)
        //Общая сумма дохода за год (проверка по ставке 15%)
        //Общая сумма дохода за год (проверка по ставке 35%)
        //Общая сумма дивидендов по ставке 13 %
        //Общая сумма дивидендов по ставке 15 %
        //Исчисленная сумма налога по ставке 13 %
        //Исчисленная сумма налога по ставке 9 %
        //Исчисленная сумма налога по ставке 15 %
        //Исчисленная сумма налога по ставке 35 %
        //Не удержанный налог
        //Количество физлиц, получивших доход
    }
}