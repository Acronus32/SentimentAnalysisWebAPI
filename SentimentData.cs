// <SnippetAddUsings>
using Microsoft.ML.Data;
using System.Collections.Generic;
// </SnippetAddUsings>

namespace SentimentAnalysis
{
    // <SnippetDeclareTypes>
    public class SentimentData
    {
        [LoadColumn(0)]
        public string SentimentText { set; get; }
        [LoadColumn(1), ColumnName("Label")]
        public bool Sentiment { set; get; }
    }

    public class SentimentPrediction : SentimentData
    {

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}