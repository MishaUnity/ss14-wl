using Content.Server.Actions;
using Content.Shared._WL.MetamorphosisSlime;
using Robust.Server.GameObjects;

namespace Content.Server._WL.MetamorphosisSlime;

public sealed partial class MetamorphosisSlimeSystem : EntitySystem
{
    [Dependency] private readonly UserInterfaceSystem _ui = default!;
    [Dependency] private readonly ActionsSystem _actions = default!;

    public override void Initialize()
    {
        base.Initialize();

        //SubscribeLocalEvent<MetamorphosisSlimeComponent, >
        SubscribeLocalEvent<MetamorphosisSlimeComponent, MapInitEvent>(OnMetamorhMapInit);
        SubscribeLocalEvent<MetamorphosisSlimeComponent, ComponentShutdown>(OnMetamorhShutdown);

    }

    private void OnMetamorhMapInit(EntityUid uid, MetamorphosisSlimeComponent component, MapInitEvent args)
    {
        _actions.AddAction(uid, ref component.MetamorphAction, component.MetamorphActionId, uid);
    }

    private void OnMetamorhShutdown(EntityUid uid, MetamorphosisSlimeComponent component, ComponentShutdown args)
    {
        _actions.RemoveAction(uid, component.MetamorphAction);
    }


    private void OnMetamorph()
    {

    }
}
