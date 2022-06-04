using UnityEngine;

namespace Source.Slime_Components
{
    public class StoneState : SlimeState
    {
        public override string Name
        { get => "StoneState"; }
        public override void ActivateAbility()
        {
            
        }

        public override int GetDamageModificator(object source) => source.GetType().Equals(typeof(SpikeDamager)) ? 0 : 1;

        public override void Init(GameObject slimeGameObject) { }

        public override void Exit()
        {
            
        }
    }
}