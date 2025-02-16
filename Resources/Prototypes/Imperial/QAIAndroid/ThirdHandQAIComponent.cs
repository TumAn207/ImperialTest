using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.TypeSerializers.Implementations;
using Robust.Shared.Serialization;
using Content.Shared.Hands.Components;
using Robust.Shared.ViewVariables;

namespace Content.Shared.QAIAndroid.Components
{
    [RegisterComponent]
    public sealed class AndroidThirdHandComponent : Component
    {
        /// <summary>
        /// Имя слота для третьей руки.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("handName")]
        public string HandName = "android_third_hand"; // Уникальное имя слота руки

        /// <summary>
        /// Путь к RSI файлу для спрайта самой руки.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("handSpritePath")]
        public string HandSpritePath = "Imperial/QAIAndroid/parts.rsi"; // Спрайт самой руки

        /// <summary>
        /// Состояние (state) спрайта руки.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("handSpriteState")]
        public string HandSpriteState = "manipulator4"; // Состояние спрайта руки

        /// <summary>
        /// Путь к RSI файлу для иконки слота руки.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("slotIconPath")]
        public string SlotIconPath = "Imperial/QAIAndroid/Hand slot image.rsi"; // Спрайт иконки

        /// <summary>
        /// Состояние (state) иконки слота руки.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("slotIconState")]
        public string SlotIconState = "manipulator"; // Состояние иконки
    }
}
