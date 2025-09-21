using JetBrains.Annotations;
using Robust.Client.GameObjects;

namespace Content.Client._WL.DynamicText;

[UsedImplicitly]
public sealed class DynamicTextBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private DynamicTextWindow? _window;

    public DynamicTextBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }
    protected override void Open()
    {
        base.Open();

        _window = new DynamicTextWindow();
        _window.OnClose += Close;
        _window.OpenCentered();
    }
}
