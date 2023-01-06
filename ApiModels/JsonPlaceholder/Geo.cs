using Core.BaseItems;

namespace ApiModels.JsonPlaceholder
{
    [Serializable]
    public class Geo : BaseModel
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
