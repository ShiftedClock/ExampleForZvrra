using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool debug;
    [SerializeField] private int startingLocation = 1; 
    [SerializeField] private GameObject grid;

    private int currentLocation;
    

    private void Awake()
    {
        // Init the player location on the grid
        currentLocation = startingLocation;
        SetPlayerPosition(startingLocation);
    }

    private void Update()
    {
        // Put all the directional checks in the same if block so the player can only move one direction at a time.
        // This is a very simple way of doing the movement, but increasing the grid size would be a bit tricky.
        if (Input.GetKeyDown(KeyCode.A)) {
            if (debug) Debug.Log("left");
            // Don't move if we're already on the left.
            if (currentLocation != 0 && currentLocation != 3) {
                SetPlayerPosition(currentLocation - 1); 
            }
        } else if (Input.GetKeyDown(KeyCode.D)) {
            if (debug) Debug.Log("right");
            // Don't move if we're already on the right.
            if (currentLocation != 2 && currentLocation != 5) {
                SetPlayerPosition(currentLocation + 1); 
            }
        } else if (Input.GetKeyDown(KeyCode.W)) {
            if (debug) Debug.Log("up");
            // Make sure we're on the bottom row.
            if (currentLocation >= 3) {
                SetPlayerPosition(currentLocation - 3); 
            }
        } else if (Input.GetKeyDown(KeyCode.S)) {
            if (debug) Debug.Log("down");
            // Make sure we're on the top row.
            if (currentLocation < 3) {
                SetPlayerPosition(currentLocation + 3); 
            }
        } 
    }

    private void SetPlayerPosition(int location)
    {
        // Turn off the sprite at our current location...
        grid.transform.GetChild(currentLocation).GetComponent<SpriteRenderer>().enabled = false;
        // And turn on the sprite renderer at the next location.
        grid.transform.GetChild(location).GetComponent<SpriteRenderer>().enabled = true;
        // Update our current location *after* we move.
        currentLocation = location;
        // This is where you could use Tweens to fade the sprites in and out, or do other effects.
    }
}

