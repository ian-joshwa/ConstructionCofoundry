using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectDefinition : ICustomEntityDefinition<ProjectDataModel>
    {
        public const string DefinitionCode = ProjectInfoProvider.DefinitionCode;
        string ICustomEntityDefinition.CustomEntityDefinitionCode => DefinitionCode;

        string ICustomEntityDefinition.Name => "Project";

        string ICustomEntityDefinition.NamePlural => "Projects";

        string ICustomEntityDefinition.Description => "Company Projects";

        bool ICustomEntityDefinition.ForceUrlSlugUniqueness => false;

        bool ICustomEntityDefinition.HasLocale => false;

        bool ICustomEntityDefinition.AutoGenerateUrlSlug => true;

        bool ICustomEntityDefinition.AutoPublish => false;
    }
}
