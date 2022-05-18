using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Slime_Components
{
    [RequireComponent(
        typeof(SlimeMovement),
        typeof(SlimeAnimator),
        typeof(SlimeStateMachine))]
    [RequireComponent(typeof(SlimeHealth), typeof(GroundChecking))]
    public class SlimeCompositionRoot : SerializedMonoBehaviour
    {
        [SerializeField]
        private int _startHealth;
        [SerializeField]
        private List<SlimeState> _slimeStates;
        [SerializeField]
        private InputBindings _inputBindings;
        [SerializeField]
        private GroundChecking _groundChecking;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            DestroyCopies();
            Compose();
            DontDestroyOnLoad(gameObject);
        }

        private void DestroyCopies()
        {
            var slimeCompositeRoot = FindObjectOfType<SlimeCompositionRoot>();
            if (slimeCompositeRoot != this)
                Destroy(slimeCompositeRoot);
        }

        private void Compose()
        {
            var slimeStateMachine = GetComponent<SlimeStateMachine>();
            var slimeAnimator = GetComponent<SlimeAnimator>();
            var slimeMovement = GetComponent<SlimeMovement>();
            var slimeHealth = GetComponent<SlimeHealth>();
            _groundChecking = GetComponent<GroundChecking>();

            slimeStateMachine.Init(_slimeStates, GetComponentInChildren<SpriteRenderer>());
            slimeHealth.Init(_startHealth, slimeStateMachine);
            slimeMovement.Init(GetComponent<Rigidbody2D>(), 
                slimeStateMachine.GetSpeedModificator,
                slimeStateMachine.GetJumpPowerModificator);
            slimeAnimator.Init(GetComponent<Animator>(), slimeMovement, slimeHealth, _groundChecking);

            _inputBindings.BindMovement(slimeMovement);
            _inputBindings.BindStateShifting(slimeStateMachine);
        }
    }
}