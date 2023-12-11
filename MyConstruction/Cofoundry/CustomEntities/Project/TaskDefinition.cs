using Cofoundry.Domain;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
	public class TaskDefinition : ICustomEntityDefinition<TaskDataModel>
	{

		public const string DefinitionCode = TasksInfoProvider.DefinitionCode;
		public string CustomEntityDefinitionCode => DefinitionCode;

		public string Name => "Task";

		public string NamePlural => "Tasks";

		public string Description => "All Tasks";

		public bool ForceUrlSlugUniqueness => false;

		public bool HasLocale => false;

		public bool AutoGenerateUrlSlug => true;

		public bool AutoPublish => false;
	}
}
