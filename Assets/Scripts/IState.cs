using System.Drawing;

public interface IState
{
    void Tick();
    void OnEnter();
    void OnExit();
    public UnityEngine.Color GizmoColor();
}