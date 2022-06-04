using UnityEngine;

namespace Source.Slime_Components
{
    public class SimpleState : SlimeState
    {
        public override string Name
        { get => "SimpleState"; }

        public override void ActivateAbility()
        {
            
        }

        public override int GetDamageModificator(object source) => 1;
        public override void Init(GameObject slimeGameObject)
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}