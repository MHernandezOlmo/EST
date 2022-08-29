using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorRobot : MonoBehaviour
{

    Vector2 minPoint;
    Vector2 maxPoint;
    RectTransform _rectTransform;
    Coroutine routine;
    EspejoController _espejoController;
    [SerializeField] List<RectTransform> _positions;
    int _pointCounter;
    private void Start()
    {
        _espejoController = FindObjectOfType<EspejoController>();
        minPoint = new Vector2(-652f, -182);
        maxPoint = new Vector2(652f, 182);
        _rectTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(()=>Kill());
        FindObjectOfType<EspejoController>().AddRobot();
        Appear();
    }

    public void Appear()
    {
        StartCoroutine(CrAppear());
    }

    public void Kill()
    {

        if (routine != null)
        {
            StopCoroutine(routine);
            StartCoroutine(CrDie());
        }
    }
    IEnumerator CrDie()
    {

        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / 0.2f);
        }
        transform.localScale = Vector3.zero;

        _espejoController.RobotKills++;
        if (FindObjectOfType<EspejoController>().robotsCount < 30)
        {
            FindObjectOfType<EspejoController>().AddRobot();
            yield return new WaitForSeconds(Random.Range(2, 5));
            Appear();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    IEnumerator CrAppear()
    {
        _rectTransform.anchoredPosition = _positions[_pointCounter].anchoredPosition;
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.2f);
        }
        transform.localScale = Vector3.one;
        routine = StartCoroutine(CrMove());
    }

    IEnumerator CrMove()
    {

        int nextCounter = (_pointCounter + 1) % _positions.Count;
        float timeToMove = Random.Range(0.75f, 1.5f);
        for(float i = 0; i< timeToMove; i += Time.deltaTime)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_positions[_pointCounter].anchoredPosition, _positions[nextCounter].anchoredPosition, i/timeToMove);
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(0.25f, 0.75f));
        _espejoController.CreateDirt(_rectTransform.anchoredPosition);
        _pointCounter++;
        _pointCounter = _pointCounter % _positions.Count;
        routine = StartCoroutine(CrMove());
    }
    
}
