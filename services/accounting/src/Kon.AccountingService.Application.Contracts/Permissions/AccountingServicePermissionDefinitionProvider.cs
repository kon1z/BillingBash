using Kon.AccountingService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kon.AccountingService.Permissions;

public class AccountingServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AccountingServicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AccountingServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AccountingServiceResource>(name);
    }
}
