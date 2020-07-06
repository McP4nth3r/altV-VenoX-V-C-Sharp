import * as alt from 'alt';
import { ShowCursor, vnxCreateCEF } from '../VnX-Lib';
let webview = null;
export function LoadChat() {
  try {
    if (webview != null) { return; }
    webview = vnxCreateCEF("Chat", "Globals/Chat/html/index.html");
    webview.focus();
    chatActive = true;
    webview.on('chat:onLoaded', () => {
      activateChat(true);
      push('Connected to VenoX', 'white', [0, 200, 255], 'check')
    });

    webview.on('chat:onInputStateChange', state => {
      inputActive = state;
      ShowCursor(state);
    });

    webview.on('chat:onChatStateChange', state => {
      chatActive = state;
    });

    webview.on('chat:onInput', text => {
      alt.emitServer('chat:message', text);
    });
  }
  catch{ }
}


let chatActive = false;
let inputActive = false;
let scrollActive = false;



alt.onServer('chat:sendMessage', (sender, text) => {
  try {
    push(`${sender} says: ${text}`);
  }
  catch{ }
});

function pushMessage(name, text) {
  try {
    push(text);
  }
  catch{ }
}

alt.onServer('chat:message', pushMessage);


alt.onServer('chat:showMessage', (text, color, gradient, icon) => {
  try { push(text, color, gradient, icon); }
  catch{ }
});



alt.onServer('chat:activateChat', state => {
  activateChat(state);
});

export function clearMessages() {
  try { webview.emit('chat:clearMessages'); }
  catch{ }
}

// Backwards compatibility until next update
export function clearChat(...args) {
  alt.logWarning('Chat function "clearChat" is deprecated. Consider using "clearMessages" as old one will be removed after next update.');
  clearMessages(...args);
}

export function push(text, color = 'white', gradient = false, icon = false) {
  webview.emit('chat:pushMessage', text, color, gradient, icon);
}

// Backwards compatibility until next update
export function addChatMessage(...args) {
  alt.logWarning('Chat function "addChatMessage" is deprecated. Consider using "push" as old one will be removed after next update.');
  push(...args);
}

export function activateChat(state) {
  webview.emit('chat:activateChat', state);
}

// Backwards compatibility until next update
export function showChat() {
  alt.logError('Chat function "showChat" is deprecated. Consider using "activateChat" as old one will be removed after next update. Function was not called!');
  push('Check you console!', 'red');
}

// Backwards compatibility until next update
export function hideChat() {
  alt.logError('Chat function "hideChat" is deprecated. Consider using "activateChat" as old one will be removed after next update. Function was not called!');
  push('Check you console!', 'red');
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
  catch{ }
});

function scrollMessagesList(direction) {
  try {
    if (scrollActive) return;
    scrollActive = true;
    alt.setTimeout(() => scrollActive = false, 250 + 5);
    webview.emit('chat:scrollMessagesList', direction);
  }
  catch{ }
}

function activateInput(state) {
  try {
    webview.focus(state);
    webview.emit('chat:activateInput', state);
  }
  catch{ }
}

function sendInput() {
  try {
    webview.emit('chat:sendInput');
  }
  catch{ }
}

function shiftHistoryUp() {
  try {
    webview.emit('chat:shiftHistoryUp');
  }
  catch{ }
}

function shiftHistoryDown() {
  try {
    webview.emit('chat:shiftHistoryDown');
  }
  catch{ }
}