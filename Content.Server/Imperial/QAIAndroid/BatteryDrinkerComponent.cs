namespace Content.Server.QAIAndroid.Power;

[RegisterComponent]
public sealed partial class BatteryDrinkerComponent : Component
{
    [DataField("drinkAll"), ViewVariables(VVAccess.ReadWrite)]
    public bool DrinkAll = false;

    [DataField("drinkSpeed"), ViewVariables(VVAccess.ReadWrite)]
    public float DrinkSpeed = 1.5f;

    [DataField("drinkMultiplier"), ViewVariables(VVAccess.ReadWrite)]
    public float DrinkMultiplier = 5f;

    [DataField("drinkAllMultiplier"), ViewVariables(VVAccess.ReadWrite)]
    public float DrinkAllMultiplier = 2.5f;
}
