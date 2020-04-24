import * as alt from 'alt';
import { ShowCursor, GetCursorStatus } from '../VnX-Lib';


let buffer = [];

let loaded = false;
let opened = false;

let view = null;


export function LoadChat() {
  if (view != null) { return; }
  view = new alt.WebView("http://resource/VenoXV_Client/Globals/Chat/html/index.html");
  view.on('chatloaded', () => {
    if (view == null) { return; }
    for (const msg of buffer) {
      addMessage(msg.name, msg.text);
    }
    loaded = true;
  })

  view.on('chatmessage', (msg) => {
    if (view == null) { return; }
    if (msg.length > 0) {
      alt.emitServer('chat:message', msg);
    }
    opened = false;
    alt.toggleGameControls(true);
    ShowCursor(opened);
  })

}


function addMessage(name, text) {
  if (view == null) { return; }
  if (name) {
    view.emit('addMessage', name, text);
  } else {
    view.emit('addString', text);
  }
}


export function pushMessage(name, text) {
  if (view == null) { return; }
  if (!loaded) {
    buffer.push({ name, text });
  } else {
    addMessage(name, text);
  }
}

export function pushLine(text) {
  if (view == null) { return; }
  pushMessage(null, text);
}

alt.onServer('chat:message', pushMessage);

alt.on('keyup', (key) => {
  if (loaded) {
    if (view == null) { return; }
    if (!opened && key === 0x54 && alt.gameControlsEnabled() && !GetCursorStatus()) {
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
