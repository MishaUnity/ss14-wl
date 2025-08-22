using Content.Server.Resist;
using Content.Shared.Humanoid;
using Content.Shared.Item;
using Robust.Shared.Prototypes;

namespace Content.Server._WL.AddHeightItem
{
    public sealed partial class AddHeightItemSystem : EntitySystem
    {
        [Dependency] private readonly SharedItemSystem _item = default!;
        [Dependency] private readonly IPrototypeManager _proto = default!;
        public override void Initialize()
        {
            base.Initialize();

            SubscribeLocalEvent<AddHeightItemComponent, ComponentInit>(OnADHI);
        }
        /// <summary>
        /// Add item component depending on height
        /// </summary>
        private void OnADHI(EntityUid uid, AddHeightItemComponent com, ComponentInit args)
        {
            if (!TryComp<HumanoidAppearanceComponent>(uid, out var humanoid))
                return;

            if (!_proto.TryIndex(humanoid.Species, out var speciesProto))
                return;

            if (speciesProto.MaxItemHeight >= humanoid.Height)
            {
                if (!EntityManager.HasComponent<ItemComponent>(uid) &&
                    !EntityManager.HasComponent<MultiHandedItemComponent>(uid) &&
                    !EntityManager.HasComponent<CanEscapeInventoryComponent>(uid))
                {
                    var size = "Ginormous";

                    var itemComponent = new ItemComponent();
                    EntityManager.AddComponent(uid, itemComponent);
                    _item.SetSize(uid, size, itemComponent);

                    var multiHandedItem = new MultiHandedItemComponent();
                    EntityManager.AddComponent(uid, multiHandedItem);

                    var canEscapeInventory = new CanEscapeInventoryComponent
                    {
                        BaseResistTime = 1f
                    };
                    EntityManager.AddComponent(uid, canEscapeInventory);
                }
            }
        }
    }
}
