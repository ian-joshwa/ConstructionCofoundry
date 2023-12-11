using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Service
{
    public class ServiceCustomEntityDefinition : ICustomEntityDefinition<ServiceDataModel>
    {
        public const string DefinitionCode = ServiceInfoDataProvider.DefinitionCode;
        string ICustomEntityDefinition.CustomEntityDefinitionCode => DefinitionCode;

        string ICustomEntityDefinition.Name => "Service";

        string ICustomEntityDefinition.NamePlural => "Services";

        string ICustomEntityDefinition.Description => "Company Services";

        bool ICustomEntityDefinition.ForceUrlSlugUniqueness => false;

        bool ICustomEntityDefinition.HasLocale => false;

        bool ICustomEntityDefinition.AutoGenerateUrlSlug => true;

        bool ICustomEntityDefinition.AutoPublish => false;
    }
}
