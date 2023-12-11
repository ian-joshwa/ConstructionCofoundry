using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.General
{
    public class StockDefinition : ICustomEntityDefinition<StockDataModel>
    {
        public const string DefinitionCode = StockInfoProvider.Code;
        string ICustomEntityDefinition.CustomEntityDefinitionCode => DefinitionCode;

        string ICustomEntityDefinition.Name => "Stock";

        string ICustomEntityDefinition.NamePlural => "Stock Type";

        string ICustomEntityDefinition.Description => "Company Stock Types";

        bool ICustomEntityDefinition.ForceUrlSlugUniqueness => false;

        bool ICustomEntityDefinition.HasLocale => false;

        bool ICustomEntityDefinition.AutoGenerateUrlSlug => true;

        bool ICustomEntityDefinition.AutoPublish => false;
    }
}
