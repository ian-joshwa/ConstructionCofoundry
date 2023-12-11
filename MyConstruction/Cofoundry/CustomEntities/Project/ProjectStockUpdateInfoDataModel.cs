using Cofoundry.Domain;
using MyConstruction.Cofoundry.CustomEntities.General;
using OctaLib.Plugins.MyConstruction.Domain;

namespace MyConstruction.Cofoundry.CustomEntities.Project
{
    public class ProjectStockUpdateInfoDataModel : IProjectStockUpdateInfo, ICustomEntityDataModel
    {
        [CustomEntity(ProjectDefinition.DefinitionCode)]
        public int ProjectId { get; set; }

        [ReadOnly]
        public DateTime StatusDate { get; } = DateTime.UtcNow;

        [CustomEntity(StockDefinition.DefinitionCode)]
        public int StockId { get; set; }
        public int Old { get; set; }
        public int New { get; set; }
        public int Used { get; set; }
        public int Remaining { get; set; }
    }
}
