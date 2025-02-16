using Content.Shared.Hands.Components;
using Robust.Shared.GameObjects;
using Content.Shared.Hands;
using Content.Shared.Hands.EntitySystems;
using Robust.Shared.IoC;
using Content.Shared.QAIAndroid.Components;
using Robust.Shared.Utility;
using Robust.Shared.Log;
using Robust.Shared.Containers;

namespace Content.Server.QAIAndroid.Systems
{
    public sealed class AndroidThirdHandSystem : EntitySystem
    {
        [Dependency] private readonly SharedHandsSystem _handsSystem = default!;

        public override void Initialize()
        {
            SubscribeLocalEvent<AndroidThirdHandComponent, ComponentStartup>(OnStartup);
            SubscribeLocalEvent<AndroidThirdHandComponent, ComponentShutdown>(OnShutdown);
        }

        private void OnStartup(EntityUid uid, AndroidThirdHandComponent component, ComponentStartup args)
        {
            if (!EntityManager.TryGetComponent(uid, out HandsComponent? handsComponent))
            {
                Logger.Error($"Entity {ToPrettyString(uid)} with AndroidThirdHandComponent has no HandsComponent.");
                return;
            }

            if (handsComponent.Hands.ContainsKey(component.HandName))
            {
                Logger.Warning($"Entity {ToPrettyString(uid)} already has a hand with name {component.HandName}.");
                return;
            }

            var hand = new Hand(uid, component.HandName)
            {
                Location = component.HandName,
                IsActive = true,
                UIElement = new Hand.HandUIElement()
                {
                    RsiPath = new ResourcePath(component.SlotIconPath),
                    RsiState = component.SlotIconState
                }
            };
            handsComponent.Hands.Add(component.HandName, hand);
            _handsSystem.AddHand(uid, hand, handsComponent);

            // Добавляем HandSpriteComponent для отображения спрайта руки
            var handSprite = EntityManager.AddComponent<HandSpriteComponent>(uid);
            handSprite.Hand = hand;
            handSprite.Location = component.HandName;
            handSprite.Layer = (int)HandVisualLayers.Default;
            handSprite.Sprite = component.HandSpritePath;
            handSprite.State = component.HandSpriteState; // <-- Добавлено состояние спрайта

            Dirty(handsComponent);

            Logger.Info($"Added Android Third Hand to {ToPrettyString(uid)}");
        }

        private void OnShutdown(EntityUid uid, AndroidThirdHandComponent component, ComponentShutdown args)
        {
            if (!EntityManager.TryGetComponent(uid, out HandsComponent? handsComponent))
            {
                return;
            }

            if (!handsComponent.Hands.ContainsKey(component.HandName))
            {
                return;
            }
            if (EntityManager.TryGetComponent(uid, out HandSpriteComponent? handSpriteComponent) && handSpriteComponent.Hand != null && handSpriteComponent.Hand.Name == component.HandName)
            {
                EntityManager.RemoveComponent(uid, handSpriteComponent);
            }
             _handsSystem.RemoveHand(uid, component.HandName, handsComponent);
             Dirty(handsComponent);

            Logger.Info($"Removed Android Third Hand from {ToPrettyString(uid)}");
        }
    }
}
