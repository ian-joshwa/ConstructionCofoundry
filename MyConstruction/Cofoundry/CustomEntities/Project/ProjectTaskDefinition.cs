using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectTaskDefinition : ICustomEntityDefinition<ProjectTaskDataModel>
    {
        public const string DefinitionCode = ProjectTaskInfoProvider.Code;
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Project Task List";

        public string NamePlural => "Projects Task List";

        public string Description => "List of all projects task";

        public bool ForceUrlSlugUniqueness => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;
    }
}
