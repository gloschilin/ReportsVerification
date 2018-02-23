## Типы валидационных сообщений

```
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
        CalculationContributionsVsSzvm412Validator,

        //Валюта баланса  за год предшествующий предыдущему
        CurencyBalance1Validator,
        
        //Валюта баланса  за предыдущий год
        CurencyBalance2Validator,

        //Валюта баланса  за отчетный год
        CurencyBalance3Validator,

        /// <summary>
        /// Изменение отложенных налоговых активов отчетного года
        /// </summary>
        AccountingStatement1Validtor,

        /// <summary>
        /// Изменение отложенных налоговых активов предыдущего  года
        /// </summary>
        AccountingStatement2Validtor,

        /// <summary>
        /// Изменение отложенных налоговых обязательств отчетного года
        /// </summary>
        AccountingStatement3Validtor,

        /// <summary>
        /// Изменение отложенных налоговых обязательств предыдущего  года
        /// </summary>
        AccountingStatement4Validtor,

        /// <summary>
        /// Изменение нераспределенной прибыли отчетного года
        /// </summary>
        AccountingStatement5Validtor,

        /// <summary>
        /// Изменение нераспределенной прибыли предыдущего года
        /// </summary>
        AccountingStatement6Validtor,

        /// <summary>
        /// Валюта баланса  за год, предшествующий предыдущему
        /// </summary>
        AccountingStatement7Validtor,

        /// <summary>
        /// Валюта баланса  за предыдущий год 
        /// </summary>
        AccountingStatement8Validtor,

        /// <summary>
        /// Валюта баланса  за отчетный год
        /// </summary>
        AccountingStatement9Validtor,

        /// <summary>
        /// Уставный капитал по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement10Validtor,

        /// <summary>
        /// Уставный капитал по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement11Validtor,

        /// <summary>
        /// Уставный капитал по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        /// </summary>
        AccountingStatement12Validtor,

        /// <summary>
        /// Собственные акции по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement13Validtor,

        /// <summary>
        /// Собственные акции по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement14Validtor,

        /// <summary>
        /// Собственные акции по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        /// </summary>
        AccountingStatement15Validtor,

        /// <summary>
        /// Резервный капитал  по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement16Validtor,

        /// <summary>
        /// Резервный капитал  по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement17Validtor,

        /// <summary>
        /// Резервный капитал  по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        /// </summary>
        AccountingStatement18Validtor,

        /// <summary>
        /// Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement19Validtor,

        /// <summary>
        /// Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement20Validtor,

        /// <summary>
        /// Нераспределенная прибыль (непокрытый убыток) по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        /// </summary>
        AccountingStatement21Validtor,

        /// <summary>
        /// Итого капитал по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement22Validtor,

        /// <summary>
        /// Итого капитал по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement23Validtor,

        /// <summary>
        /// Итого капитал по данным баланса и отчета об изменении капитала за год, предшествующий  предыдущему
        /// </summary>
        AccountingStatement24Validtor,

        /// <summary>
        /// Сумма переоценки и добавочного капитала по данным баланса и отчета об изменении капитала за отчетный  год
        /// </summary>
        AccountingStatement25Validtor,

        /// <summary>
        /// Сумма переоценки и добавочного капитала по данным баланса и отчета об изменении капитала за предыдущий год
        /// </summary>
        AccountingStatement26Validtor,

        /// <summary>
        /// Денежные средства на конец отчетного периода по данным баланса и отчета о движении денежных средств
        /// </summary>
        AccountingStatement27Validtor,

        /// <summary>
        /// Денежные средства на начало отчетного периода по данным баланса и отчета о движении денежных средств
        /// </summary>
        AccountingStatement28Validtor,

        /// <summary>
        /// Денежные средства на начало отчетного периода по данным баланса и отчета о движении денежных средств
        /// </summary>
        AccountingStatement29Validtor,

        /// <summary>
        /// Чистая прибыль (убыток) за  отчетный период по данным баланса и отчета об изменении капитала
        /// </summary>
        AccountingStatement30Validtor,

        /// <summary>
        /// Чистая прибыль (убыток) за пошлый год по данным баланса и отчета об изменении капитала
        /// </summary>
        AccountingStatement31Validtor,

        /// <summary>
        /// Общая сумма дохода за год (проверка по ставке 13%)
        /// </summary>
        Ndfl6Vs2Rate13Validator,

        /// <summary>
        /// Общая сумма дохода за год (проверка по ставке 9%)
        /// </summary>
        Ndfl6Vs2Rate9Validator,

        /// <summary>
        /// Общая сумма дохода за год (проверка по ставке 15%) 
        /// </summary>
        Ndfl6Vs2Rate15Validator,

        /// <summary>
        /// Общая сумма дохода за год (проверка по ставке 35%) 
        /// </summary>
        Ndfl6Vs2Rate35Validator,

        /// <summary>
        /// Общая сумма дивидендов по ставке 13 %
        /// </summary>
        Ndfl6Vs2Rate13DivValidator,

        /// <summary>
        /// Общая сумма дивидендов по ставке 15 %
        /// </summary>
        Ndfl6Vs2Rate15DivValidator,

        /// <summary>
        /// Исчисленная сумма налога по ставке 13 %
        /// </summary>
        Ndfl6Vs2Rate13TaxSumValidator,

        /// <summary>
        /// Исчисленная сумма налога по ставке 9 %
        /// </summary>
        Ndfl6Vs2Rate9TaxSumValidator,

        /// <summary>
        /// Исчисленная сумма налога по ставке 15 %
        /// </summary>
        Ndfl6Vs2Rate15TaxSumValidator,

        /// <summary>
        /// Исчисленная сумма налога по ставке 35 %
        /// </summary>
        Ndfl6Vs2Rate35TaxSumValidator,

        /// <summary>
        /// Не удержанный налог
        /// </summary>
        Ndfl6Vs2TaxNuValidator,

        /// <summary>
        /// Количество физлиц, получивших доход
        /// </summary>
        Ndfl6Vs2PersonsAmountValidator
```