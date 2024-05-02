using UnityEngine;

public class PlayButton : MenuButton
{
    [SerializeField] private string sceneToTransition;

    protected override void Clicked()
    {
        base.Clicked(); 
        SceneLoader.Instance.Transition(sceneToTransition, gameObject.scene.name);
    }
}
