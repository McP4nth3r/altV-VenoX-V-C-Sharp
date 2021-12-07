import * as alt from 'alt';
import { ShowCursor, vnxCreateCEF } from '../VnX-Lib';
let webview = null;
export function LoadChat() {
  try {
    if (webview != null) { return; }
    webview = vnxCreateCEF("Chat", "Globals/Chat/html/index.html");
    chatActive = true;
    webview.on('chat:onLoaded', () => {
      activateChat(true);
      push('Connected to VenoX', 'white', [0, 200, 255], 'check')
    });

    webview.on('chat:onInputStateChange', state => {
      inputActive = state;
      ShowCursor(state);
      if (state) webview.focus();
      else webview.unfocus();
    });

    webview.on('chat:onChatStateChange', state => {
      chatActive = state;
      webview.unfocus();
    });

    webview.on('chat:onInput', text => {
      alt.emitServer('chat:message', text);
      webview.unfocus();
    });
  }
  catch { }
}


let chatActive = false;
let inputActive = false;
let scrollActive = false;



alt.onServer('chat:sendMessage', (sender, text) => {
  try {
    push(`${sender} says: ${text}`);
  }
  catch { }
});

function pushMessage(name, text) {
  try {
    push(text);
  }
  catch { }
}

alt.onServer('chat:message', pushMessage);


alt.onServer('chat:showMessage', (text, color, gradient, icon) => {
  try { push(text, color, gradient, icon); }
  catch { }
});

alt.onServer('chat:activateChat', state => {
  activateChat(state);
});

export function clearMessages() {
  try { webview.emit('chat:clearMessages'); }
  catch { }
}

export function push(text, color = 'white', gradient = false, icon = false) {
  webview.emit('chat:pushMessage', text, color, gradient, icon);
}


export function activateChat(state) {
  webview.emit('chat:activateChat', state);
}


alt.on('keyup', key => {
  try {
    // Keys working only when chat is not active
    if (!chatActive) {
      switch (key) {
      }
    }

    // Keys working only when chat is active
    if (chatActive) {
      switch (key) {
        // PageUp
        case 33: return scrollMessagesList('up');
        // PageDown
        case 34: return scrollMessagesList('down');
      }
    }

    // Keys working only when chat is active and input is not active
    if (chatActive && !inputActive) {
      switch (key) {
        // KeyT
        case 84: return activateInput(true);
      }
    }

    // Keys working only when chat is active and input is active
    if (chatActive && inputActive) {
      switch (key) {
        // Enter
        case 13: return sendInput();
        // ArrowUp
        case 38: return shiftHistoryUp();
        // ArrowDown
        case 40: return shiftHistoryDown();
      }
    }
  }
  catch { }
});

function scrollMessagesList(direction) {
  try {
    if (scrollActive) return;
    scrollActive = true;
    alt.setTimeout(() => scrollActive = false, 250 + 5);
    webview.emit('chat:scrollMessagesList', direction);
  }
  catch { }
}

function activateInput(state) {
  webview.focus();
  webview.emit('chat:activateInput', state);
}

function sendInput() {
  webview.emit('chat:sendInput');
  webview.unfocus();
}

function shiftHistoryUp() {
  webview.emit('chat:shiftHistoryUp');
}

function shiftHistoryDown() {
  webview.emit('chat:shiftHistoryDown');
}