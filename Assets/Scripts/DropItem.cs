using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    private Button yourButton;
    private Inventory inventory;
    private Transform player;
    
    public void Start() {
        // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // Button btn = GameObject.Find("Pop").GetComponent<Button>();
        // btn.onClick.AddListener(Drop);
        // Debug.Log("12");
        Debug.Log("as");
        
    }

    public void Drop() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        int a=3;
        
        for(int i=inventory.slots.Length-1; i>=0; i--){
            if(inventory.isFull[i]==true){
                a=i;
                break;
            }
        }
        GameObject Button = inventory.slots[a].transform.GetChild (0).gameObject;
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        go.GetComponent<SpriteRenderer>().sprite = Button.GetComponent<Image>().sprite;
        Spawn(go);
        // Sprite s = inventory.slots[a].gameObject.GetComponent<SpriteRenderer>().sprite;
        GameObject.Destroy(inventory.slots[a].gameObject);
        inventory.isFull[a] = false;
        return;        
    }
    public void Spawn(GameObject item) {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, 0);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
