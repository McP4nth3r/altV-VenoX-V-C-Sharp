import * as alt from 'alt';
import { ShowCursor } from '../VnX-Lib';


let buffer = [];

let loaded = false;
let opened = false;

const view = new alt.WebView("http://resource/VenoXV_Client/Globals/Chat/html/index.html");

function addMessage(name, text) {
  if (name) {
    view.emit('addMessage', name, text);
  } else {
    view.emit('addString', text);
  }
}

view.on('chatloaded', () => {
  for (const msg of buffer) {
    addMessage(msg.name, msg.text);
  }
  loaded = true;
})

view.on('chatmessage', (msg) => {
  if (msg.length > 0) {
    alt.emitServer('chat:message', msg);
  }
  opened = false;
  alt.toggleGameControls(true);
  ShowCursor(opened);
})

export function pushMessage(name, text) {
  if (!loaded) {
    buffer.push({ name, text });
  } else {
    addMessage(name, text);
  }
}

export function pushLine(text) {
  pushMessage(null, text);
}

alt.onServer('chat:message', pushMessage);

alt.on('keyup', (key) => {
  if (loaded) {
    if (!opened && key === 0x54 && alt.gameControlsEnabled()) {
      opened = true;
      view.emit('openChat', false);
      alt.toggleGameControls(false);
      ShowCursor(opened);
    } else if (!opened && key === 0xBF && alt.gameControlsEnabled()) {
      opened = true;
      view.emit('openChat', true);
      alt.toggleGameControls(false);
      ShowCursor(opened);
    } else if (opened && key == 0x1B) {
      opened = false;
      view.emit('closeChat');
      alt.toggleGameControls(true);
      ShowCursor(opened);
    }
  }
});

//pushLine('<b>alt:V Multiplayer has started</b>');
