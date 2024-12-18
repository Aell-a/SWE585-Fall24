using UnityEngine;
using System.Collections;

public class CharacterTurn : MonoBehaviour
{
    public Animator animator; 
    public float animationDuration = 2f;

    private bool isTurning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isTurning)
        {
            StartCoroutine(Turn180(animationDuration));
        }
    }

    private IEnumerator Turn180(float duration)
    {
        isTurning = true;

        animator.SetTrigger("Turn");

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 180, 0));

        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            float progress = elapsedTime / duration;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;

        isTurning = false;

        animator.SetTrigger("EndTurn");
    }
}
