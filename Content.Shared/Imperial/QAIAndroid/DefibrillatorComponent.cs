using Content.Shared.Damage;
using Content.Shared.DoAfter;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server.QAIAndroidMedical;

[RegisterComponent, NetworkedComponent]
public sealed partial class QAIAndroidDefibrillatorComponent : Component
{
    [DataField("zapHeal", required: true), ViewVariables(VVAccess.ReadWrite)]
    public DamageSpecifier ZapHeal = default!;

    [DataField("zapDamage"), ViewVariables(VVAccess.ReadWrite)]
    public int ZapDamage = 5;

    [DataField("writheDuration"), ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan WritheDuration = TimeSpan.FromSeconds(3);

    [DataField]
    public string DelayId = "defib-delay";

    [DataField]
    public TimeSpan ZapDelay = TimeSpan.FromSeconds(5);

    [DataField("doAfterDuration"), ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan DoAfterDuration = TimeSpan.FromSeconds(3);

    [DataField]
    public bool AllowDoAfterMovement = true;

    [DataField]
    public bool CanDefibCrit = true;

    [ViewVariables(VVAccess.ReadWrite), DataField("zapSound")]
    public SoundSpecifier? ZapSound = new SoundPathSpecifier("/Audio/Items/Defib/defib_zap.ogg");

    [ViewVariables(VVAccess.ReadWrite), DataField("chargeSound")]
    public SoundSpecifier? ChargeSound = new SoundPathSpecifier("/Audio/Items/Defib/defib_charge.ogg");

    [ViewVariables(VVAccess.ReadWrite), DataField("failureSound")]
    public SoundSpecifier? FailureSound = new SoundPathSpecifier("/Audio/Items/Defib/defib_failed.ogg");

    [ViewVariables(VVAccess.ReadWrite), DataField("successSound")]
    public SoundSpecifier? SuccessSound = new SoundPathSpecifier("/Audio/Items/Defib/defib_success.ogg");

    [ViewVariables(VVAccess.ReadWrite), DataField("readySound")]
    public SoundSpecifier? ReadySound = new SoundPathSpecifier("/Audio/Items/Defib/defib_ready.ogg");
}

[Serializable, NetSerializable]
public sealed partial class QAIDefibrillatorZapDoAfterEvent : SimpleDoAfterEvent
{

}
