using Robust.Shared.GameStates;

namespace Content.Shared.Imperial.QAIAndroid.Systems;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class SeeingStaticComponent : Component
{
    [AutoNetworkedField]
    public float Multiplier = 1f;
}
