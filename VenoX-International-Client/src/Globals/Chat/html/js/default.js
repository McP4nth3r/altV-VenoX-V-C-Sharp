// Settings
var _MAX_MESSAGES_ON_CHAT = 10;
var _HIDE_INPUT_BAR_ON_BLUR = true;
var _MAX_INPUT_HISTORIES = 5;

// Data
var chatActive = false;
var inputActive = false;

// Input History
var inputHistory = [];
var inputHistoryCurrent;
var inputHistoryCache;

// Elements
var chatBox = $('.chat-box');
var chatMessagesList = $('.chat-box .chat-messages-list');
var chatInputBar = $('.chat-box .chat-input-bar');
var pushButton = $('.chat-box .PushButton');
var chatInputBarLength = $('.chat-box .chat-input-bar-length');
var chatNewMessagesWarning = $('.chat-box .chat-new-messages-warning');

// Initiation
$(document).ready(() => {
    const messagesListHeight = _MAX_MESSAGES_ON_CHAT * 22;
    const chatBoxHeight = messagesListHeight + 50;

    chatBox.css('height', chatBoxHeight + 'px');
    chatMessagesList.css('height', messagesListHeight + 'px');

    alt.emit('chat:onLoaded');
});
if (_HIDE_INPUT_BAR_ON_BLUR) $(chatInputBar).focusout(() => inputActive && activateInput(false));
chatMessagesList.bind('mousewheel DOMMouseScroll', (e) => e.preventDefault());
chatInputBar.bind('propertychange change click keyup input paste', () => inputActive && setInputBarLengthCounterCurrent(chatInputBar.val().length));

function clearMessages() {
    chatMessagesList.html('');
}


function colorify(text) {
    let matches = [];
    let m = null;
    let curPos = 0;

    do {
        m = /\{[A-Fa-f0-9]{3}\}|\{[A-Fa-f0-9]{6}\}/g.exec(text.substr(curPos));

        if (!m) {
            break;
        }

        matches.push({
            found: m[0],
            index: m['index'] + curPos
        });

        curPos = curPos + m['index'] + m[0].length;
    } while (m != null);

    if (matches.length > 0) {
        text += '</font>';

        for (let i = matches.length - 1; i >= 0; --i) {
            let color = matches[i].found.substring(1, matches[i].found.length - 1);
            let insertHtml = (i != 0 ? '</font>' : '') + '<font color="#' + color + '">';
            text = text.slice(0, matches[i].index) + insertHtml + text.slice(matches[i].index + matches[i].found.length, text.length);
        }
    }
    return text;
}

// Functions - Actions
function pushMessage(text, color = 'white', gradient = false, icon = false) {
    if (text.length < 1) return;
    text = colorify(text);
    if (gradient !== false && Array.isArray(gradient) === false) return;

    let style = `color:${color};`

    if (gradient)
        style += `background:linear-gradient(90deg,rgba(${[gradient[0], gradient[1], gradient[2]]},0.3) 0%, rgba(255,255,255,0) 100%);`;

    if (icon)
        text = `<i class="fi-${icon}" style="padding:0 2px 0 2px"></i> ` + text;

    chatMessagesList.append(`<div class="chat-message no-select" style="${style}">${text}</div>`);

    // Check if player's chat is scrolled all the way to the bottom. If true, then scroll down for new message to appear,
    // if false, inform player about new message(s).
    (getScrolledUpMessagesAmount() >= 4) ? toggleWarningText(true) : scrollMessagesList('bottom');
}

function scrollMessagesList(direction) {
    const pixels = 22 * 5;

    switch (direction) {
        case 'up':
            chatMessagesList.stop().animate({ scrollTop: `-=${pixels}px` }, 250);
            break;
        case 'down':
            chatMessagesList.stop().animate({ scrollTop: `+=${pixels}px` }, 250);
            break;
        case 'bottom':
            chatMessagesList.stop().animate({ scrollTop: chatMessagesList.prop('scrollHeight') }, 250);
            break;
    }

    setTimeout(() => {
        if (getScrolledUpMessagesAmount() == 0) toggleWarningText(false);
    }, 250);
}

