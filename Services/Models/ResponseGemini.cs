using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Content
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class InputTokensByModality
    {
        public string modality { get; set; }
        public int tokens { get; set; }
    }

    public class ResponseGemini
    {
        public string id { get; set; }
        public string status { get; set; }
        public Usage usage { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string service_tier { get; set; }
        public List<Step> steps { get; set; }
        public string @object { get; set; }
        public string model { get; set; }
    }

    public class Step
    {
        public string signature { get; set; }
        public string type { get; set; }
        public List<Content> content { get; set; }
    }

    public class Usage
    {
        public int total_tokens { get; set; }
        public int total_input_tokens { get; set; }
        public List<InputTokensByModality> input_tokens_by_modality { get; set; }
        public int total_cached_tokens { get; set; }
        public int total_output_tokens { get; set; }
        public int total_tool_use_tokens { get; set; }
        public int total_thought_tokens { get; set; }
        public int raw_prompt_token { get; set; }
    }


}
