using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectStockUpdateInfoDefinition : ICustomEntityDefinition<ProjectStockUpdateInfoDataModel>
    {
        public const string DefinitionCode = ProjectStockUpdateInfoProvider.Code;
        string ICustomEntityDefinition.CustomEntityDefinitionCode => DefinitionCode;

        string ICustomEntityDefinition.Name => "Project Stock Update";

        string ICustomEntityDefinition.NamePlural => "Project Stock Update";

        string ICustomEntityDefinition.Description => "stock updates of the projects";

        bool ICustomEntityDefinition.ForceUrlSlugUniqueness => false;

        bool ICustomEntityDefinition.HasLocale => false;

        bool ICustomEntityDefinition.AutoGenerateUrlSlug => true;

        bool ICustomEntityDefinition.AutoPublish => false;
    }
}
