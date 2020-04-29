//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { Draw3DText } from '../../../Globals/VnX-Lib';


let CurrentWeedPlants = {
    Name: "",
    Position: [],
};
CurrentWeedPlants.Name = "";
let CurrentWeedCounter = 0;

function DestroyAllWeedObjects() {
    for (var weed in CurrentWeedPlants) {
        game.deleteObject(CurrentWeedPlants[weed].Object);
    }
    CurrentWeedCounter = 0;
}

alt.onServer('Weed:Create', (WeedJson) => {
    let WeedItems = JSON.parse(WeedJson);
    for (let i = 0; i < WeedItems.length; i++) {
        let data = WeedItems[i];
        CurrentWeedPlants[CurrentWeedCounter++] = game.createObject(alt.hash("prop_weed_01"), data.Position.X, data.Position.Y, data.Position.Z, false, false, false);//;
    }
});

alt.everyTick(() => {
    if (CurrentWeedPlants.length <= 0) { return; }
    for (var weedplants in CurrentWeedPlants) {
        //Draw3DText("Test " + CurrentWeedPlants[weedplants].Name, CurrentWeedPlants[weedplants].Pos, 0, [255, 255, 255], [1, 1], true, true);
        if (!CurrentWeedPlants[weedplants].Name) { return; }
        let x = CurrentWeedPlants[weedplants].Pos[0];
        let y = CurrentWeedPlants[weedplants].Pos[1];
        let z = CurrentWeedPlants[weedplants].Pos[2] + 0.5;
        let Text = "~g~" + CurrentWeedPlants[weedplants].Name + "\n____________\n ~g~Gewachsen : ~w~" + CurrentWeedPlants[weedplants].Value + "% \n ~g~Erstellt am : ~w~ 29.03.2020 - 14:53";
        Draw3DText(Text, x, y, z, 0, [255, 255, 255, 255], 20, true, true);
    }
});

alt.onServer('Weed:Destroy', () => {
    DestroyAllWeedObjects();
});

alt.onServer('Weed:Update', (WeedJson) => {
    let WeedItems = JSON.parse(WeedJson);
    for (let i = 0; i < WeedItems.length; i++) {
        let data = WeedItems[i];
        let NewObject = game.createObject(alt.hash("prop_weed_01"), data.Position.X, data.Position.Y, data.Position.Z - 0.5, false, false, false);
        CurrentWeedPlants[CurrentWeedCounter] = {
            Name: data.Name + "",
            Pos: [data.Position.X, data.Position.Y, data.Position.Z],
            Object: NewObject,
            Value: data.Value,
            Created: data.Created,
        }
        CurrentWeedCounter++;
    }
});