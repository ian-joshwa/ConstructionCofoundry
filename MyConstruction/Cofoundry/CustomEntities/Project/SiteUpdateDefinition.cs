using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class SiteUpdateDefinition : ICustomEntityDefinition<SiteUpdateDataModel>
    {
        public const string DefinitionCode = SiteUpdateInfoDataProvider.Code;
        string ICustomEntityDefinition.CustomEntityDefinitionCode => DefinitionCode;

        string ICustomEntityDefinition.Name => "Project Site Update";

        string ICustomEntityDefinition.NamePlural => "Project  Site Updates";

        string ICustomEntityDefinition.Description => "Company Project  Site Updates";

        bool ICustomEntityDefinition.ForceUrlSlugUniqueness => false;

        bool ICustomEntityDefinition.HasLocale => false;

        bool ICustomEntityDefinition.AutoGenerateUrlSlug => true;

        bool ICustomEntityDefinition.AutoPublish => false;
    }
}
