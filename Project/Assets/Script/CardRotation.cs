using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///　カードを回転させるプログラム
///　非同期でカードが回るようにしている
/// </summary>
public class CardRotation : MonoBehaviour
{
    public void GoRotation()
    {
        StartCoroutine(IEcardRotation());
    }

    private IEnumerator IEcardRotation()
    {
        Vector3 vec3 = new Vector3(gameObject.transform.localEulerAngles.x, 0, gameObject.transform.localEulerAngles.z);
        for (float i = 180; i >= 0; i-=2.5f)
        {
            gameObject.transform.localEulerAngles = vec3 + new Vector3(0, i, 0);
            yield return null;
        }
    }
}
