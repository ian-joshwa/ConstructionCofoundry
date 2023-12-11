using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.WorkCategory
{
    public class WorkCategoryDefinition : ICustomEntityDefinition<WorkCategoryDataModel>
    {

        public const string DefinitionCode = WorkCategoryInfoProvider.DefinitionCode;

        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Work Category";

        public string NamePlural => "Work Categories";

        public string Description => "Categories of work that are performed on site.";

        public bool ForceUrlSlugUniqueness => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;
    }
}
