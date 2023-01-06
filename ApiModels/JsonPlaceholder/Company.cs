using Core.BaseItems;

namespace ApiModels.JsonPlaceholder
{
    [Serializable]
	public class Company : BaseModel
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
