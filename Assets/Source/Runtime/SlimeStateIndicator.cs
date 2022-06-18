using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Source.Slime_Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SlimeStateIndicator : SerializedMonoBehaviour
{
    [SerializeField]
    private Dictionary<SlimeState, (Color, string)> _dictionary;
    [SerializeField]
    private TextMeshProUGUI _stateName;
    private Image _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<Image>();
    }

    private void Start()
    {
        FindObjectOfType<Slime>().StateChanged += OnStateChanged;
    }

    private void OnStateChanged(SlimeState slimeState)
    {
        var state =
            _dictionary.FirstOrDefault(x => x.Key.GetType() == slimeState.GetType());
        _stateName.text = state.Value.Item2;
        _spriteRenderer.color = state.Value.Item1;
    }
}