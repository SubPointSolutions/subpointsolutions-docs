using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;

namespace SPMeta2.Docs.ProvisionSamples.Definitions
{
    public static class DocLists
    {
        #region properties

        public static ListDefinition GeneralReports = new ListDefinition
        {
            Title = "General Reports",
            Description = "General reports register.",
            CustomUrl = "general-reports",
            TemplateType = BuiltInListTemplateTypeId.DocumentLibrary
        };

        public static class HRLists
        {
            public static ListDefinition Poicies = new ListDefinition
            {
                Title = "Policies",
                Description = "Policies register.",
                CustomUrl = "policies",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary
            };

            public static ListDefinition Procedures = new ListDefinition
            {
                Title = "Procedures",
                Description = "Procedures register",
                CustomUrl = "procedures",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary
            };

            public static ListDefinition AnnualReviews = new ListDefinition
            {
                Title = "Annual reviews",
                Description = "Annual reviews.",
                CustomUrl = "procedures",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary
            };
        }

        public static class DepartmentsLists
        {
            public static ListDefinition TeamTasks = new ListDefinition
            {
                Title = "Team Tasks",
                Description = "Shared tasks for an IT team.",
                CustomUrl = "team-tasks",
                TemplateType = BuiltInListTemplateTypeId.Tasks
            };

            public static ListDefinition TeamEvents = new ListDefinition
            {
                Title = "Team Events",
                Description = "Shared events for an IT team.",
                CustomUrl = "team-events",
                TemplateType = BuiltInListTemplateTypeId.Events
            };

            public static ListDefinition IssueRegister = new ListDefinition
            {
                Title = "Issue Register",
                Description = "Shared events for an IT team.",
                CustomUrl = "shared-issues",
                TemplateType = BuiltInListTemplateTypeId.IssueTracking
            };
        }

        public static class AboutUsLists
        {
            public static ListDefinition OurClients = new ListDefinition
            {
                Title = "Our Clients",
                Description = "Client list.",
                CustomUrl = "our-clients",
                TemplateType = BuiltInListTemplateTypeId.Contacts
            };
            public static ListDefinition ManagementTeam = new ListDefinition
            {
                Title = "Management Team",
                Description = "Management team contacts.",
                CustomUrl = "management-team",
                TemplateType = BuiltInListTemplateTypeId.Contacts
            };
        }

        #endregion
    }
}
