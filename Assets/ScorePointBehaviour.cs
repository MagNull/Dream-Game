using Source.Slime_Components;
using UnityEngine;

public class ScorePointBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _scoreCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime _))
        {
            var canvas = _scoreCanvas.GetComponent<ActivateScoreCanvas>();
            canvas.UpdateScoreOnExit();
            Destroy(transform.gameObject);
        }
    }
}
