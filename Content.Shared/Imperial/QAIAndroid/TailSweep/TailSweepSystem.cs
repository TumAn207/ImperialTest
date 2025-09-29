using Content.Shared.Coordinates;
using Content.Shared.Damage;
using Content.Shared.Effects;
using Content.Shared.Interaction;
using Content.Shared.Mobs.Components;
using Content.Shared.Stunnable;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;

namespace Content.Shared.Imperial.QAIAndroid.Sweep;

public sealed class QAIAndroidTailSweepSystem : EntitySystem
{
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedColorFlashEffectSystem _colorFlash = default!;
    [Dependency] private readonly DamageableSystem _damageable = default!;
    [Dependency] private readonly EntityLookupSystem _entityLookup = default!;
    [Dependency] private readonly INetManager _net = default!;
    [Dependency] private readonly RotateToFaceSystem _rotateTo = default!;
    [Dependency] private readonly SharedStunSystem _stun = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    private readonly HashSet<Entity<MobStateComponent>> _hit = new();

    public override void Initialize()
    {
        SubscribeLocalEvent<QAIAndroidTailSweepComponent, QAIAndroidTailSweepActionEvent>(OnQAIAndroidTailSweepAction);
    }

    private void OnQAIAndroidTailSweepAction(Entity<QAIAndroidTailSweepComponent> android, ref QAIAndroidTailSweepActionEvent args)
    {
        if (!TryComp(android, out TransformComponent? transform))
            return;

        var ev = new QAIAndroidTailSweepAttemptEvent();
        RaiseLocalEvent(android, ref ev);

        if (ev.Cancelled)
            return;

        args.Handled = true;

        EnsureComp<QAIAndroidSweepingComponent>(android);

        if (_net.IsClient)
            return;

        _hit.Clear();
        _entityLookup.GetEntitiesInRange(transform.Coordinates, android.Comp.Range, _hit);

        var origin = _transform.GetMapCoordinates(android);
        foreach (var mob in _hit)
        {
            //if (xeno.Comp.Damage is { } damage)
                //_damageable.TryChangeDamage(mob, _xeno.TryApplyXenoSlashDamageMultiplier(mob, damage), origin: xeno, tool: xeno);

            var filter = Filter.Pvs(mob, entityManager: EntityManager);
            _colorFlash.RaiseEffect(Color.Red, new List<EntityUid> { mob }, filter);
        }
    }


    public override void Update(float frameTime)
    {
        var query = EntityQueryEnumerator<QAIAndroidSweepingComponent, TransformComponent>();
        while (query.MoveNext(out var uid, out var sweeping, out var xform))
        {
            if (sweeping.NextRotation > _timing.CurTime)
                continue;

            if (sweeping.TotalRotations >= sweeping.MaxRotations)
            {
                RemCompDeferred<QAIAndroidSweepingComponent>(uid);
                continue;
            }

            sweeping.TotalRotations++;
            sweeping.NextRotation = _timing.CurTime + sweeping.Delay;
            sweeping.LastDirection ??= _transform.GetWorldRotation(xform).GetDir();

            var nextAngle = sweeping.LastDirection.Value.ToAngle() + Angle.FromDegrees(90);
            sweeping.LastDirection = nextAngle.GetDir();

            Dirty(uid, sweeping);

            _rotateTo.TryFaceAngle(uid, nextAngle, xform);
        }
    }

    public override void FrameUpdate(float frameTime)
    {
        var query = EntityQueryEnumerator<QAIAndroidSweepingComponent, TransformComponent>();
        while (query.MoveNext(out var uid, out var sweeping, out var xform))
        {
            if (sweeping.LastDirection is not { } direction)
                continue;

            _rotateTo.TryFaceAngle(uid, direction.ToAngle(), xform);
        }
    }
    public DamageSpecifier TryApplyandroidSlashDamageMultiplier(EntityUid target, DamageSpecifier baseDamage)
    {

        return baseDamage * ANDROID_SLASH_DAMAGE_MULT;
    }
    public const float ANDROID_SLASH_DAMAGE_MULT = 1.5f;
}

