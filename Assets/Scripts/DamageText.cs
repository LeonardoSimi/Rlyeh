using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

    public Text dmgText;
    public EnemyAI enemyAI;
    public float fadeOutTime = 2.0f;

    // Use this for initialization
    void Start () {

        dmgText = this.GetComponent<Text>();
        enemyAI = GetComponentInParent<EnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
        showDamage();
        FadeOut();
        transform.Translate(Vector3.up * Time.deltaTime);

    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
        if (text.color == Color.clear)
        {
            Destroy(this.gameObject);
        }
    }

    private void showDamage()
    {
        dmgText.text = enemyAI.selfDamage.ToString();
    }
}

