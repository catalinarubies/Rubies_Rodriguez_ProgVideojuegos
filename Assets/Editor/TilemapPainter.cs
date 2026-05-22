using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapPainter
{
    private const string TILE_PATH = "Assets/Sprites/Tiles/tile_0036.png";
    private const int X_MIN = -20;
    private const int X_MAX = 20;
    private const int Y_MIN = -12;
    private const int Y_MAX = 12;

    [MenuItem("Tools/Paint Tilemap/Pintar con tile_0036")]
    static void PaintWithTile0036()
    {
        Tilemap tilemap = Object.FindAnyObjectByType<Tilemap>();
        if (tilemap == null)
        {
            EditorUtility.DisplayDialog("Error", "No se encontró ningún Tilemap en la escena.", "OK");
            return;
        }

        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(TILE_PATH);
        if (sprite == null)
        {
            EditorUtility.DisplayDialog("Error", $"No se pudo cargar el sprite en:\n{TILE_PATH}", "OK");
            return;
        }

        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;

        Undo.RecordObject(tilemap, "Paint Tilemap tile_0036");

        for (int x = X_MIN; x <= X_MAX; x++)
        {
            for (int y = Y_MIN; y <= Y_MAX; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        EditorUtility.SetDirty(tilemap);
        Debug.Log($"[TilemapPainter] Pintado con tile_0036 en X[{X_MIN},{X_MAX}] Y[{Y_MIN},{Y_MAX}]. Total: {(X_MAX - X_MIN + 1) * (Y_MAX - Y_MIN + 1)} tiles.");
    }

    [MenuItem("Tools/Paint Tilemap/Limpiar todo el Tilemap")]
    static void ClearAll()
    {
        Tilemap tilemap = Object.FindAnyObjectByType<Tilemap>();
        if (tilemap == null)
        {
            EditorUtility.DisplayDialog("Error", "No se encontró ningún Tilemap en la escena.", "OK");
            return;
        }

        Undo.RecordObject(tilemap, "Clear All Tilemap");
        tilemap.ClearAllTiles();
        EditorUtility.SetDirty(tilemap);
        Debug.Log("[TilemapPainter] Tilemap completamente limpiado.");
    }
}
