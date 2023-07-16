using UnityEngine;

public class DragAllRestricted : MonoBehaviour {
  [SerializeField] private LayerMask movableLayers;
  [SerializeField] private bool isMoveRestrictedToScreen = false;

  private Transform dragging = null;
  private Vector3 offset;
  private Vector3 extents;

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      // Cast our own ray.
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
                                           Vector2.zero, float.PositiveInfinity, movableLayers);
      if (hit) {
        // If we hit, record the transform of the object we hit.
        dragging = hit.transform;
        // And record the offset.
        offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Record the size of the sprite so we can limit it to the screen if necessary.
        extents = dragging.GetComponent<SpriteRenderer>().sprite.bounds.extents;
      }
    } else if (Input.GetMouseButtonUp(0)) {
      // Stop dragging.
      dragging = null;
    }

    if (dragging != null) {
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
      if (isMoveRestrictedToScreen) {
        // Find the screen bounds in world coordinates.
        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        // Limit to the screen
        pos.x = Mathf.Clamp(pos.x, bottomLeft.x + extents.x, topRight.x - extents.x);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y + extents.y, topRight.y - extents.y);
      }
      // Set the target objects position.
      dragging.position = pos;
    }
  }
}
