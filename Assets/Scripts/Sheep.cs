using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float speed;  // Adjust this to control the speed of movement

    private bool canMove = false;

    Vector2 lastClickedPos;

    public GameObject vfxPowerUp;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            canMove = true;
        }

        if (canMove && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

            Vector2 direction = new Vector2(lastClickedPos.x - transform.position.x, lastClickedPos.y - transform.position.y);

            transform.up = direction;
        }
        else
        {
            canMove = false;
        }
    }

    private void OnMouseDown()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Block"))
        {
            canMove = false;
        }

        if (collision != null && collision.gameObject.CompareTag("Wolf"))
        {
            GameManager.Instance.ResetGame();
        }

        if (collision != null && collision.gameObject.CompareTag("Goal"))
        {
            GameManager.Instance.CheckLevelUp();
        }

        if (collision != null && collision.gameObject.CompareTag("PowerUp"))
        {
            GameObject vfx = Instantiate(vfxPowerUp, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            collision.gameObject.SetActive(false);
            speed *= 1.5f;
        }
    }
}
