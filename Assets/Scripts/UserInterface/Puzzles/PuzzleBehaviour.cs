using UnityEngine;

public abstract class PuzzleBehaviour : MonoBehaviour
{
    [Header("Deps")]
    public PuzzleIntroUI introUIPrefab;
    public PuzzleExitUI exitUIPrefab;
    public PuzzleWinUI winUIPrefab;
    public PuzzleGameOverUI gameOverUIPrefab;

    protected PuzzleExitUI exitUI;

    protected void Awake()
    {
        gameObject.SetActive(false);

        Instantiate(introUIPrefab).startBtn.onClick.AddListener( () =>
        {
            gameObject.SetActive(true);
        });

        exitUI = Instantiate(exitUIPrefab.gameObject).GetComponent<PuzzleExitUI>();
    }

    protected void ShowWin()
    {
        exitUI.Close();
        exitUI.exitBtn.interactable = false;
        Instantiate(winUIPrefab);
    }

    protected void ShowGameOver()
    {
        exitUI.Close();
        exitUI.exitBtn.interactable = false;
        Instantiate(gameOverUIPrefab);
    }
}
