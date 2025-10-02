using Robust.Shared.GameStates;

namespace Content.Shared._WL.Shuttles;

[NetworkedComponent, RegisterComponent]
public sealed class RadarMarkerComponent : Component
{
    [DataField]
    public bool Visible = true;
}
