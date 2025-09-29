using Content.Server.QAIAndroidMedical;
using Content.Shared.Inventory;

namespace Content.Shared.Medical;

[ByRefEvent]
public readonly record struct QAIAndroidTargetDefibrillatedEvent(EntityUid User, Entity<QAIAndroidDefibrillatorComponent> Defibrillator);

public abstract class QAIAndroidBeforeDefibrillatorZapsEvent : CancellableEntityEventArgs, IInventoryRelayEvent
{
    public SlotFlags TargetSlots { get; } = SlotFlags.WITHOUT_POCKET;
    public EntityUid EntityUsingDefib;
    public readonly EntityUid Defib;
    public EntityUid DefibTarget;

    public QAIAndroidBeforeDefibrillatorZapsEvent(EntityUid entityUsingDefib, EntityUid defib, EntityUid defibTarget)
    {
        EntityUsingDefib = entityUsingDefib;
        Defib = defib;
        DefibTarget = defibTarget;
    }
}

public sealed class QAIAndroidSelfBeforeDefibrillatorZapsEvent : BeforeDefibrillatorZapsEvent
{
    public QAIAndroidSelfBeforeDefibrillatorZapsEvent(EntityUid entityUsingDefib, EntityUid defib, EntityUid defibtarget) : base(entityUsingDefib, defib, defibtarget) { }
}

public sealed class QAIAndroidTargetBeforeDefibrillatorZapsEvent : BeforeDefibrillatorZapsEvent
{
    public QAIAndroidTargetBeforeDefibrillatorZapsEvent(EntityUid entityUsingDefib, EntityUid defib, EntityUid defibtarget) : base(entityUsingDefib, defib, defibtarget) { }
}
