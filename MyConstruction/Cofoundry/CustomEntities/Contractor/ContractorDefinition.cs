using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Contractor
{
    public class ContractorDefinition : ICustomEntityDefinition<ContractorDataModel>
    {
        public const string DefinitionCode = ContractorInfoProvider.DefinitionCode;

        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Contractor";

        public string NamePlural => "Contractors";

        public string Description => "Contractors that provides services for construction.";

        public bool ForceUrlSlugUniqueness => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;
    }
}
