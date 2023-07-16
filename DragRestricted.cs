using UnityEngine;

public class DragRestricted : MonoBehaviour {
  [SerializeField] private bool isMoveRestrictedToScreen = false;

  private bool dragging = false;
  private Vector3 offset;
  private Vector3 extents;

  private void Start() {
    // Record the size of the sprite so we can limit it to the screen if necessary.
    extents = GetComponent<SpriteRenderer>().sprite.bounds.extents;
  }

  // Update is called once per frame
  void Update() {
    if (dragging) {
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
      if (isMoveRestrictedToScreen) {
        // Find the screen bounds in world coordinates.
        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        // Limit to the screen
        pos.x = Mathf.Clamp(pos.x, bottomLeft.x + extents.x, topRight.x - extents.x);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y + extents.y, topRight.y - extents.y);
      }
      // Set the objects position.
      transform.position = pos;
    }
  }

  private void OnMouseDown() {
    // Record the difference between the objects centre, and the clicked point on the camera plane.
    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    dragging = true;
  }

  private void OnMouseUp() {
    // Stop dragging.
    dragging = false;
  }
}
