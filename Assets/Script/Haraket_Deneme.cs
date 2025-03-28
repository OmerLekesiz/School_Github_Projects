using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public Vector3 pointA; // İlk nokta
    public Vector3 pointB; // İkinci nokta
    public float speed = 2f;

    private float t = 0f;

    private bool isFlipped = false;
    private bool facingRight = true; // Objeyi takip etmek için

    void Start()
{
    pointA = new Vector3(4.54f, 8.2f, -42.96f); // Başlangıç noktası
    pointB = new Vector3(57.11f, 8.2f, -37.41f); // Bitiş noktası
}


 void Update()
    {
        t += Time.deltaTime * speed;
        float pingPongValue = Mathf.PingPong(t, 1f);
        transform.position = Vector3.Lerp(pointA, pointB, pingPongValue);

        // Her yön değiştiğinde dönmesini sağla
        if ((pingPongValue >= 0.99f || pingPongValue <= 0.01f) && !isFlipped)
        {
            Flip();
            isFlipped = true; // Aynı frame içinde birden fazla dönüşü önler
        }
        else if (pingPongValue > 0.01f && pingPongValue < 0.99f)
        {
            isFlipped = false; // Yeniden dönüşe izin verir
        }
    }

    void Flip()
    {
        transform.eulerAngles += new Vector3(0, 180, 0);
    }
}