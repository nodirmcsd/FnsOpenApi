# FnsOpenApi
Клиент для ФНС Open API для проверки чеков 

При регистрации Вы получите также URL доступа к API. Необходимо поменять пути в Connected Service и перегенерировать прокси. 

В ответном письме от технической службы вы получите следующие данные:

- Мастер-токен
- Количество запросов в сутки
- Адрес сервиса
- Руководство пользователя и документация по сервису с примерами в приложенном архиве

**Пример использования**

```
//MasterToken Мастер токен из письма 
//ClientAppId строковый уникальный идентификатор вашего приложения 

IFnsApiClient apiClient = FnsApiClientFactory.CreateClient();
var token = apiClient.GetAuthToken(MasterToken);
Console.WriteLine(token);

var receipt = new Receipt
{
    Date = new DateTime(2020, 1, 18, 15, 46, 0),
    Fp = "54411",
    Fd = "872811111",
    Fn = "9284000100258875",
    Sum = 225.40,
    Operation = 1
};

var result = apiClient.GetReceiptDetails(token, receipt, ClientAppId);
Console.WriteLine(result.ToJson());

```
