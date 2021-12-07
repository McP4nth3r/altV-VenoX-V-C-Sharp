//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
import * as alt from 'alt-client';
import * as game from "natives";

import { vnxCreateCEF } from "../../VnX-Lib";

const maxRange = 60.0;
const localPlayer = alt.Player.local;
let musicPlayer = vnxCreateCEF('MusicPlayer', 'Globals/Sync/Sound/musicPlayer/index.html');
let id = 0;
let activeSounds = {}, hostSounds = {},
    soundInterval;

const soundManager = {
    add: function (player, id) {
        if (player && hostSounds[id]) {
            hostSounds[id].listeners.push(player);
            if (localPlayer.scriptID !== player.scriptID) return alt.emit('addListener', player.scriptID, JSON.stringify(hostSounds[id]));
            if (musicPlayer) musicPlayer.emit('SoundAPI:PlayAudio', id, hostSounds[id].url, hostSounds[id].volume);
        }
    },
    remove: function (player, id) {
        if (player) {
            if (hostSounds[id]) {
                let idx = hostSounds[id].listeners.indexOf(player);
                if (idx !== -1) {
                    hostSounds[id].listeners.splice(idx, 1);
                    if (localPlayer.scriptID !== player.scriptID) return alt.emit('removeListener', player.scriptID, id);
                }
            }
            if (musicPlayer) {
                if (activeSounds[id]) activeSounds[id] = null;
                musicPlayer.emit('SoundAPI:StopAudio', id);
            }
        }
    },
    setVolume: function (player, id, volume) {
        if (player) {
            if (hostSounds[id] && localPlayer.scriptID !== player.scriptID) return alt.emit('changeSoundVolume', player.scriptID, id, volume);
            if (musicPlayer) musicPlayer.emit('SoundAPI:SetVolume', id, volume);
        }
    },
    pauseToggle: function (player, id, pause) {
        if (player) {
            if (hostSounds[id]) {
                hostSounds[id].paused = pause;
                if (localPlayer.scriptID !== player.scriptID) return alt.emit('pauseToggleSound', player.scriptID, id, pause);
            }
            if (musicPlayer) {
                if (activeSounds[id]) activeSounds[id].paused = pause;
                musicPlayer.emit('SoundAPI:SetPaused', id, pause);
            }
        }
    }
}

alt.on({
    'createSound': (soundObj) => {
        soundObj = JSON.parse(soundObj);
        id = soundObj.id;
        if (!activeSounds[soundObj.id] && !hostSounds[soundObj.id]) {
            alt.log(`Pushing Sound[${soundObj.id}]:  ${soundObj.range} ${soundObj.pos}`);
            activeSounds[soundObj.id] = {
                id: soundObj.id,
                url: soundObj.url,
                pos: soundObj.pos,
                volume: soundObj.volume,
                range: soundObj.range,
                dimension: soundObj.dimension,
                listeners: soundObj.listeners,
                host: soundObj.host, // Possibility of host change in future maybe
                paused: soundObj.paused
            }
            if (musicPlayer) musicPlayer.emit('SoundAPI:PlayAudio', soundObj.id, activeSounds[soundObj.id].url, activeSounds[soundObj.id].volume)
        }
    },
    /*
    'soundPosition': (id, pos) => { // Could be used in future for host changing sync.
        pos = JSON.parse(pos);
        if (activeSounds[id]) {
            activeSounds[id].pos = pos;
        }
    },
    'soundRange': (id, range) => { // Could be used in future for host changing sync.
        if (activeSounds[id]) {
            activeSounds[id].range = range;
        }
    },
    */
    'setSoundVolume': (id, volume) => {
        soundManager.setVolume(localPlayer, id, volume);
    },
    'destroySound': (soundID) => {
        if (activeSounds[soundID]) {
            soundManager.remove(localPlayer, soundID);
            activeSounds[soundID] = null;
        } else if (hostSounds[soundID]) {
            hostSounds[soundID].listeners.forEach(listener => {
                soundManager.remove(listener, soundID);
            });
            hostSounds[soundID] = null;
        }
        if (Object.keys(hostSounds).length < 1) {
            if (soundInterval) clearInterval(soundInterval);
        }
    },
    'destroySoundHost': (hostID) => {
        Object.keys(activeSounds).forEach(soundID => {
            if (hostID == activeSounds[soundID].host) {
                soundManager.remove(localPlayer, soundID);
            }
        });
    },
    'pauseSound': (soundID) => {
        soundManager.pauseToggle(localPlayer, soundID, true);
    },
    'resumeSound': (soundID) => {
        soundManager.pauseToggle(localPlayer, soundID, false);
    },
    'audioFinish': (soundID) => {
        alt.emit('destroySound', soundID);
        alt.emit('soundFinish', soundID);
    },
    'audioError': (soundID, err) => {
        alt.emit('destroySound', soundID);
        alt.emit('soundError', soundID, err);
    }
});

