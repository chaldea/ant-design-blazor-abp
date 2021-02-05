using AntDesign.Abp.Pro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AntDesign.Abp.Pro.Permissions
{
    public class ProPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ProPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProResource>(name);
        }
    }
}
