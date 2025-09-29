using Content.Shared.Damage;
using Content.Shared.FixedPoint;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Imperial.QAIAndroid.Sweep;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(QAIAndroidTailSweepSystem))]
public sealed partial class QAIAndroidTailSweepComponent : Component
{
    [DataField, AutoNetworkedField]
    public FixedPoint2 PlasmaCost = 10;

    [DataField, AutoNetworkedField]
    public float Range = 1.5f;

    [DataField, AutoNetworkedField]
    public float KnockBackDistance = 1f;

    [DataField]
    public DamageSpecifier? Damage;

    [DataField, AutoNetworkedField]
    public TimeSpan ParalyzeTime = TimeSpan.FromSeconds(2);

    [DataField, AutoNetworkedField]
    public EntProtoId HitEffect = "CMEffectPunch";
}
