using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared._WL.MetamorphosisSlime;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class MetamorphosisSlimeComponent : Component
{
    [DataField]
    public EntProtoId MetamorphActionId = "ActionSlimeMetamorphosis";

    [DataField, AutoNetworkedField]
    public EntityUid? MetamorphAction;

    [DataField("morph")]
    public HashSet<string> Morph = new();

    //[DataField]

}
[Serializable, NetSerializable]
public enum MetamorfSlimeUiKey : byte
{
    Key
}
