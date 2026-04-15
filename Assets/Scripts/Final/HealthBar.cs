using NodeCanvas.Framework;
using UnityEngine;

public class HealthBar : MonoBehaviour

{

    public float Health;
    public float MaxHealth;
    public float Width;
    public float Height;
    public RectTransform healthbar;
    public Blackboard bb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bb = GetComponent<Blackboard>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;

    }

    public void SetHealth(float health)
    {
        Health = health;
        float updatedwidth = (Health/MaxHealth)*Width;
        healthbar.sizeDelta = new Vector2(updatedwidth, Height);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
