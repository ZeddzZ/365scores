using Core.BaseItems;

namespace ApiModels.JsonPlaceholder
{
    [Serializable]
	public class Address : BaseModel
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }
}