export function playSound3D(url, pos, range = maxRange, volume = 1, dimension = 0) {
    id += 1;
    hostSounds[id] = {
        id: id,
        url: url,
        pos: pos,
        volume: volume,
        range: range,
        dimension: dimension,
        listeners: [],
        host: localPlayer.scriptID,
        paused: false,
    };
    hostSounds[id].destroy = function () {
        return alt.emit('soundState', 'destroySound', this.id);
    };
    hostSounds[id].pause = function () {
        return alt.emit('soundState', 'pauseSound', this.id);
    };
    hostSounds[id].resume = function () {
        return alt.emit('soundState', 'resumeSound', this.id)
    };
    if (!soundInterval) initSoundInterval();
    return hostSounds[id];
};

export function setSoundVolume(id, volume = 1) {
    if (hostSounds[id]) {
        hostSounds[id].volume = volume;
    }
};

export function setSoundPosition(id, pos) {
    if (hostSounds[id]) {
        hostSounds[id].pos = pos;
        // alt.emit('soundPosition', id, JSON.stringify(pos)); // Could be used in future for host changing sync.
    }
}

export function setSoundRange(id, range) {
    if (range < 0 || range > maxRange) range = maxRange;
    hostSounds[id].range = range;
    // alt.emit('soundRange', id, range); // Could be used in future for host changing sync.
}

function initSoundInterval() {
    soundInterval = alt.setInterval(() => {
        Object.keys(hostSounds).forEach(sound => {
            if (hostSounds[sound] && !hostSounds[sound].paused) {
                const soundPosition = hostSounds[sound].pos;
                const maxRange = hostSounds[sound].range;

                let players = alt.Player.all
                if (players.length > 0) {
                    for (var i = 0; i < players.length; i++) {
                        var player = players[i];
                        if (player && player.dimension === hostSounds[sound].dimension && !hostSounds[sound].listeners.includes(player)) {
                            const playerPos = player.pos;
                            let dist = game.vdist(playerPos.x, playerPos.y, playerPos.z, soundPosition.x, soundPosition.y, soundPosition.z)
                            if (dist <= maxRange) {
                                soundManager.add(player, sound);
                            }
                        }

                    }
                }
                if (hostSounds[sound].listeners && hostSounds[sound].listeners.length > 0)
                    hostSounds[sound].listeners.forEach(player => {
                        if (player) {
                            const playerPos = player.pos;
                            let dist = game.vdist(playerPos.x, playerPos.y, playerPos.z, soundPosition.x, soundPosition.y, soundPosition.z);
                            if (dist > maxRange || hostSounds[sound].dimension !== player.dimension) {
                                soundManager.remove(player, sound);
                            } else {
                                let volume = (hostSounds[sound].volume - (dist / hostSounds[sound].range)).toFixed(2); // Credits to George....
                                soundManager.setVolume(player, sound, volume);
                            }
                        }
                    });
            }
        });
    }, 500);
};