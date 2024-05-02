using UnityEngine;

public class ExitButton : MenuButton
{
    protected override void Clicked()
    {
        base.Clicked(); 
        Application.Quit(); 
    }
}
