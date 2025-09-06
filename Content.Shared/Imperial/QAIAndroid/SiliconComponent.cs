using Robust.Shared.GameStates;
using Content.Shared.SimpleStation14.Silicon.Systems;
using Robust.Shared.Serialization.TypeSerializers.Implementations;
using Robust.Shared.Containers;

namespace Content.Shared.SimpleStation14.Silicon.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class SiliconComponent : Component
{
    [ViewVariables(VVAccess.ReadOnly)]
    public ChargeState ChargeState = ChargeState.Full;

    [ViewVariables(VVAccess.ReadOnly)]
    public float OverheatAccumulator = 0.0f;

    public TimeSpan LastDrainTime = TimeSpan.Zero;

    public bool Dead = false;

    [DataField("entityType", customTypeSerializer: typeof(EnumSerializer))]
    public Enum EntityType = SiliconType.Npc;

    [DataField("batteryPowered"), ViewVariables(VVAccess.ReadWrite)]
    public bool BatteryPowered = false;

    [DataField("batterySlot")]
    public string? BatterySlot = null;

    [DataField("drainPerSecond"), ViewVariables(VVAccess.ReadWrite)]
    public float DrainPerSecond = 50f;

    [DataField("chargeThresholdMid"), ViewVariables(VVAccess.ReadWrite)]
    public float? ChargeThresholdMid = 0.5f;

    /// <inheritdoc cref="ChargeThresholdMid"/>
    [DataField("chargeThresholdLow"), ViewVariables(VVAccess.ReadWrite)]
    public float? ChargeThresholdLow = 0.25f;

    /// <inheritdoc cref="ChargeThresholdMid"/>
    [DataField("chargeThresholdCritical"), ViewVariables(VVAccess.ReadWrite)]
    public float? ChargeThresholdCritical = 0.0f;


    [DataField("speedModifierThresholds", required: true)]
    public Dictionary<ChargeState, float> SpeedModifierThresholds = default!;
}
