using Robust.Shared.GameStates;

namespace Content.Shared._WL.Shuttles;

public sealed class RadarMarkerSystem : EntitySystem
{
    [Dependency] private readonly SharedPvsOverrideSystem _pvs = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RadarMarkerComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(EntityUid uid, RadarMarkerComponent component, ComponentStartup args)
    {
        _pvs.AddGlobalOverride(uid);
    }
}
