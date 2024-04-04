using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camshift : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform target;
    [SerializeField] private Transform top;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform bot;
    [SerializeField] private Transform spawner1;
    [SerializeField] private Transform spawner2;
    [SerializeField] private Transform spawner3;
    [SerializeField] private Transform spawner4;
    public int updown;
    public int leftright;
    private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;
    public int next;
    public float followSmooth;
    public int followV;

    // Update is called once per frame
    void Update()
    {
        campJump();

    }




    void campJump()
    {
        if (target.position.y >= top.position.y)
        {

            Vector2 newTop = new Vector2(top.position.x, top.position.y + next);
            Vector2 newRight = new Vector2(right.position.x, right.position.y + next);
            Vector2 newLeft = new Vector2(left.position.x, left.position.y + next);
            Vector2 newBot = new Vector2(bot.position.x, bot.position.y + next);
            Vector2 newSpawner1 = new Vector2(spawner1.position.x, spawner1.position.y + next);
            Vector2 newSpawner2 = new Vector2(spawner2.position.x, spawner2.position.y + next);
            Vector2 newSpawner3 = new Vector2(spawner3.position.x, spawner3.position.y + next);
            Vector2 newSpawner4 = new Vector2(spawner4.position.x, spawner4.position.y + next);
            //spawner1.position = Vector3.SmoothDamp(spawner1.position, newSpawner1, ref velocity, smoothTime);
            //spawner2.position = Vector3.SmoothDamp(spawner2.position, newSpawner2, ref velocity, smoothTime);
            //spawner3.position = Vector3.SmoothDamp(spawner3.position, newSpawner3, ref velocity, smoothTime);
            //spawner4.position = Vector3.SmoothDamp(spawner4.position, newSpawner4, ref velocity, smoothTime);
            top.position = Vector3.SmoothDamp(top.position, newTop, ref velocity, smoothTime);
            left.position = Vector3.SmoothDamp(left.position, newLeft, ref velocity, smoothTime);
            right.position = Vector3.SmoothDamp(right.position, newRight, ref velocity, smoothTime);
            bot.position = Vector3.SmoothDamp(bot.position, newBot, ref velocity, smoothTime);

            Vector3 targetPosition2 = new Vector3(transform.position.x, transform.position.y + next, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, smoothTime);


        }
        if (target.position.y <= bot.position.y)
        {

            Vector2 newTop = new Vector2(top.position.x, top.position.y - next);
            Vector2 newRight = new Vector2(right.position.x, right.position.y - next);
            Vector2 newLeft = new Vector2(left.position.x, left.position.y - next);
            Vector2 newBot = new Vector2(bot.position.x, bot.position.y - next);
            Vector2 newSpawner1 = new Vector2(spawner1.position.x, spawner1.position.y - next);
            Vector2 newSpawner2 = new Vector2(spawner2.position.x, spawner2.position.y - next);
            Vector2 newSpawner3 = new Vector2(spawner3.position.x, spawner3.position.y - next);
            Vector2 newSpawner4 = new Vector2(spawner4.position.x, spawner4.position.y - next);
            //spawner1.position = Vector3.SmoothDamp(spawner1.position, newSpawner1, ref velocity, smoothTime);
            //spawner2.position = Vector3.SmoothDamp(spawner2.position, newSpawner2, ref velocity, smoothTime);
            //spawner3.position = Vector3.SmoothDamp(spawner3.position, newSpawner3, ref velocity, smoothTime);
            //spawner4.position = Vector3.SmoothDamp(spawner4.position, newSpawner4, ref velocity, smoothTime);
            top.position = Vector3.SmoothDamp(top.position, newTop, ref velocity, smoothTime);
            left.position = Vector3.SmoothDamp(left.position, newLeft, ref velocity, smoothTime);
            right.position = Vector3.SmoothDamp(right.position, newRight, ref velocity, smoothTime);
            bot.position = Vector3.SmoothDamp(bot.position, newBot, ref velocity, smoothTime);
            Vector3 targetPosition2 = new Vector3(transform.position.x, transform.position.y - next, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, smoothTime);
        }
        else if (target.position.x <= left.position.x)
        {
            Vector2 newSpawner1 = new Vector2(spawner1.position.x - leftright, spawner1.position.y);
            Vector2 newSpawner2 = new Vector2(spawner2.position.x - leftright, spawner2.position.y);
            Vector2 newSpawner3 = new Vector2(spawner3.position.x - leftright, spawner3.position.y);
            Vector2 newSpawner4 = new Vector2(spawner4.position.x - leftright, spawner4.position.y);
            //spawner1.position = Vector3.SmoothDamp(spawner1.position, newSpawner1, ref velocity, smoothTime);
            //spawner2.position = Vector3.SmoothDamp(spawner2.position, newSpawner2, ref velocity, smoothTime);
            //spawner3.position = Vector3.SmoothDamp(spawner3.position, newSpawner3, ref velocity, smoothTime);
            //spawner4.position = Vector3.SmoothDamp(spawner4.position, newSpawner4, ref velocity, smoothTime);

            Vector2 newTop = new Vector2(top.position.x - leftright, top.position.y);
            Vector2 newRight = new Vector2(right.position.x - leftright, right.position.y);
            Vector2 newLeft = new Vector2(left.position.x - leftright, left.position.y);
            Vector2 newBot = new Vector2(bot.position.x - leftright, bot.position.y);
            top.position = Vector3.SmoothDamp(top.position, newTop, ref velocity, smoothTime);
            left.position = Vector3.SmoothDamp(left.position, newLeft, ref velocity, smoothTime);
            right.position = Vector3.SmoothDamp(right.position, newRight, ref velocity, smoothTime);
            bot.position = Vector3.SmoothDamp(bot.position, newBot, ref velocity, smoothTime);

            Vector3 targetPosition2 = new Vector3(transform.position.x - leftright, transform.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, smoothTime);
        }
        else if (target.position.x >= right.position.x)
        {
            Vector2 newSpawner1 = new Vector2(spawner1.position.x + leftright, spawner1.position.y);
            Vector2 newSpawner2 = new Vector2(spawner2.position.x + leftright, spawner2.position.y);
            Vector2 newSpawner3 = new Vector2(spawner3.position.x + leftright, spawner3.position.y);
            Vector2 newSpawner4 = new Vector2(spawner4.position.x + leftright, spawner4.position.y);
            //spawner1.position = Vector3.SmoothDamp(spawner1.position, newSpawner1, ref velocity, smoothTime);
            //spawner2.position = Vector3.SmoothDamp(spawner2.position, newSpawner2, ref velocity, smoothTime);
            //spawner3.position = Vector3.SmoothDamp(spawner3.position, newSpawner3, ref velocity, smoothTime);
            //spawner4.position = Vector3.SmoothDamp(spawner4.position, newSpawner4, ref velocity, smoothTime);

            Vector2 newTop = new Vector2(top.position.x + leftright, top.position.y);
            Vector2 newRight = new Vector2(right.position.x + leftright, right.position.y);
            Vector2 newLeft = new Vector2(left.position.x + leftright, left.position.y);
            Vector2 newBot = new Vector2(bot.position.x + leftright, bot.position.y);
            top.position = Vector3.SmoothDamp(top.position, newTop, ref velocity, smoothTime);
            left.position = Vector3.SmoothDamp(left.position, newLeft, ref velocity, smoothTime);
            right.position = Vector3.SmoothDamp(right.position, newRight, ref velocity, smoothTime);
            bot.position = Vector3.SmoothDamp(bot.position, newBot, ref velocity, smoothTime);

            Vector3 targetPosition2 = new Vector3(transform.position.x + leftright, transform.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, smoothTime);
        }
    }

    void camFollow()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, followV * Time.deltaTime);
    }
}
