namespace iti.chalenge.api.domain.models
{
    public class ResponseModel
    {
        public bool isValid { get; set; }
        public string info { get; set; }

        public ResponseModel(bool isValid, string info)
        {
            this.isValid = isValid;
            this.info = info;
        }

        public ResponseModel() {}



    }
}