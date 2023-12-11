using Cofoundry.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using OctaLib.Plugins.MyConstruction.Data;

namespace MyConstruction.Cofoundry.ApiCalls
{
    public class UserApiListOptions : IListOptionApiSource
    {

        public string Path => "/admin/api/users";

        public string NameField => "text";

        public string ValueField => "value";

    }
}
