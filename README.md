# SentimentAnalysisWebAPI
 
Web-сервис реализующий публичное REST API, позволяющий классифицировать обращение исходя из его текста, формат входных и выходных данных JSON.

Используется модель из https://github.com/Acronus32/SentimentAnalysis

Протестировать работу сервиса можно тут http://ml.somee.com/swagger/index.html

или отправив POST json-запрос вида

```javascript
{
  "SentimentText" : "текст для анализа"
}
```
по адресу http://ml.somee.com/api/predict

!(https://github.com/Acronus32/SentimentAnalysisWebAPI/postman.png)
