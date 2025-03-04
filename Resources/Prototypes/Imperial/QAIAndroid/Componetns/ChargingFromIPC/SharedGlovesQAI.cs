using Content.Shared.Mind;
using Content.Shared.Objectives.Systems;

namespace Content.Server.QAIAndroid.Systems;

public sealed class GlovesQAI : SharedGlovesQAI ///Отредактировано. NinjaGlovesSystem
{
    [Dependency] private readonly SharedMindSystem _mind = default!;
    [Dependency] private readonly SharedObjectivesSystem _objectives = default!;
    [Dependency] private readonly SpaceNinjaSystem _ninja = default!;

    protected override void EnableGloves(Entity<NinjaGlovesComponent> ent, Entity<SpaceNinjaComponent> user)
    {
        base.EnableGloves(ent, user);



        foreach (var ability in ent.Comp.Abilities)
        {
            if (ability.Objective is not {} objId)
                continue;

            if (!_mind.TryFindObjective((mindId, mind), objId, out var obj))
            {
                Log.Error($"Ninja glove ability of {ent} referenced missing objective {ability.Objective} of {_mind.MindOwnerLoggingString(mind)}");
                continue;
            }

            if (!_objectives.IsCompleted(obj.Value, (mindId, mind)))
                EntityManager.AddComponents(user, ability.Components);
        }

        if (_ninja.GetNinjaBattery(user, out var battery, out var _))
        {
            var ev = new NinjaBatteryChangedEvent(battery.Value, suit);
            RaiseLocalEvent(user, ref ev);
            RaiseLocalEvent(suit, ref ev);
        }
    }
}