function activateChat(state) {
    chatActive = state;
    (state) ? chatBox.removeClass('hide') : chatBox.addClass('hide');

    alt.emit('chat:onChatStateChange', state);
}

function activateInput(state) {
    inputActive = state;

    // Restart Input Bar Length Counter
    setInputBarLengthCounterCurrent(0);

    // Restart Input History
    inputHistoryCache = '';
    inputHistoryCurrent = inputHistory.length;

    switch (state) {
        case true:
            chatInputBar.val('');
            chatInputBarLength.removeClass('hide');
            chatInputBar.removeClass('hide');
            pushButton.removeClass('hide');
            chatInputBar.focus();
            break;
        case false:
            chatInputBarLength.addClass('hide');
            chatInputBar.addClass('hide');
            pushButton.addClass('hide');
            chatInputBar.blur();
            break;
    }
    alt.emit('chat:onInputStateChange', state);
}

function sendInput() {
    const length = chatInputBar.val().length;
    if (length > 0) {
        alt.emit('chat:onInput', chatInputBar.val());
        addInputToHistory(chatInputBar.val());
    }
    activateInput(false);
}

function addInputToHistory(input) {
    // If history list have max amount of inputs, start deleting them from the beginning
    if (inputHistory.length >= _MAX_INPUT_HISTORIES) inputHistory.shift();

    // Add input to history list
    inputHistory.push(input);
}

function shiftHistoryUp() {
    let current = inputHistoryCurrent;
    if (inputHistoryCurrent == inputHistory.length) inputHistoryCache = chatInputBar.val();

    if (current > 0) {
        inputHistoryCurrent--;
        chatInputBar.val(inputHistory[inputHistoryCurrent]);
    }
}

function shiftHistoryDown() {
    if (inputHistoryCurrent == inputHistory.length) return;
    if (inputHistoryCurrent < inputHistory.length - 1) {
        inputHistoryCurrent++;
        chatInputBar.val(inputHistory[inputHistoryCurrent]);
    } else {
        inputHistoryCurrent = inputHistory.length;
        chatInputBar.val(inputHistoryCache);
    }
}

function toggleWarningText(state) {
    switch (state) {
        case true:
            chatNewMessagesWarning.removeClass('hide');
            break;
        case false:
            chatNewMessagesWarning.addClass('hide');
            break;
    }
}

function setInputBarLengthCounterCurrent(amount) {
    chatInputBarLength.html(`${amount}/100`);
}

// Functions - Checks

function getScrolledUpMessagesAmount() {
    const amount = Math.round((chatMessagesList.prop('scrollHeight') - chatMessagesList.scrollTop() - _MAX_MESSAGES_ON_CHAT * 22) / 22);
    return (amount > 0) ? amount : 0;
}
/*
function Call(){
    pushMessage('Privet');
    pushMessage('test');
    pushMessage('Pridasdadadsvet');
    pushMessage('dasdsadsadsadf a');
  
    activateInput(true);
    console.log('Call got called');
  }

  Call();
  */

// alt:V - Callbacks
alt.on('chat:clearMessages', clearMessages);
alt.on('chat:pushMessage', pushMessage);
alt.on('chat:activateChat', activateChat);
alt.on('chat:activateInput', activateInput);
alt.on('chat:sendInput', sendInput);
alt.on('chat:scrollMessagesList', scrollMessagesList);
alt.on('chat:addInputToHistory', addInputToHistory);
alt.on('chat:shiftHistoryUp', shiftHistoryUp);
alt.on('chat:shiftHistoryDown', shiftHistoryDown);

$(function () {
    $(document).keydown(function (objEvent) {
        if (objEvent.ctrlKey) {
            if (objEvent.keyCode == 65) {
                return false;
            }
        }
        if (objEvent.keyCode == 32 && objEvent.target == document.body) {
            objEvent.preventDefault();
        }
        if (objEvent.keyCode == 9) objEvent.preventDefault();
    });
});
