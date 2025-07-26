using Content.Server.Resist;
using Content.Shared.Humanoid;
using Content.Shared.Item;

namespace Content.Server._WL.AddHeightItem
{
    public sealed partial class AddHeightItemSystem : EntitySystem
    {
        [Dependency] private readonly SharedItemSystem _item = default!;

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            var query = EntityQueryEnumerator<AddHeightItemComponent, HumanoidAppearanceComponent>();
            while (query.MoveNext(out var uid, out var ahiComp, out var humanoid))
            {
                OnComp(uid, ahiComp, humanoid);
            }
        }
        private void OnComp(EntityUid uid, AddHeightItemComponent com, HumanoidAppearanceComponent profile)
        {

            var ahiHeight = com.Height;
            var humanoidHeight = profile.Height;

            if (ahiHeight >= humanoidHeight)
            {
                if (!EntityManager.HasComponent<ItemComponent>(uid))
                {
                    var itemComponent = new ItemComponent();
                    EntityManager.AddComponent(uid, itemComponent);

                    var multiHandedItem = new MultiHandedItemComponent();
                    EntityManager.AddComponent(uid, multiHandedItem);

                    var canEscapeInventory = new CanEscapeInventoryComponent
                    {
                        BaseResistTime = 1f
                    };
                    EntityManager.AddComponent(uid, canEscapeInventory);

                    SetMetadataItem(uid);

                }
            }
        }
        private void SetMetadataItem(EntityUid uid)
        {
            var size = "Ginormous";

            var item = Comp<ItemComponent>(uid);
            _item.SetSize(uid, size, item);
        }
    }
}
