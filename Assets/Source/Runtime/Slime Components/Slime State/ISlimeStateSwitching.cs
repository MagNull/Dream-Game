namespace Source.Slime_Components
{
    public interface ISlimeStateSwitching
    {
        void AddState<T>() where T : SlimeState;
        void SwitchState();
    }
}