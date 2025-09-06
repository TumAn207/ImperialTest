using Content.Shared.Alert;
using Content.Shared.Silicons.Borgs;
using Content.Shared.Whitelist;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Imperial.QAIAndroid.Components;

[RegisterComponent, NetworkedComponent, Access(typeof(SharedBorgSystem)), AutoGenerateComponentState]
public sealed partial class QAIAndroidChassisComponent : Component
{
    #region Brain
    [DataField("brainWhitelist")]
    public EntityWhitelist? BrainWhitelist;

    [DataField("brainContainerId")]
    public string BrainContainerId = "borg_brain";

    [ViewVariables(VVAccess.ReadWrite)]
    public ContainerSlot BrainContainer = default!;

    public EntityUid? BrainEntity => BrainContainer.ContainedEntity;
    #endregion

    #region Modules
    [DataField("moduleWhitelist")]
    public EntityWhitelist? ModuleWhitelist;

    [DataField("maxModules"), ViewVariables(VVAccess.ReadWrite)]
    public int MaxModules = 6;

    [DataField("moduleContainerId")]
    public string ModuleContainerId = "borg_module";

    [ViewVariables(VVAccess.ReadWrite)]
    public Container ModuleContainer = default!;

    public int ModuleCount => ModuleContainer.ContainedEntities.Count;
    #endregion

    [DataField("selectedModule"), AutoNetworkedField]
    public EntityUid? SelectedModule;

    [DataField]
    public ProtoId<AlertPrototype> BatteryAlert = "BorgBattery";

    [DataField]
    public ProtoId<AlertPrototype> NoBatteryAlert = "BorgBatteryNone";
}
