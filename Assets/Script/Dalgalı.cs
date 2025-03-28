using UnityEngine;

public class MoveWithWaveEffect : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    public float waveHeight = 0.5f; // Dalga yüksekliği
    public float waveFrequency = 2f; // Dalga frekansı

    private float t = 0f;
    private bool isFlipped = false;


    void Update()
    {
        t += Time.deltaTime * speed;
        float pingPongValue = Mathf.PingPong(t, 1f);

        // İleri geri hareket
        Vector3 newPos = Vector3.Lerp(pointA, pointB, pingPongValue);

        // Yukarı-aşağı dalga efekti (Sin fonksiyonu ile)
        newPos.y += Mathf.Sin(Time.time * waveFrequency) * waveHeight;

        transform.position = newPos;

        // Yön değiştirdiğinde döndür
        if ((pingPongValue >= 0.99f || pingPongValue <= 0.01f) && !isFlipped)
        {
            Flip();
            isFlipped = true;
        }
        else if (pingPongValue > 0.01f && pingPongValue < 0.99f)
        {
            isFlipped = false;
        }
    }

    void Flip()
    {
        transform.eulerAngles += new Vector3(0, 180, 0);
            // Eğer şu anki yön 0 ise 180 yap, eğer 180 ise 0 yap
    float newYRotation = (transform.eulerAngles.y == 0) ? 180 : 0;
    transform.eulerAngles = new Vector3(0, newYRotation, 0);
    }
}