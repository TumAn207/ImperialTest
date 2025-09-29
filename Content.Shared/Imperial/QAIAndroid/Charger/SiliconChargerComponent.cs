using Content.Shared.Storage.Components;
using Content.Shared.StepTrigger.Components;
using Robust.Shared.Audio;

namespace Content.Shared.QAIAndroid.Silicon;

[RegisterComponent]
public sealed partial class SiliconChargerComponent : Component
{
    public bool Active = false;

    public TimeSpan WarningTime = TimeSpan.Zero;

    public float PartsChargeMulti = 1.2f;


    [DataField("soundLoop")]
    public SoundSpecifier SoundLoop = new SoundPathSpecifier("/Audio/Machines/microwave_loop.ogg");

    [DataField("chargeMulti"), ViewVariables(VVAccess.ReadWrite)]
    public float ChargeMulti = 50f;

    [DataField("minChargeSize"), ViewVariables(VVAccess.ReadWrite)]
    public int MinChargeSize = 1000;

    [DataField("minChargeTime"), ViewVariables(VVAccess.ReadWrite)]
    public float MinChargeTime = 10f;

    [DataField("targetTemp"), ViewVariables(VVAccess.ReadWrite)]
    public float TargetTemp = 373.15f;

    [DataField("damageType")]
    public string DamageType = "Shock";

    [DataField("upgradePartsMulti"), ViewVariables(VVAccess.ReadWrite)]
    public float UpgradePartsMulti = 0.6f;

    [DataField("chargeSpeedPart")]
    public string ChargeSpeedPart = "Capacitor";

    [DataField("chargeEfficiencyPart")]
    public string ChargeEfficiencyPart = "Manipulator";


    [DataField("overheatString")]
    public string OverheatString = "silicon-charger-overheatwarning";

    [ViewVariables(VVAccess.ReadOnly)]
    public List<EntityUid> PresentEntities = new List<EntityUid>();

    [DataField("maxEntities"), ViewVariables(VVAccess.ReadWrite)]
    public int MaxEntities = 1;
}
