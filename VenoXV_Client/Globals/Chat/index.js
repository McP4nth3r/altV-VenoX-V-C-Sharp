import * as alt from 'alt';
import { ShowCursor, GetCursorStatus } from '../VnX-Lib';


let buffer = [];

let loaded = false;
let opened = false;

let view = null;


export function LoadChat() {
  if (view != null) { return; }
  view = new alt.WebView("http://resource/VenoXV_Client/Globals/Chat/index.html");
  view.on('chatloaded', () => {
    if (view == null) { return; }
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



alt.onServer('chat:message', (text) => {
  if (view == null) { return; }
  view.emit('Chat:Push', text);
});

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
