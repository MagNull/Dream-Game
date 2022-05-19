using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Slime_Components
{
    [RequireComponent(
        typeof(SlimeMovement),
        typeof(SlimeAnimator),
        typeof(Slime))]
    [RequireComponent(typeof(GroundChecking))]
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
            var slime = GetComponent<Slime>();
            var slimeAnimator = GetComponent<SlimeAnimator>();
            var slimeMovement = GetComponent<SlimeMovement>();
            var slimeHealth = new Health(_startHealth);
            _groundChecking = GetComponent<GroundChecking>();

            slime.Init(_slimeStates, slimeHealth, 
                GetComponentInChildren<SpriteRenderer>());
            slimeMovement.Init(GetComponent<Rigidbody2D>(),
                slime.GetSpeedModificator, slime.GetJumpPowerModificator, _groundChecking);
            slimeAnimator.Init(GetComponent<Animator>(), slimeMovement, slimeHealth, _groundChecking);

            _inputBindings.BindMovement(slimeMovement);
            _inputBindings.BindStateShifting(slime);
            _inputBindings.BindAbilityCast(slime);
        }
    }
}