using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayData
{
    public int version = 1;
    public PlayerPlayData[] players;
}

[Serializable]
public class PlayerPlayData
{
    public int playerNumber;

    // Polyline vertices for this player's run path.
    public Vector2[] points;

    // Optional per-vertex event metadata.
    public bool hasEvent;
    public int eventPositionInLine;
    public int eventType;
    public bool eventHasBeenMade;
}

public class PlaybookSaveLoad : MonoBehaviour
{
    public string saveFileName = "last_play.json";

    private string SavePath =>
        Path.Combine(Application.persistentDataPath, saveFileName);

    public void SavePlay()
    {
        if (PlayerMenuScript.players == null || PlayerMenuScript.players.Length == 0)
            return;

        var playerData = new PlayerPlayData[PlayerMenuScript.players.Length];

        for (int i = 0; i < PlayerMenuScript.players.Length; i++)
        {
            var player = PlayerMenuScript.players[i];
            playerData[i] = BuildPlayerPlayData(player);
        }

        var playData = new PlayData { players = playerData };
        var json = JsonUtility.ToJson(playData, true);
        File.WriteAllText(SavePath, json);
    }

    public void LoadPlay()
    {
        if (PlayerMenuScript.players == null || PlayerMenuScript.players.Length == 0)
            return;

        if (!File.Exists(SavePath))
            return;

        var json = File.ReadAllText(SavePath);
        var playData = JsonUtility.FromJson<PlayData>(json);
        if (playData == null || playData.players == null)
            return;

        bool isDrawAndEditMode = false;
        var drawAndEdit = FindObjectOfType<DrawAndEdit>();
        if (drawAndEdit != null)
            isDrawAndEditMode = drawAndEdit.isDrawAndEditMode;

        // Clear all current lines first.
        for (int i = 0; i < PlayerMenuScript.players.Length; i++)
        {
            var p = PlayerMenuScript.players[i];
            var lineDestroyer = p.GetComponent<LineDestroyer>();
            if (lineDestroyer != null)
                lineDestroyer.DeleteLine(p.transform);

            p.ModifyPlayerCollider(isDrawAndEditMode);
        }

        // Recreate lines from the save.
        for (int i = 0; i < playData.players.Length; i++)
        {
            var pp = playData.players[i];
            var player = FindPlayerByNumber(pp.playerNumber);
            if (player == null)
                continue;

            if (pp.points == null || pp.points.Length == 0)
                continue;

            var lineCreator = player.GetComponent<LineCreator>();
            if (lineCreator == null || lineCreator.linePrefab == null)
                continue;

            // Create the Line instance, then replace its points deterministically.
            lineCreator.MakeLine();
            var line = player.runningLine;
            if (line == null)
                continue;

            line.SetLinePoints(new List<Vector2>(pp.points));

            if (pp.hasEvent)
            {
                line.eventPositionInLine = Mathf.Clamp(pp.eventPositionInLine, 0, pp.points.Length - 1);
                line.eventInfo = new EventInformation(
                    player,
                    (EventTypeHandler.DynamicEventTypes)pp.eventType,
                    pp.eventHasBeenMade
                );
            }
            else
            {
                line.eventPositionInLine = 0;
                line.eventInfo = null;
            }

            // Stop mouse/touch updating while we loaded from JSON.
            lineCreator.activeLine = null;

            // Place player on the first vertex and reset movement indices.
            player.transform.position = pp.points[0];
            player.playerMovement.currentPositionInLine = 0;
            player.playerMovement.currentPositionX = pp.points[0].x;
            player.playerMovement.currentPositionY = pp.points[0].y;

            player.ModifyPlayerCollider(isDrawAndEditMode);
        }
    }

    private Player FindPlayerByNumber(int playerNumber)
    {
        var players = PlayerMenuScript.players;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].playerNumber == playerNumber)
                return players[i];
        }
        return null;
    }

    private PlayerPlayData BuildPlayerPlayData(Player player)
    {
        var data = new PlayerPlayData();
        data.playerNumber = player.playerNumber;

        if (player.runningLine != null)
        {
            var points = player.runningLine.GetLine();
            if (points != null && points.Count > 0)
                data.points = points.ToArray();
            else
                data.points = new Vector2[0];

            if (player.runningLine.eventInfo != null)
            {
                data.hasEvent = true;
                data.eventPositionInLine = player.runningLine.eventPositionInLine;
                data.eventType = (int)player.runningLine.eventInfo.eventType;
                data.eventHasBeenMade = player.runningLine.eventInfo.hasEventBeenMade;
            }
        }
        else
        {
            data.points = new Vector2[0];
        }

        return data;
    }
}

