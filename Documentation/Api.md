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
RESPONSE: IValidationInfo[]
```

```IValidationInfo``` представляет собой объект
```
interface IValidationInfo
{
  message: ValidationStepType,
  quarter: int?
}
```
значение quarter может быть пустым для общих соотношений,

а `ValidationStepType` может принимать следующие значения [validationmessages.md]


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
