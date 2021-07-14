using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using Newtonsoft.Json;
using SentimentAnalysis;

namespace SentimentAnalysisWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<SentimentData, SentimentPrediction> _predictionEnginePool;

        public PredictController(PredictionEnginePool<SentimentData, SentimentPrediction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<SentimentData> Post([FromBody] SentimentData input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (input.SentimentText=="")
            {
                input = new SentimentData()
                {
                    SentimentText = "Получен пустой запрос"
                };
            }

            SentimentPrediction prediction = _predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: input);
            
            string sentiment = GetPrediction(prediction.Probability);

            var response = new
            {
                SentimentText = input.SentimentText,
                Prediction = sentiment
            };

            return Ok(response);
        }

        public static string GetPrediction(double probability)
        {
            if (probability > 0.6) return "Positive";
            if (probability < 0.4) return "Negative";
            return "Neutral";
        }
    }
}
