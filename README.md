# Unity - NotNullAttribute

The NotNullAttribute is a custom attribute that is used to support workflows in Unity that rely heavily on object references. By applying the `[NotNull]` attribute to public Object fields on MonoBehaviours we can get alerted when a field is not properly wired up in the Editor. This allows us to assume the field is not null.

The package comes with a drawer that renders NotNull fields in the Inspector with errors when null, and with an "*" next to their label to help identify required fields. It also includes a tool to help find NotNull violations, which can be run at launch time or as part of a build.

##Example Workflow
Our workflow for UI requires each root UI screen, such a Main Menu, to be its own prefab. This root prefab controls all of its children, including assigning on click events and text, etc. We assign the children directly to the root prefab object as public members, of say a UIMainMenu.cs script.

Here is an example of the script without a NotNull attribute:

```
public class UI_MainMenu
{
  public Button ContinueButton;
  
  void Awake ()
  {
    if (ContinueButton == null) {
      Debug.LogError ("ContinueButton not assigned on 
    }
  
     ContinueButton.onClick.AddListener ( ClickContinueButton );
  }
  ...
}
```
Every object that we need to link on this Main Menu script will need to have a null error check and debug log. You can see that it would get tedious to type out this boiler plate. After a while, it would be tempting to leave off the null check and error log altogether.

Adding the NotNull gives us several advantages over the previous code:

* Less boiler plate
  * By flagging the field as NotNull, we can remove the null check and alert, since we can be confident it will be wired up at edit time. 
* Better error handling
  * We will catch the null reference at edit / build time, rather than having to instantiate the object to discover the bug. 
  * It will also produce better error output, since we won't have to write an error log for every member.

Here is what the MainMenu script looks like with NotNull:

```
public class UI_MainMenu
{
  [NotNull]
  public Button ContinueButton;
  
  void Awake ()
  {
     ContinueButton.onClick.AddListener ( ClickContinueButton );
  }
  ...
}
```

##FAQ

* Why use this workflow instead of `GameObject.Find ("ObjectName")` or `FindComponentsInChildren<>`
  * TODO: Answer this in depth
