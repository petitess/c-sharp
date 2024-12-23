Create Tooltip.razor
```razor
@code {
    private bool _isVisible;

    [Parameter]
    public string Text { get; set; }

    private void ShowTooltip() => _isVisible = true;
    private void HideTooltip() => _isVisible = false;
}

<div @onmouseover="ShowTooltip" @onmouseout="HideTooltip" style="display: inline-block; position: relative;">
    @ChildContent
    @if (_isVisible)
    {
        <div class="tooltip" style="position: absolute; background-color: #333; color: #fff; padding: 5px; border-radius: 4px; z-index: 100;">
            @Text
        </div>
    }
</div>

@code {
    [Parameter] public RenderFragment? ChildContent { get; set; }
}

<style>
    div.tooltip {
    visibility: visible;
    opacity: 1;
    transition: opacity 0.2s;
        width: 150px
    }
    div.tooltip:hover {
    visibility: visible;
    opacity: 1;
}
</style>
```

Create a Blazor Page:
```razor
@page "/tooltip-example"

<h3>Tooltip Example</h3>
<Tooltip Text="This is a tooltip!">
    <button>Hover over me!</button>
</Tooltip>
```
