# SentimentAnalysisWebAPI
 
Web-сервис реализующий публичное REST API, позволяющий классифицировать обращение исходя из его текста, формат входных и выходных данных JSON.

Протестировать работу сервиса можно тут http://ml.somee.com/swagger/index.html

или отправив json-запрос вида

```json
{
  "SentimentText" : "текст для анализа"
}
```
по адресу http://ml.somee.com/api/predict