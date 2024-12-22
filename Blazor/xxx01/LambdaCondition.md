```razor
<span @onclick="@(e => { if (IsActive) Go.DoSomething("please");})">
    @s
</span>
```
```razor
@onclick=@(Active?() => Go.DoSomething:null)
```
```razor
<button @onclick="ChangeBtn"
class=@(Dark ? "btn btn-warning" : "btn btn-secondary")>
    Toggle Dark/Light Mode
</button>

@code {
    bool Dark = false;
    private void ChangeBtn()
    {
        Dark = Dark ? false : true;
    }
}
```
