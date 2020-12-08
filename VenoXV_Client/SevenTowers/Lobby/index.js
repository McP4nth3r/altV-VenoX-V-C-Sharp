//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";
import { DrawText, ShowCountdown } from '../../Globals/VnX-Lib';
import Camera from '../../Globals/VnX-Lib/camera';

// Cache
let PlayerList = [];
let PlayerListInterval;
let SevenTowersTick;
let CurrentWinner = "Noob";
let CurrentWinnerText = "";
let spectatedPlayerIndex = -1;
let spectateTick = undefined;
let spectatorCamera = undefined;

let offset = {
    x: 0,
    y: -20,
    z: 5,
};

export function Render7TowersLobby() {
    try {
        //DrawText("1:34", [0.5, 0.006], [0.5, 0.5], 0, [255, 255, 255, 255], true, true);
        //game.drawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
        DrawText(CurrentWinner + " " + CurrentWinnerText, [0.5, 0.5], [1, 1], 0, [255, 255, 255, 255], false, true);
        game.drawRect(0.5, 0.57, 0.25, 0.005, 255, 200, 0, 255);
    }
    catch { }
}

alt.onServer('SevenTowers:ShowWinner', (Winner, TranslatedText, DestroyMS) => {
    try {
        if (SevenTowersTick != null) return;
        CurrentWinnerText = TranslatedText;
        alt.toggleGameControls(false);
        SevenTowersTick = alt.everyTick(() => {
            Render7TowersLobby();
            CurrentWinner = Winner;
        });
        alt.setTimeout(() => {
            if (SevenTowersTick != null) {
                alt.clearEveryTick(SevenTowersTick); SevenTowersTick = null; alt.toggleGameControls(true);
                ShowCountdown(5);
            }
        }, DestroyMS);
    }
    catch { }
});

alt.onServer('SevenTowers:AddPlayer', (player) => {
    alt.log('SevenTowers:AddPlayer');
    PlayerList.push(player);
});

alt.onServer('SevenTowers:RemovePlayer', (player) => {
    alt.log('SevenTowers:RemovePlayer');
    const playerIndex = PlayerList.findIndex(entity => entity === player);

    if (playerIndex >= 0) {
        if (playerIndex === spectatedPlayerIndex) {
            spectatedPlayerIndex = 0;
        }

        PlayerList.splice(playerIndex, 1);
    }
});

alt.onServer('SevenTowers:PlayerListUninit', () => {
    if (PlayerListInterval) return;
    alt.clearInterval(PlayerListInterval);
    PlayerListInterval = null;
});


function PutPlayerIntoSpectatorMode() {
    alt.log(JSON.stringify(PlayerList));
    alt.log('PutPlayerIntoSpectatorMode');
    if (PlayerList.length <= 0) return;

    spectatedPlayerIndex = 0;
    spectatePlayer(PlayerList[0]);
}

function RemovePlayerFromSpectatorMode() {
    alt.log('RemovePlayerFromSpectatorMode');
    if (spectateTick !== undefined) {
        alt.clearEveryTick(spectateTick);
    }

    if (spectatorCamera !== undefined) {
        spectatorCamera.destroy();
        spectatorCamera = undefined;
    }

    if (spectatedPlayerIndex >= 0) {
        spectatedPlayerIndex = -1;
    }
}

alt.onServer('SevenTowers:PutPlayerIntoSpectatorMode', PutPlayerIntoSpectatorMode);
alt.onServer('SevenTowers:RemovePlayerFromSpectatorMode', RemovePlayerFromSpectatorMode);

function spectatePlayer(player) {
    alt.log(JSON.stringify(player));
    if (!player) return;

    spectatorCamera = new Camera(
        new alt.Vector3(
            player.pos.x,
            player.pos.y,
            player.pos.z + offset.z
        ),
        new alt.Vector3(0, 0, player.rot.z),
        20
    );

    spectateTick = alt.everyTick(() => {
        spectatorCamera.rotation = new alt.Vector3(0, 0, player.rot.z);
    });

    spectatorCamera.pointAtEntity(player.scriptID, new alt.Vector3(0, 0, 0));
    spectatorCamera.attach(player.scriptID, new alt.Vector3(0, offset.y, offset.z), true);
    spectatorCamera.render();
}

alt.on('keyup', (key) => {
    if (spectatedPlayerIndex >= 0) {
        switch (key) {
            case 33:
                spectatedPlayerIndex = spectatedPlayerIndex - 1 === PlayerList.length ? 0 : spectatedPlayerIndex++;

                spectatorCamera.destroy();
                spectatePlayer(PlayerList[spectatedPlayerIndex]);
                break;
            case 34:
                spectatedPlayerIndex = spectatedPlayerIndex === 0 ? PlayerList.length - 1 : spectatedPlayerIndex--;

                spectatorCamera.destroy();
                spectatePlayer(PlayerList[spectatedPlayerIndex]);
                break;
        }
    }
});