## Документация по взаимедействию с API сервисом
### Сессия пользователя
Весь обмен данными одной сверки должен происходить в рамках одной сессии.

```ts
interface ISessionInfo
{
  id : guid  
}
```
Перед началом загрузки документов и их проверкой необходимо получить идентификатор сессии. 
```json
POST: /api/session
BODY: { "userId" : "int" }
RESPONSE: ISessionInfo
```

Для получения информации по сессии:
```
GET: /api/session/{sessionId}
RESPONSE: ISessionInfo
```
Обновление данных сессии происходит ответе на контрольные вопросы пользвоателем
```
PUT: /api/session/{sessionId}
BODY: ISessionInfo
RESPONSE ISessionInfo
```
где `sessionId` идентификатор ранее полученной сессии


## Загрузка отчетов

Загрузка файлов XML отчетов:
```
POST: /api/{sessionId}/reports
BODY: XML файла отчета
RESPONSE OK: 201
RESPONSE Error: 400, в теле овтета сообщение о выданном исключении при загрузке файла
```

## Получение информации о загруженных отчетах

Заруженный отчет представляет собой объект:
```ts
interface IReportInfo
{
  reportMonth: IDateOfMonth,
  companyName: string,
  type: ReportType
}
```

где 

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
GET: /api/{sessionId}/reports?type=Exists
RESPONSE: IReportInfo[]
```

Перечень недостающих отчетов (рекомендации к загрузке):
```
GET: /api/{sessionId}/reports?type=Missing
RESPONSE: IReportInfo[]
```

### Валидация и проверка отчетности:

НЕ РЕАЛИЗОВАНО
