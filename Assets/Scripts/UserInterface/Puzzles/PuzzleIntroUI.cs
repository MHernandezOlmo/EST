using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleIntroUI : MonoBehaviour
{
    const float SPEED = 2f;
    const float OFFSET = 1f;

    [Header("Deps")]
    public Button startBtn;
    public RectTransform introPanel;

    void Start() => startBtn.onClick.AddListener( () =>
    {
        StartCoroutine(HideIntroPanel());
    });
    
    IEnumerator HideIntroPanel()
    {
        Vector3 screenTopBorderPos = introPanel.position.With(y: GetComponent<RectTransform>().position.y * 3f);
        Vector3 offScreenPos = screenTopBorderPos + OFFSET.Up();

        while(introPanel.position.y <= screenTopBorderPos.y)
        {
            introPanel.position = Vector3.Lerp(introPanel.position, offScreenPos, SPEED * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}