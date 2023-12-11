using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectTagsDefinition : ICustomEntityDefinition<ProjectTagsDataModel>
    {
        public const string DefinitionCode = ProjectTagsInfoProvider.DefinitionCode;
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Project Tag";

        public string NamePlural => "Project Tags";

        public string Description => "Project Tags";

        public bool ForceUrlSlugUniqueness => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;
    }
}
