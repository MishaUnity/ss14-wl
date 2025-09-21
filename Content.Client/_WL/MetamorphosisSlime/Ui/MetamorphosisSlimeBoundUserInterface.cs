using Content.Shared._WL.MetamorphosisSlime;
using Content.Shared.Radio;
using Content.Shared.Radio.Components;
using JetBrains.Annotations;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface;

namespace Content.Client._WL.MetamorphosisSlime.Ui;

[UsedImplicitly]
public sealed class MetamorphosisSlimeBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private MetamorphosisSlimeMenu? _menu;

    public MetamorphosisSlimeBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {

    }

    protected override void Open()
    {
        base.Open();

        //var currentEmotion = PAIEmotion.Neutral;
        //if (EntMan.TryGetComponent<PAIEmotionComponent>(Owner, out var emotionComp))
        //    currentEmotion = emotionComp.CurrentEmotion;

        _menu = this.CreateWindow<MetamorphosisSlimeMenu>();

        if (EntMan.TryGetComponent(Owner, out MetamorphosisSlimeComponent? Metamorph))
        {
            _menu.Update((Owner, Metamorph));
        }

        //_menu = new MetamorphosisSlimeMenu();
        //_menu.OpenCentered();
        //_menu.OnClose += Close;
        //_menu.OnEmotionSelected += OnEmotionSelected;
    }

    public void Update(Entity<MetamorphosisSlimeComponent> ent)
    {
        _menu?.Update(ent);
    }
}
