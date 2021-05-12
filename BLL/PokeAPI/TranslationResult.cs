using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BLL.PokeAPI
{
    public class TranslationResponse
    {
        [JsonProperty("success")]
        public TranslationResult TranslationResult { get; set; }
        [JsonProperty("contents")]
        public TranslatedContents TranslatedContents { get; set; }
    }

    public class TranslationResult
    {
        public int Total { get; set; }
    }

    public class TranslatedContents
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }

}
