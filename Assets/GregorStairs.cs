using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregorStairs : Interactable
{
    [SerializeField] Transform _targetPosition;
    TransitionsController _transitionsController;
    private void Start()
    {
        base.Start();
        _transitionsController = FindObjectOfType<TransitionsController>();
    }
    public override void Interact()
    {
        StartCoroutine(CrFadeAndMove());
    }
    IEnumerator CrFadeAndMove()
    {
        yield return _transitionsController.coFadeToBlack(0.5f);
        FindObjectOfType<PlayerController>().transform.position = _targetPosition.position;
        yield return new WaitForSeconds(1f);
        yield return _transitionsController.coFadeFromBlack(0.5f);
    }
}
