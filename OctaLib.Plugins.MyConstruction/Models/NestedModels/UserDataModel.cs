using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using MyConstruction.Cofoundry.ApiCalls;
using OctaLib.Plugins.MyConstruction.Common.Enum;

namespace OctaLib.Plugins.MyConstruction.Models.NestedModels
{
    public class UserDataModel : INestedDataModel
    {
        [PreviewTitle]
        [Required]
        [SelectList(typeof(UserApiListOptions), DefaultItemText = "-- Select User --")]
        public string Username { get; set; }


        [PreviewDescription]
        [Required]
        [SelectList(typeof(ProjectRoles), DefaultItemText = "-- Select Project Role --")]
        public ProjectRoles ProjectRole { get; set; }

    }
}
