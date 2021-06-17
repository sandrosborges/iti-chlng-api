
namespace iti.chalenge.api.domain.models
{
    public class RuleModel
    {
        public string regexPatern { get; set; }
        public string info { get; set; }

        public RuleModel(string regexPatern, string ruleInfo)
        {
            this.regexPatern = regexPatern;
            this.info = ruleInfo;
        }
    }
}