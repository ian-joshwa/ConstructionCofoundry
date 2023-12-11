using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
	public class WorkTaskDefinition : ICustomEntityDefinition<WorkTaskDataModel>
	{

		public const string DefinitionCode = WorkTaskInfoProvider.DefinitionCode;
		public string CustomEntityDefinitionCode => DefinitionCode;

		public string Name => "Work Task";

		public string NamePlural => "Work TaskList";

		public string Description => "List of Work Tasks";

		public bool ForceUrlSlugUniqueness => false;

		public bool HasLocale => false;

		public bool AutoGenerateUrlSlug => true;

		public bool AutoPublish => false;
	}
}
