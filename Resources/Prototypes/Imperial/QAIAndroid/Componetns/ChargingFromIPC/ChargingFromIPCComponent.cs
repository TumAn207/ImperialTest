using Content.Shared.Ninja.Systems;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared.QAIAndroid.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState] ///BatteryDrainerComponent
[Access(typeof(SharedBatteryDrainerSystem))]
public sealed partial class ChargingFromIPCComponent : Component
{
    [DataField, AutoNetworkedField]
    public EntityUid? BatteryUid;

    [DataField]
    public float DrainEfficiency = 0.001f; ///Компонент высасывания Энергии

    [DataField]
    public float DrainTime = 1f;

    [DataField]
    public SoundSpecifier SparkSound = new SoundCollectionSpecifier("sparks");
}
