//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


// Static variables
let WindowOpen = false;
let PasswordVisible = false;
let GenderSelected = 0;
/////////////////////////////////////////////////////////////////////////////////////
function LoadLoginWindowEvents() {
    // Login
    $("#login_button").click(function () {
        if (!WindowOpen) {
            $("#login_button").addClass('Button_Active');
            $("#window_login").removeClass('d-none');
            WindowOpen = true;
        }
    });

    $("#window_login_close").click(function () {
        $("#login_button").removeClass('Button_Active');
        $("#window_login").addClass('d-none');
        WindowOpen = false;
    });

    // Register
    $("#register_button").click(function () {
        if (!WindowOpen) {
            $("#register_button").addClass('Button_Active');
            $("#window_register").removeClass('d-none');
            WindowOpen = true;
        }
    });

    $("#window_register_close").click(function () {
        $("#register_button").removeClass('Button_Active');
        $("#window_register").addClass('d-none');
        WindowOpen = false;
    });


    $("#window_login_button").click(function () {
        let name = document.getElementById('usernamee').value;
        let password = document.getElementById('passwordd').value;
        alt.emit('request_player_login', name, password);
    });

    $("#pass_view_click_view").click(function () {
        if (!PasswordVisible) {
            document.getElementById("passwordd").attributes["type"].value = "text";
            PasswordVisible = true;
            $("#pass_view_click_view").addClass('d-none');
            $("#pass_view_click_hide").removeClass('d-none');
        }
    });

    $("#pass_view_click_hide").click(function () {
        if (PasswordVisible) {
            document.getElementById("passwordd").attributes["type"].value = "password";
            PasswordVisible = false;
            $("#pass_view_click_hide").addClass('d-none');
            $("#pass_view_click_view").removeClass('d-none');
        }
    });
}
function LoadRegisterEvents() {
    $('#window_register_male').click(function () {
        GenderSelected = 0;
        // RemoveLastSelectedButton 
        $('#window_register_female').removeClass('d-none');
        $('#window_register_selected_female').addClass('d-none');

        // Select new Button
        $('#window_register_male').addClass('d-none');
        $('#window_register_selected_male').removeClass('d-none');
    });
    $('#window_register_female').click(function () {
        GenderSelected = 1;
        // RemoveLastSelectedButton 
        $('#window_register_male').removeClass('d-none');
        $('#window_register_selected_male').addClass('d-none');

        // Select new Button
        $('#window_register_female').addClass('d-none');
        $('#window_register_selected_female').removeClass('d-none');
    });
    $('#window_register_first').click(function () {
        let username = $('#register_username').val();
        let email = $('#register_email').val();
        let password = $('#register_password').val();
        let password_retype = $('#register_password_retype').val();
        //console.log(username + " | " + email + " | " + password + " | " + password_retype + " | " + GenderSelected);
        alt.emit('Register:First', username, email, password, password_retype, GenderSelected);
    });
}
function LoadTaskbarEvents() {
    $('#task_privacypolicy').click(function () {
        if (!WindowOpen) {
            if (CurrentLanguage == AvailableLanguages.EN) {
                $('#privacypolicy_window_en').removeClass('d-none');
            }
            else {
                $('#privacypolicy_window_de').removeClass('d-none');
            }
            WindowOpen = true;
        }
    });

    $('#window_privacypolicy_close_de').click(function () {
        if (WindowOpen) {
            if (CurrentLanguage == AvailableLanguages.EN) {
                $('#privacypolicy_window_en').addClass('d-none');
            }
            else {
                $('#privacypolicy_window_de').addClass('d-none');
            }
            WindowOpen = false;
        }
    });
    $('#window_privacypolicy_close_en').click(function () {
        if (WindowOpen) {
            if (CurrentLanguage == AvailableLanguages.EN) {
                $('#privacypolicy_window_en').addClass('d-none');
            }
            else {
                $('#privacypolicy_window_de').addClass('d-none');
            }
            WindowOpen = false;
        }
    });

    $('#task_languages').click(function () {

    });
}
let TextList = null;
/////////////////////////////////////////////////////////////////////////////////////

// Language settings

let AvailableLanguages = {
    DE: "Deutsch",
    EN: "English"
};

let DE_Texts = {
    input: {
        username_input_text: "Benutzername hier eintippen...",
        password_input_text: "Passwort hier eintippen...",

        register_username: "Benutzername hier eintippen...",
        register_email: "E-Mail hier eintippen...",
        register_password: "Passwort hier eintippen...",
        register_password_retype: "Passwort wiederholen..."
    },
    buttons: {
        register_male: "Männlich",
        register_female: "Weiblich",
        register_first: "Weiter...",

        taskbar_privacypolicy: "Datenschutzerklärung",
        taskbar_information: "Information",
        taskbar_help: "Hilfe",
        taskbar_music: "Musik an / aus 🔊"
    }

};

let EN_Texts = {
    input: {
        username_input_text: "Type your Username here...",
        password_input_text: "Type your Password here...",

        register_username: "Type your Username here...",
        register_email: "Type your E-Mail here...",
        register_password: "Type your Password here...",
        register_password_retype: "Retype your Password here..."
    },
    buttons: {
        register_male: "Male",
        register_female: "Female",
        register_first: "Continue...",

        taskbar_privacypolicy: "VenoX Privacy Policy",
        taskbar_information: "Information",
        taskbar_help: "Help",
        taskbar_music: "Musik on / off 🔊"
    },
}


function SetTextToLanguage() {
    // Login Inputs
    $('#usernamee').attr("placeholder", TextList.input.username_input_text);
    $('#passwordd').attr("placeholder", TextList.input.password_input_text);

    // Register Inputs
    $('#register_username').attr("placeholder", TextList.input.register_username);
    $('#register_email').attr("placeholder", TextList.input.register_email);
    $('#register_password').attr("placeholder", TextList.input.register_password);
    $('#register_password_retype').attr("placeholder", TextList.input.register_password_retype);

    // Buttons
    $('#window_register_male').html(TextList.buttons.register_male);
    $('#window_register_female').html(TextList.buttons.register_female);
    $('#window_register_first').html(TextList.buttons.register_first);
    //Taskbar 
    $('#task_privacypolicy').html(TextList.buttons.taskbar_privacypolicy);
    $('#task_information').html(TextList.buttons.taskbar_information);
    $('#task_help').html(TextList.buttons.taskbar_help);
    $('#task_music').html(TextList.buttons.taskbar_music);
}

/////////////////////////////////////////////////////////////////////////////////////



$(document).ready(function () {
    // Load the current language list
    if (CurrentLanguage == AvailableLanguages.EN) { TextList = EN_Texts } else { CurrentLanguage = AvailableLanguages.DE; TextList = DE_Texts; }
    LoadLoginWindowEvents();
    LoadTaskbarEvents();
    LoadRegisterEvents();
    SetTextToLanguage();
});



let CurrentLanguage = AvailableLanguages.EN;