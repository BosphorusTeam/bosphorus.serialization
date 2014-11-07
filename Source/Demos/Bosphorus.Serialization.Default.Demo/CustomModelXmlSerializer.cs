using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default.Demo
{
    public class CustomModelXmlSerializer: IXmlSerializer<CustomModel>
    {
        private readonly IXmlSerializer<Customer> customerSerializer;

        public CustomModelXmlSerializer(IXmlSerializer<Customer> customerSerializer)
        {
            this.customerSerializer = customerSerializer;
        }

        public string Serialize(CustomModel model)
        {
            return string.Empty;
        }

        public CustomModel Deserialize(string input)
        {
            return null;
        }
    }
}
