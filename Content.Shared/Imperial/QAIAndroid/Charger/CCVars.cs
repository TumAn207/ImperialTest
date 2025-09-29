using Robust.Shared.Configuration;

namespace Content.Shared.QAIAndroid.CCVar;

[CVarDefs]
public sealed class SimpleStationCCVars
{
    #region Silicons
    public static readonly CVarDef<float> SiliconNpcUpdateTime =
        CVarDef.Create("silicon.npcupdatetime", 1.5f, CVar.SERVERONLY);
    #endregion Silicons
}
