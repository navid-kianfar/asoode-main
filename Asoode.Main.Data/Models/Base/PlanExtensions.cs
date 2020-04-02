using Asoode.Main.Core.ViewModel.Membership;

namespace Asoode.Main.Data.Models.Base
{
    public static class PlanExtensions
    {
        public static PlanViewModel ToViewModel(this Plan plan)
        {
            return new PlanViewModel
            {
                Days = plan.Days,
                Description = plan.Description,
                Enabled = plan.Enabled,
                Id = plan.Id,
                Order = plan.Order,
                Picture = plan.Picture,
                Title = plan.Title,
                Type = plan.Type,
                Unit = plan.Unit,
                Users = plan.Users,
                AttachmentSize = plan.AttachmentSize,
                CanExtend = plan.CanExtend,
                ComplexGroup = plan.ComplexGroup,
                ComplexProject = plan.ComplexProject,
                CreatedAt = plan.CreatedAt,
                DiskSpace = plan.DiskSpace,
                OneTime = plan.OneTime,
                PlanCost = plan.PlanCost,
                SimpleGroup = plan.SimpleGroup,
                SimpleProject = plan.SimpleProject,
                UpdatedAt = plan.UpdatedAt,
                AdditionalGroupCost = plan.AdditionalGroupCost,
                AdditionalProjectCost = plan.AdditionalProjectCost,
                AdditionalSpaceCost = plan.AdditionalSpaceCost,
                AdditionalUserCost = plan.AdditionalUserCost,
                FeatureCustomField = plan.FeatureCustomField,
                FeatureTimeSpent = plan.FeatureTimeSpent,
                FeatureTimeValue = plan.FeatureTimeValue,
                FeatureTimeOff = plan.FeatureTimeOff,
                FeatureShift = plan.FeatureShift,
                FeatureReports = plan.FeatureReports,
                FeaturePayments = plan.FeaturePayments,
                FeatureChat = plan.FeatureChat,
                FeatureFiles = plan.FeatureFiles,
                FeatureWbs = plan.FeatureWbs,
                FeatureRoadMap = plan.FeatureRoadMap,
                FeatureTree = plan.FeatureTree,
                FeatureObjectives = plan.FeatureObjectives,
                FeatureSeasons = plan.FeatureSeasons,
                FeatureVote = plan.FeatureVote,
                FeatureSubTask = plan.FeatureSubTask,
                FeatureCalendar = plan.Calendar,
                FeatureKartabl = plan.Kartabl,
                FeatureBlocking = plan.Blocking,
                FeatureRelated = plan.Related
            };
        }
    }
}