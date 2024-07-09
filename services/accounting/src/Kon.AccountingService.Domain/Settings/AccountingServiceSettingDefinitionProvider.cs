using Volo.Abp.Settings;

namespace Kon.AccountingService.Settings;

public class AccountingServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AccountingServiceSettings.MySetting1));
    }
}
