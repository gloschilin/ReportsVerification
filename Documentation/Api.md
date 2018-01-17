## Документация по взаимедействию с API сервисом
### Сессия пользователя
Весь обмен данными одной сверки должен происходить в рамках одной сессии.

```ts
interface ISessionInfo
{
  /// <summary>
  /// Идентификатор сессии
  /// </summary>
  id : guid,
  
  /// <summary>
  /// Идентификатор пользователя из ID2
  /// </summary>
  userId: int,
  
  category : "ALIAS",
  mode : "ALIAS",
  regionId : "GUID"
}
```
Где `category` - категория компании.

Значения `category`:

```
/// <summary>
/// ООО – работодатель
/// </summary>
OooEmployer,

/// <summary>
/// АО  ? работодатель
/// </summary>
AoEmployer,

/// <summary>
/// ИП без сотрудников
/// </summary>
IpWithoutEmployees,

/// <summary>
/// ИП – работодатель
/// </summary>
IpEmployer,

/// <summary>
/// АО без сотрудников
/// </summary>
AoWithoutEmployees,

/// <summary>
/// ООО без сотрудников
/// </summary>
OooWithoutEmployees,
```

Где `mode` - режимы пользователя. 

Значения `mode`:
```
/// <summary>
/// Патент
/// </summary>
Patent,

/// <summary>
/// ОСНО
/// </summary>
Osno,

/// <summary>
/// УСН + ЕНВД
/// </summary>
UsnWitnEnvd,

/// <summary>
 /// ЕСХН + ЕНВД
/// </summary>
EshnWithEnvd,

/// <summary>
/// ОСНО + ЕНВД
/// </summary>
OsnoWithEnvd,

/// <summary>
/// ЕНВД
/// </summary>
Envd,

/// <summary>
/// УСН
/// </summary>
Usn,

/// <summary>
/// ЕСХН
/// </summary>
Eshn
```
Где `regionId` выбранный регион пользователя.

Перед началом загрузки документов и их проверкой необходимо получить идентификатор сессии. 
```json
POST: /api/sessions
BODY: { "userId" : "int" }
RESPONSE: ISessionInfo
```

Для получения информации по сессии:
```
GET: /api/sessions/{sessionId}
RESPONSE: ISessionInfo
```
Обновление данных сессии происходит при ответе на контрольные вопросы пользвоателем
```
PUT: /api/sessions/{sessionId}
BODY: ISessionInfo
RESPONSE ISessionInfo
```
где `sessionId` идентификатор ранее полученной сессии

## Получение данных справочников

Получение списка регионов
```
GET /api/catalos/regions
RESPONSE IRegion[]
```
```ts
interface IRegion
{
  id: "GUID",
  name: ""
}
```

Получить информацияю по региону
```
GET /api/catalos/regions/{regionId}
RESPONSE IRegionInfo
```
```ts
interface IRegionInfo
{
  id: "GUID",
  name: "",
  
  /// <summary>
  /// Размер МРОТ
  /// </summary>
  mrot: "decimal",
  
  /// <summary>
  /// Значение вычета на 1 квартал
  /// </summary>
  firstQuaterAmountDeduction : "decimal",
  
  /// <summary>
  /// Значение вычета на 2 квартал
  /// </summary>
  secondQuaterAmountDeduction : "decimal",
  
  /// <summary>
  /// Значение вычета на 3 квартал
  /// </summary>
  thirdQuaterAmountDeduction : "decimal",
  
  /// <summary>
  /// Значение вычета на 4 квартал
  /// </summary>
  forthQuaterAmountDeduction : "decimal"
}
```

## Загрузка отчетов

Загрузка файлов XML отчетов:
```
POST: /api/sessions/{sessionId}/reports
BODY: XML файла отчета, можно несколько
RESPONSE OK: 201
RESPONSE Error: 400, в теле овтета сообщение о выданном исключении при загрузке файла
```

## Получение информации о загруженных отчетах

Заруженный отчет представляет собой объект:
```ts
interface IReportInfo
{
  reportMonth: TDate,
  companyName: string,
  type: TReportType,
  companyName : "",
  inn : ""
}
```

где `TDate` представляет дату отчета, возможные типы `IDateOfQuarter`, `IDateOfMonth`

```ts
interface IDateOfQuarter
{
  year: int,
  quarter: int
}
```

```ts
interface IDateOfMonth
{
  year: int,
  month: int
}
```

а перечисление ReportType может принимать значения:

```ts
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
```

Загруженные отчеты:
```
GET: /api/sessions/{sessionId}/reports?type=Exists
RESPONSE: IReportInfo[]
```

Перечень недостающих отчетов (рекомендации к загрузке):
```
GET: /api/sessions/{sessionId}/reports?type=Missing
RESPONSE: IReportInfo[]
```

### Валидация и проверка отчетности:

После загрузки отчетов делаем их проверку. 
```
HTTP GET: api/services/validation?sessionId={sessionId}&type={validationType}
```
где `{sessionId}` идентификатор сессии загрузки

а `{validationType}` может принимать значения `Primary` (первичная валидация) `Secondary` (полная валидация)

В ответе будет коллекция из ALIAS валидационных сообщений. 
```
RESPONSE: ValidationStepType[]
```
Где `ValidationStepType` может принимать следующий значения

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
```

### Получение рекомендаций после загрузки и валидации отчетов
```
HTTP GET: api/services/recomendations?sessionId={sessionId}
RESPONSE: ReportsRecomendationTypes[]
```

Где `ReportsRecomendationTypes` могут принимать значения

```
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
```
