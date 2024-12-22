public interface IBehavior
{
    void Enter(ActorCtrl ctrl);
    void Execute(ActorCtrl ctrl);
    void Exit(ActorCtrl ctrl);
}